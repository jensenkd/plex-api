namespace Plex.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Api;
    using Automapper;
    using Models;
    using Models.OAuth;
    using Models.Providers;
    using Models.Session;
    using PlexModels;
    using PlexModels.Account;
    using PlexModels.Hubs;
    using PlexModels.Library;
    using PlexModels.Media;
    using PlexModels.Server;
    using ResourceModels;
    using Metadata = PlexModels.Media.Metadata;
    using PlexAccount = Models.PlexAccount;

    /// <inheritdoc/>
    public class PlexClient : IPlexClient
    {
        private readonly IApiService apiService;
        private readonly ClientOptions clientOptions;
        private const string BaseUri = "https://plex.tv/api/v2/";

        /// <summary>
        /// Initializes a new instance of the <see cref="PlexClient"/> class.
        /// </summary>
        /// <param name="clientOptions">Plex Client Options.</param>
        /// <param name="apiService">Api Service.</param>
        public PlexClient(ClientOptions clientOptions, IApiService apiService)
        {
            this.apiService = apiService;
            this.clientOptions = clientOptions;
        }

        /// <inheritdoc/>
        public async Task<OAuthPin> CreateOAuthPinAsync(string redirectUrl)
        {
            if (redirectUrl == null)
            {
                throw new ArgumentNullException(nameof(redirectUrl));
            }

            var apiRequest =
                new ApiRequestBuilder(BaseUri, "pins", HttpMethod.Post)
                    .AcceptJson()
                    .AddQueryParam("strong", "true")
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AddRequestHeaders(this.GetClientMetaHeaders())
                    .Build();

            var oAuthPin = await this.apiService.InvokeApiAsync<OAuthPin>(apiRequest);
            oAuthPin.Url =
                $"https://app.plex.tv/auth#?context[device][product]={this.clientOptions.Product}&context[device][environment]=bundled&context[device][layout]=desktop&context[device][platform]={this.clientOptions.Platform}&context[device][device]={this.clientOptions.DeviceName}&clientID={this.clientOptions.ClientId}&forwardUrl={redirectUrl}&code={oAuthPin.Code}";

            return oAuthPin;
        }

        /// <inheritdoc/>
        public async Task<OAuthPin> GetAuthTokenFromOAuthPinAsync(string pinId)
        {
            var apiRequest =
                new ApiRequestBuilder(BaseUri, $"pins/{pinId}", HttpMethod.Get)
                    .AcceptJson()
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .Build();

            var oauthPin = await this.apiService.InvokeApiAsync<OAuthPin>(apiRequest);

            return oauthPin;
        }

        /// <inheritdoc/>
        public async Task<User> SignInAsync(string username, string password)
        {
            var userRequest = new PlexUserRequest { User = new UserRequest { Login = username, Password = password } };

            var apiRequest =
                new ApiRequestBuilder("https://plex.tv/users/sign_in.json", string.Empty, HttpMethod.Post)
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AddRequestHeaders(this.GetClientMetaHeaders())
                    .AcceptJson()
                    .AddJsonBody(userRequest)
                    .Build();

            var account = await this.apiService.InvokeApiAsync<PlexAccount>(apiRequest);

            return account?.User;
        }

        public async Task<PlexModels.Account.PlexAccount> GetPlexAccountAsync(string username, string password)
        {
            var user = await this.SignInAsync(username, password);

            if (user == null)
            {
                throw new ApplicationException("User login failed.");
            }

            return await this.GetPlexAccountAsync(user.AuthenticationToken);
        }

        /// <inheritdoc/>
        public async Task<PlexModels.Account.PlexAccount> GetPlexAccountAsync(string authToken)
        {
            var apiRequest = new ApiRequestBuilder(BaseUri + "user.json", string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .Build();

            var account = await this.apiService.InvokeApiAsync<PlexModels.Account.PlexAccount>(apiRequest);

            return account;
        }

        /// <inheritdoc/>
        public async Task<List<AccountServer>> GetAccountServersAsync(string authToken, bool showActiveOnly)
        {
            var apiRequest = new ApiRequestBuilder("https://plex.tv/pms/servers.xml", string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .Build();

            var serverContainer = await this.apiService.InvokeApiAsync<AccountServerContainer>(apiRequest);

            // if (showActiveOnly)
            // {
            //     return serverContainer?.Servers.Where(c=>c);
            // }
            return serverContainer?.Servers;
        }

        /// <inheritdoc/>
        public async Task<ProviderWrapper> GetServerProvidersAsync(string authToken, string plexServerHost)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "media/providers", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<ProviderWrapper>(apiRequest);

            return plexMediaContainer;
        }

        public async Task<AnnouncementWrapper> GetPlexAnnouncementsAsync(string authToken)
        {
            var apiRequest = new ApiRequestBuilder("https://plex.tv/api/announcements.xml", string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .Build();

            var announcementContainer = await this.apiService.InvokeApiAsync<AnnouncementWrapper>(apiRequest);

            return announcementContainer;
        }

        /// <inheritdoc/>
        public async Task<List<PlexModels.Resources.Resource>> GetResourcesAsync(string authToken)
        {
            var apiRequest = new ApiRequestBuilder(BaseUri + "resources.json", string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .Build();

            var resources = await this.apiService.InvokeApiAsync<List<PlexModels.Resources.Resource>>(apiRequest);
            return resources;
        }

        /// <inheritdoc/>
        public async Task<List<Friend>> GetFriendsAsync(string authToken)
        {
            var apiRequest = new ApiRequestBuilder(BaseUri + "friends.json", string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .Build();

            var friends = await this.apiService.InvokeApiAsync<List<Friend>>(apiRequest);
            return friends;
        }

        /// <inheritdoc/>
        public async Task<LibrarySummary> GetLibrarySummaryAsync(string authToken, string plexServerHost)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "library/sections", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var libraryWrapper = await this.apiService.InvokeApiAsync<LibrarySummaryWrapper>(apiRequest);

            return libraryWrapper.LibrarySummary;
        }

        /// <inheritdoc/>
        public async Task<MediaContainer> GetMetadataForLibraryAsync(string authToken, string plexServerHost, string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/sections/{key}/all", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AcceptJson()
                    .Build();

            var mediaContainerWrapper = await this.apiService.InvokeApiAsync<MediaContainerWrapper>(apiRequest);

            return mediaContainerWrapper.MediaContainer;
        }

        public async Task<MediaContainer> GetHomeRecentlyAddedAsync(string authToken, string plexServerHost, int start = 0, int count = 50)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"hubs/home/recentlyAdded", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AddRequestHeaders(this.GetClientLimitHeaders(start, count))
                    .AcceptJson()
                    .Build();

            var mediaContainerWrapper = await this.apiService.InvokeApiAsync<MediaContainerWrapper>(apiRequest);

            return mediaContainerWrapper.MediaContainer;
        }

        /// <inheritdoc/>
        public async Task<MediaContainer> GetLibraryRecentlyAddedAsync(string authToken, string plexServerHost, string libraryKey, int start = 0, int count = 50)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/sections/{libraryKey}/recentlyAdded", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AddRequestHeaders(this.GetClientLimitHeaders(start, count))
                    .AcceptJson()
                    .Build();

            var mediaContainerWrapper = await this.apiService.InvokeApiAsync<MediaContainerWrapper>(apiRequest);

            return mediaContainerWrapper.MediaContainer;
        }

        /// <inheritdoc/>
        public async Task<MediaContainer> GetHomeOnDeckAsync(string authToken, string plexServerHost, int start, int count)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"hubs/home/onDeck", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AddRequestHeaders(this.GetClientLimitHeaders(start, count))
                    .AcceptJson()
                    .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<MediaContainerWrapper>(apiRequest);

            return plexMediaContainer.MediaContainer;
        }

        public async Task<MediaContainer> GetHomeContinueWatchingAsync(string authToken, string plexServerHost,
            int start, int count)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"hubs/home/continueWatching", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AddRequestHeaders(this.GetClientLimitHeaders(start, count))
                    .AcceptJson()
                    .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<MediaContainerWrapper>(apiRequest);

            return plexMediaContainer.MediaContainer;
        }

        /// <inheritdoc/>
        public async Task<HubMediaContainer> GetLibraryHubAsync(string authToken, string plexServerHost, string libraryKey, int count = 10)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"includeEmpty", "1"},
                {"includeMeta", "1"},
                {"includeFeatureTags", "1"},
                {"includeTypeFirst", "1"},
                {"includeStations", "1"},
                {"includeExternalMedia", "1"},
                {"includeExternalMetadata", "1"},
                {"includeRecentChannels", "1"},
                {"excludePlaylists", "1"},
                {"count", count.ToString()}
            };

            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"hubs/sections/{libraryKey}", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AddQueryParams(queryParams)
                    .AcceptJson()
                    .Build();

            var hubMediaContainerWrapper = await this.apiService.InvokeApiAsync<HubMediaContainerWrapper>(apiRequest);

            return hubMediaContainerWrapper.HubMediaContainer;
        }

        /// <inheritdoc/>
        public async Task<Metadata> GetMediaMetadataAsync(string authToken, string plexServerHost,
            string ratingKey)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, $"library/metadata/{ratingKey}", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var mediaContainerWrapper = await this.apiService.InvokeApiAsync<MediaContainerWrapper>(apiRequest);

            return mediaContainerWrapper.MediaContainer.Media.FirstOrDefault();
        }


        /// <inheritdoc/>
        public async Task<MediaContainer> GetChildrenMetadataAsync(string authToken, string plexServerHost, int metadataId)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/metadata/{metadataId}/children", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AcceptJson()
                    .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<MediaContainer>(apiRequest);

            return plexMediaContainer;
        }

        /// <inheritdoc/>
        public async Task<PlexServer> GetPlexServerInfo(string authToken, string plexServerHost)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<PlexServerContainer>(apiRequest);

            return plexMediaContainer.PlexServer;
        }

        /// <inheritdoc/>
        public async Task<List<Session>> GetSessionsAsync(string authToken, string plexServerHost)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "status/sessions", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var sessionWrapper = await this.apiService.InvokeApiAsync<SessionWrapper>(apiRequest);

            return sessionWrapper.SessionContainer.Sessions?.ToList();
        }

        /// <inheritdoc/>
        public Task<Session> GetSessionByPlayerIdAsync(string authToken, string plexServerHost, string playerKey)
            => throw new NotImplementedException();

        /// <inheritdoc/>
        public async Task UnScrobbleItemAsync(string authToken, string plexServerHost, string ratingKey)
        {
            var apiRequest = new ApiRequestBuilder(
                    plexServerHost,
                    ":/unscrobble?identifier=com.plexapp.plugins.library&key=" + ratingKey,
                    HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        /// <inheritdoc/>
        public async Task ScrobbleItemAsync(string authToken, string plexServerHost, string ratingKey)
        {
            var apiRequest = new ApiRequestBuilder(
                    plexServerHost,
                    ":/scrobble?identifier=com.plexapp.plugins.library&key=" + ratingKey,
                    HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        /// <inheritdoc/>
        public async Task<MediaContainer> SearchAsync(string authToken, string plexServerHost, string query)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "search", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddQueryParams(this.GetClientIdentifierHeader())
                    .AddQueryParam("query", query)
                    .AcceptJson()
                    .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<MediaContainer>(apiRequest);

            return plexMediaContainer;
        }

        /// <inheritdoc/>
        public async Task<List<CollectionModel>> GetCollectionsAsync(string authToken, string plexServerHost, string libraryKey)
        {
            var apiRequest = new ApiRequestBuilder(
                    plexServerHost,
                    $"library/sections/{libraryKey}/collections?includeCollections=1&includeAdvanced=1&includeMeta=1",
                    HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var container = await this.apiService.InvokeApiAsync<MediaContainer>(apiRequest);

            var collections =
                ObjectMapper.Mapper.Map<List<Metadata>, List<CollectionModel>>(container.Media);

            return collections;
        }

        /// <inheritdoc/>
        public async Task UpdateCollectionAsync(string authToken, string plexServerHost, string libraryKey, CollectionModel collectionModel)
        {
            if (authToken == null)
            {
                throw new ArgumentNullException(nameof(authToken));
            }

            if (plexServerHost == null)
            {
                throw new ArgumentNullException(nameof(plexServerHost));
            }

            if (libraryKey == null)
            {
                throw new ArgumentNullException(nameof(libraryKey));
            }

            if (collectionModel == null)
            {
                throw new ArgumentNullException(nameof(collectionModel));
            }

            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "library/sections/" + libraryKey + "/all", HttpMethod.Put)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AcceptJson()
                    .AddQueryParams(new Dictionary<string, string>()
                    {
                        { "type", "18" },
                        {"id", collectionModel.RatingKey},
                        {"includeExternalMedia", "1"},
                        {"title.value", collectionModel.Title},
                        {"titleSort.value", collectionModel.TitleSort},
                        {"summary.value", collectionModel.Summary},
                        {"contentRating.value", collectionModel.ContentRating},
                        {"title.locked", "1"},
                        {"titleSort.locked", "1"},
                        {"contentRating.locked", "1"},
                    })
                    .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        /// <inheritdoc/>
        public async Task<CollectionModel> GetCollectionAsync(string authToken, string plexServerHost, string collectionKey)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "library/metadata/" + collectionKey, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var container = await this.apiService.InvokeApiAsync<MediaContainer>(apiRequest);

            var collection =
                ObjectMapper.Mapper.Map<Metadata, CollectionModel>(container.Media.FirstOrDefault());

            return collection;
        }

        /// <inheritdoc/>
        public async Task<List<string>> GetCollectionTagsForMovieAsync(string authToken, string plexServerHost, string ratingKey)
        {
            var metadata = await this.GetMediaMetadataAsync(authToken, plexServerHost, ratingKey);

            if (metadata != null && metadata.Collections.Any())
            {
                return metadata.Collections.Select(c => c.Tag)
                    .OrderBy(c => c)
                    .ToList();
            }

            return null;
        }

        // TODO Rewrite this to use different Media Container
        /// <inheritdoc/>
        public async Task<List<Metadata>> GetCollectionMoviesAsync(string authToken, string plexServerHost, string collectionKey)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "library/metadata/" + collectionKey + "/children", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var container = await this.apiService.InvokeApiAsync<MediaContainer>(apiRequest);

            var items = container.Media;

            return items;
        }

        /// <inheritdoc/>
        public async Task AddCollectionToLibraryItemAsync(string authToken, string plexServerHost, string libraryKey, string ratingKey, string collectionName)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "library/sections/" + libraryKey + "/all", HttpMethod.Put)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AcceptJson()
                    .AddQueryParams(new Dictionary<string, string>()
                    {
                        {"type", "1"},
                        {"id", ratingKey},
                        {"includeExternalMedia", "1"},
                        {"collection[0].tag.tag", collectionName},
                        {"collection.locked", "1"},
                    })
                    .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        /// <inheritdoc/>
        public async Task DeleteCollectionFromLibraryItemAsync(string authToken, string plexServerHost, string libraryKey, string ratingKey, string collectionName)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "library/sections/" + libraryKey + "/all", HttpMethod.Put)
                    .AddPlexToken(authToken)
                    .AddQueryParams(this.GetClientIdentifierHeader())
                    .AcceptJson()
                    .AddJsonBody(new Dictionary<string, string>()
                    {
                        {"type", "1"},
                        {"id", ratingKey},
                        {"includeExternalMedia", "1"},
                        {"collection.locked", "1"},
                        {"collection[0].tag.tag-", collectionName},
                    })
                    .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        /// <inheritdoc/>
        public async Task ScanLibraryAsync(string authToken, string plexServerHost, string libraryKey, bool forceMetadataRefresh = false)
        {
            // From https://support.plex.tv/articles/201638786-plex-media-server-url-commands/
            // http://[PMS_IP_ADDRESS]:32400/library/sections/29/refresh?X-Plex-Token=YourTokenGoesHere
            // http://[PMS_IP_ADDRESS]:32400/library/sections/29/refresh?force=1&X-Plex-Token=YourTokenGoesHere
            var apiRequestBuilder =
                new ApiRequestBuilder(plexServerHost, "library/sections/" + libraryKey + "/refresh", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddQueryParams(this.GetClientIdentifierHeader())
                    .AcceptJson();

            if (forceMetadataRefresh)
            {
                apiRequestBuilder = apiRequestBuilder.AddQueryParam("force", "1");
            }

            var apiRequest = apiRequestBuilder.Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        // TODO Incorporate these into the Metadata methods
        private Dictionary<string, string> GetClientLimitHeaders(int from, int to)
        {
            var plexHeaders = new Dictionary<string, string>
            {
                ["X-Plex-Container-Start"] = from.ToString(), ["X-Plex-Container-Size"] = to.ToString(),
            };

            return plexHeaders;
        }

        private Dictionary<string, string> GetClientIdentifierHeader()
        {
            var plexHeaders = new Dictionary<string, string> { ["X-Plex-Client-Identifier"] = this.clientOptions.ClientId };

            return plexHeaders;
        }

        private Dictionary<string, string> GetClientMetaHeaders()
        {
            var plexHeaders = new Dictionary<string, string>
            {
                ["X-Plex-Product"] = this.clientOptions.Product,
                ["X-Plex-Version"] = this.clientOptions.Version,
                ["X-Plex-Device"] = this.clientOptions.DeviceName,
                ["X-Plex-Platform"] = this.clientOptions.Platform,
            };

            return plexHeaders;
        }
    }
}
