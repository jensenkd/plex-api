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
    using Models.Announcements;
    using Models.Friends;
    using Models.Metadata;
    using Models.OAuth;
    using Models.Providers;
    using Models.Server;
    using Models.Server.Resources;
    using Models.Session;
    using ResourceModels;
    using Provider = Models.Provider;

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

        /// <inheritdoc/>
        public async Task<User> GetAccountAsync(string authToken)
        {
            var apiRequest = new ApiRequestBuilder("https://plex.tv/users/account.json", string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .Build();

            var account = await this.apiService.InvokeApiAsync<PlexAccount>(apiRequest);

            return account?.User;
        }

        /// <inheritdoc/>
        public async Task<List<Server>> GetServersAsync(string authToken, bool showActiveOnly)
        {
            var apiRequest = new ApiRequestBuilder("https://plex.tv/pms/servers.xml", string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .Build();

            var serverContainer = await this.apiService.InvokeApiAsync<ServerContainer>(apiRequest);

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
        public async Task<List<Resource>> GetResourcesAsync(string authToken)
        {
            var apiRequest = new ApiRequestBuilder("https://plex.tv/pms/resources.xml", string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .Build();

            var resourceContainer = await this.apiService.InvokeApiAsync<ResourceContainer>(apiRequest);

            return resourceContainer?.Devices;
        }

        /// <inheritdoc/>
        public async Task<List<Friend>> GetFriendsAsync(string authToken)
        {
            var apiRequest = new ApiRequestBuilder("https://plex.tv/pms/friends/all", string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .Build();

            var friendContainer = await this.apiService.InvokeApiAsync<FriendContainer>(apiRequest);

            return friendContainer?.Friends.ToList();
        }

        /// <inheritdoc/>
        public async Task<PlexMediaContainer> GetLibrariesAsync(string authToken, string plexServerHost)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "library/sections", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            return plexMediaContainer;
        }

        /// <inheritdoc/>
        public async Task<PlexMediaContainer> GetLibraryAsync(string authToken, string plexServerHost, string libraryKey)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, $"library/sections/{libraryKey}/all", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            if (plexMediaContainer.MediaContainer.Identifier == "com.plexapp.plugins.library")
            {
                foreach (var item in plexMediaContainer.MediaContainer.Metadata)
                {
                    var directItem = await this.GetMetadataAsync(authToken, plexServerHost, int.Parse(item.RatingKey));
                    item.PlexGuid = directItem.MediaContainer.Metadata.First().PlexGuid;
                }
            }

            return plexMediaContainer;
        }

        /// <inheritdoc/>
        public async Task<PlexMediaContainer> GetMetadataForLibraryAsync(string authToken, string plexServerHost, string libraryKey)
        {
            if (libraryKey == null)
            {
                throw new ArgumentNullException(nameof(libraryKey));
            }

            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/sections/{libraryKey}/all", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AcceptJson()
                    .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            if (plexMediaContainer.MediaContainer.Identifier == "com.plexapp.plugins.library")
            {
                foreach (var item in plexMediaContainer.MediaContainer.Metadata)
                {
                    var directItem = await this.GetMetadataAsync(authToken, plexServerHost, int.Parse(item.RatingKey));
                    item.PlexGuid = directItem.MediaContainer.Metadata.First().PlexGuid;
                    item.PlexRating = directItem.MediaContainer.Metadata.First().Rating;
                }
            }

            return plexMediaContainer;
        }

        /// <inheritdoc/>
        public async Task<PlexMediaContainer> GetRecentlyAddedAsync(string authToken, string plexServerHost, string libraryKey)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/sections/{libraryKey}/recentlyAdded", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AcceptJson()
                    .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            return plexMediaContainer;
        }

        /// <inheritdoc/>
        public async Task<PlexMediaContainer> GetOnDeckAsync(string authToken, string plexServerHost)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/onDeck", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AcceptJson()
                    .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            return plexMediaContainer;
        }

        /// <inheritdoc/>
        public async Task<PlexMediaContainer> GetMetadataAsync(string authToken, string plexServerHost, int metadataId)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, $"library/metadata/{metadataId}", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            return plexMediaContainer;
        }

        /// <inheritdoc/>
        public async Task<PlexMediaContainer> GetChildrenMetadataAsync(string authToken, string plexServerHost, int metadataId)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/metadata/{metadataId}/children", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AcceptJson()
                    .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            return plexMediaContainer;
        }

        /// <inheritdoc/>
        public async Task<PlexMediaContainer> GetPlexInfoAsync(string authToken, string plexServerHost)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            return plexMediaContainer;
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
        public async Task<PlexMediaContainer> SearchAsync(string authToken, string plexServerHost, string query)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "search", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddQueryParams(this.GetClientIdentifierHeader())
                    .AddQueryParam("query", query)
                    .AcceptJson()
                    .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

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

            var container = await this.apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            var collections =
                ObjectMapper.Mapper.Map<List<Metadata>, List<CollectionModel>>(container.MediaContainer.Metadata);

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

            var container = await this.apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            var collection =
                ObjectMapper.Mapper.Map<Metadata, CollectionModel>(container.MediaContainer.Metadata.FirstOrDefault());

            return collection;
        }

        /// <inheritdoc/>
        public async Task<List<string>> GetCollectionTagsForMovieAsync(string authToken, string plexServerHost, string movieKey)
        {
            var movieContainer = await this.GetMetadataAsync(authToken, plexServerHost, int.Parse(movieKey));
            var movie = movieContainer.MediaContainer.Metadata.FirstOrDefault();

            if (movie != null && movie.Collection.Any())
            {
                return movie.Collection.Select(c => c.Tag)
                    .OrderBy(c => c)
                    .ToList();
            }

            return null;
        }

        /// <inheritdoc/>
        public async Task<List<Metadata>> GetCollectionMoviesAsync(string authToken, string plexServerHost, string collectionKey)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "library/metadata/" + collectionKey + "/children", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(this.GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var container = await this.apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            var items = container.MediaContainer.Metadata;

            return items;
        }

        /// <inheritdoc/>
        public async Task AddCollectionToMovieAsync(string authToken, string plexServerHost, string libraryKey, string movieKey, string collectionName)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "library/sections/" + libraryKey + "/all", HttpMethod.Put)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(this.GetClientIdentifierHeader())
                    .AcceptJson()
                    .AddQueryParams(new Dictionary<string, string>()
                    {
                        {"type", "1"},
                        {"id", movieKey},
                        {"includeExternalMedia", "1"},
                        {"collection[0].tag.tag", collectionName},
                        {"collection.locked", "1"},
                    })
                    .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        /// <inheritdoc/>
        public async Task DeleteCollectionFromMovieAsync(string authToken, string plexServerHost, string libraryKey, string movieKey, string collectionName)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "library/sections/" + libraryKey + "/all", HttpMethod.Put)
                    .AddPlexToken(authToken)
                    .AddQueryParams(this.GetClientIdentifierHeader())
                    .AcceptJson()
                    .AddJsonBody(new Dictionary<string, string>()
                    {
                        {"type", "1"},
                        {"id", movieKey},
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
