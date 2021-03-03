namespace Plex.Api.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Api;
    using Automapper;
    using Interfaces;
    using PlexModels;
    using PlexModels.Hubs;
    using PlexModels.Library;
    using PlexModels.Media;
    using PlexModels.Providers;
    using PlexModels.Server;
    using PlexModels.Server.Activities;
    using PlexModels.Server.Clients;
    using PlexModels.Server.DeviceContainer;
    using PlexModels.Server.History;
    using PlexModels.Server.Playlists;
    using PlexModels.Server.Releases;
    using PlexModels.Server.Sessions;
    using PlexModels.Server.Statistics;
    using PlexModels.Server.Transcoders;
    using ResourceModels;
    using Metadata = PlexModels.Media.Metadata;

    /// <inheritdoc/>
    public class PlexServerClient : IPlexServerClient
    {
        private readonly IApiService apiService;
        private readonly ClientOptions clientOptions;
        private const string BaseUri = "https://plex.tv/api/v2/";

        /// <summary>
        /// Initializes a new instance of the <see cref="PlexServerClient"/> class.
        /// </summary>
        /// <param name="clientOptions">Plex Client Options.</param>
        /// <param name="apiService">Api Service.</param>
        public PlexServerClient(ClientOptions clientOptions, IApiService apiService)
        {
            this.apiService = apiService;
            this.clientOptions = clientOptions;
        }

        /// <inheritdoc/>
        public async Task<ProviderContainer> GetServerProvidersAsync(string authToken, string plexServerHost)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "media/providers", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .AcceptJson()
                .Build();

            var wrapper = await this.apiService.InvokeApiAsync<GenericWrapper<ProviderContainer>>(apiRequest);
            return wrapper.Container;
        }

        /// <inheritdoc/>
        public async Task<DeviceContainer> GetDevices(string authToken, string plexServerHost)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "devices", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .AcceptJson()
                .Build();

            var wrapper = await this.apiService.InvokeApiAsync<GenericWrapper<DeviceContainer>>(apiRequest);
            return wrapper.Container;
        }

        /// <inheritdoc/>
        public async Task<LibraryContainer> GetLibrariesAsync(string authToken, string plexServerHost)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "library/sections", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .AcceptJson()
                .Build();

            var wrapper = await this.apiService.InvokeApiAsync<GenericWrapper<LibraryContainer>>(apiRequest);
            return wrapper.Container;
        }

        /// <inheritdoc/>
        public async Task<MediaContainer> GetHomeRecentlyAddedAsync(string authToken, string plexServerHost, int start = 0, int count = 50)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"hubs/home/recentlyAdded", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AddRequestHeaders(ClientUtilities.GetClientLimitHeaders(start, count))
                    .AcceptJson()
                    .Build();

            var wrapper = await this.apiService.InvokeApiAsync<GenericWrapper<MediaContainer>>(apiRequest);
            return wrapper.Container;
        }

        /// <inheritdoc/>
        public async Task<MediaContainer> GetLibraryRecentlyAddedAsync(string authToken, string plexServerHost, string key, int start = 0, int count = 50)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/sections/{key}/recentlyAdded", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AddRequestHeaders(ClientUtilities.GetClientLimitHeaders(start, count))
                    .AcceptJson()
                    .Build();

            var wrapper = await this.apiService.InvokeApiAsync<GenericWrapper<MediaContainer>>(apiRequest);
            return wrapper.Container;
        }

        /// <inheritdoc/>
        public async Task<MediaContainer> GetHomeOnDeckAsync(string authToken, string plexServerHost, int start, int count)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"hubs/home/onDeck", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AddRequestHeaders(ClientUtilities.GetClientLimitHeaders(start, count))
                    .AcceptJson()
                    .Build();

            var wrapper = await this.apiService.InvokeApiAsync<GenericWrapper<MediaContainer>>(apiRequest);
            return wrapper.Container;
        }

        public async Task<MediaContainer> GetHomeContinueWatchingAsync(string authToken, string plexServerHost,
            int start, int count)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"hubs/home/continueWatching", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AddRequestHeaders(ClientUtilities.GetClientLimitHeaders(start, count))
                    .AcceptJson()
                    .Build();

            var wrapper = await this.apiService.InvokeApiAsync<GenericWrapper<MediaContainer>>(apiRequest);
            return wrapper.Container;
        }

        /// <inheritdoc/>
        public async Task<HubMediaContainer> GetLibraryHubAsync(string authToken, string plexServerHost, string key, int count = 10)
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

            return  await this.FetchWithWrapper<HubMediaContainer>(plexServerHost, $"hubs/sections/{key}",
                authToken, HttpMethod.Get, queryParams);
        }

        /// <inheritdoc/>
        public async Task<MediaContainer> GetMediaMetadataAsync(string authToken, string plexServerHost, string key) =>
            await this.FetchWithWrapper<MediaContainer>(plexServerHost, $"library/metadata/{key}",
                authToken, HttpMethod.Get);


        /// <inheritdoc/>
        public async Task<MediaContainer> GetChildrenMetadataAsync(string authToken, string plexServerHost, int id)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/metadata/{id}/children", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
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
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .AcceptJson()
                .Build();

            var plexMediaContainer = await this.apiService.InvokeApiAsync<PlexServerContainer>(apiRequest);

            return plexMediaContainer.PlexServer;
        }

        /// <inheritdoc/>
        public async Task<SessionContainer> GetSessionsAsync(string authToken, string plexServerHost) =>
            await this.FetchWithWrapper<SessionContainer>(plexServerHost, "status/sessions",
                authToken, HttpMethod.Get);

        /// <inheritdoc/>
        public Task<SessionContainer> GetSessionByPlayerIdAsync(string authToken, string plexServerHost, string playerKey)
            => throw new NotImplementedException();

        /// <inheritdoc/>
        public async Task UnScrobbleItemAsync(string authToken, string plexServerHost, string key)
        {
            var apiRequest = new ApiRequestBuilder(
                    plexServerHost,
                    ":/unscrobble?identifier=com.plexapp.plugins.library&key=" + key,
                    HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .AcceptJson()
                .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        /// <inheritdoc/>
        public async Task ScrobbleItemAsync(string authToken, string plexServerHost, string key)
        {
            var apiRequest = new ApiRequestBuilder(
                    plexServerHost,
                    ":/scrobble?identifier=com.plexapp.plugins.library&key=" + key,
                    HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .AcceptJson()
                .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        /// <inheritdoc/>
        public async Task<List<CollectionModel>> GetCollectionsAsync(string authToken, string plexServerHost, string key)
        {
            var apiRequest = new ApiRequestBuilder(
                    plexServerHost,
                    $"library/sections/{key}/collections?includeCollections=1&includeAdvanced=1&includeMeta=1",
                    HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
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
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AcceptJson()
                    .AddQueryParams(new Dictionary<string, string>()
                    {
                        {"type", "18"},
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
        public async Task<CollectionModel> GetCollectionAsync(string authToken, string plexServerHost, string key)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "library/metadata/" + key, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .AcceptJson()
                .Build();

            var container = await this.apiService.InvokeApiAsync<MediaContainer>(apiRequest);

            var collection =
                ObjectMapper.Mapper.Map<Metadata, CollectionModel>(container.Media.FirstOrDefault());

            return collection;
        }

        /// <inheritdoc/>
        public async Task<MediaContainer> GetCollectionMoviesAsync(string authToken, string plexServerHost, string collectionKey) =>
            await this.FetchWithWrapper<MediaContainer>(plexServerHost, "library/metadata/" + collectionKey + "/children",
                authToken, HttpMethod.Get);

        /// <inheritdoc/>
        public async Task AddCollectionToLibraryItemAsync(string authToken, string plexServerHost, string libraryKey, string ratingKey, string collectionName)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "library/sections/" + libraryKey + "/all", HttpMethod.Put)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
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
                    .AddQueryParams(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
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
        public async Task<HistoryMediaContainer> GetPlayHistory(string authToken, string plexServerHost, int start = 0, int count = 100, DateTime? minDate = null)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"X-Plex-Container-Start", start.ToString()},
                {"X-Plex-Container-Size", count.ToString()}
            };

            return await this.FetchWithWrapper<HistoryMediaContainer>(plexServerHost, "status/sessions/history/all", authToken, HttpMethod.Get, queryParams);
        }

        /// <inheritdoc/>
        public async Task<ClientMediaContainer> GetClients(string authToken, string plexServerHost) =>
            await this.FetchWithWrapper<ClientMediaContainer>(plexServerHost, "clients", authToken, HttpMethod.Get);

        /// <inheritdoc/>
        public async Task<UpdateContainer> CheckForUpdate(string authToken, string plexServerHost) =>
            await this.FetchWithWrapper<UpdateContainer>(plexServerHost, "updater/status", authToken, HttpMethod.Get);

        /// <inheritdoc/>
        public async Task<ActivityContainer> GetActivities(string authToken, string plexServerHost) =>
            await this.FetchWithWrapper<ActivityContainer>(plexServerHost, "activities", authToken, HttpMethod.Get);

        /// <inheritdoc/>
        public async Task<StatisticContainer> GetStatistics(string authToken, string plexServerHost)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "statistics/resources?timespan=6", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddQueryParam("timespan", "6")
                    .AddQueryParams(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AcceptJson()
                    .Build();

            var wrapper = await this.apiService.InvokeApiAsync<GenericWrapper<StatisticContainer>>(apiRequest);
            return wrapper.Container;
        }

        /// <inheritdoc/>
        public async Task RefreshSyncList(string authToken, string plexServerHost)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "sync/refreshSynclists", HttpMethod.Put)
                    .AddPlexToken(authToken)
                    .AddQueryParams(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AcceptJson()
                    .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        /// <inheritdoc/>
        public async Task RefreshContent(string authToken, string plexServerHost)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "sync/refreshContent", HttpMethod.Put)
                    .AddPlexToken(authToken)
                    .AddQueryParams(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AcceptJson()
                    .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        /// <inheritdoc/>
        public async Task<TranscodeContainer> GetTranscodeSessions(string authToken, string plexServerHost) =>
            await this.FetchWithWrapper<TranscodeContainer>(plexServerHost, "transcode/sessions", authToken, HttpMethod.Get);

        /// <inheritdoc/>
        public async Task<PlaylistContainer> GetPlaylists(string authToken, string plexServerHost) =>
            await this.FetchWithWrapper<PlaylistContainer>(plexServerHost, "playlists", authToken, HttpMethod.Get);

        /// <inheritdoc/>
        public Task<object> InviteFriend(string authToken, string plexServerHost, string sections, bool allowSync, bool allowCameraUpload,
            bool allowChannels, string filterMovies, string filterTelevision, string filterMusic) =>
            throw new NotImplementedException();

        private async Task<T> FetchWithWrapper<T>(string baseUrl, string endpoint, string authToken, HttpMethod method,
            Dictionary<string, string> queryParams = null)
        {
            var apiRequest =
                new ApiRequestBuilder(baseUrl, endpoint, method)
                    .AddPlexToken(authToken)
                    .AddQueryParams(queryParams)
                    .AddQueryParams(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AcceptJson()
                    .Build();

            var wrapper = await this.apiService.InvokeApiAsync<GenericWrapper<T>>(apiRequest);

            return wrapper.Container;
        }
    }
}
