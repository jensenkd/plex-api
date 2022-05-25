namespace Plex.ServerApi.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Api;
    using Enums;
    using Interfaces;
    using PlexModels;
    using PlexModels.Hubs;
    using PlexModels.Library;
    using PlexModels.Media;
    using PlexModels.Providers;
    using PlexModels.Server;
    using PlexModels.Server.Activities;
    using PlexModels.Server.Clients;
    using PlexModels.Server.Devices;
    using PlexModels.Server.History;
    using PlexModels.Server.Playlists;
    using PlexModels.Server.Sessions;
    using PlexModels.Server.Statistics;
    using PlexModels.Server.Transcoders;
    using PlexModels.Server.Updates;

    /// <inheritdoc/>
    public class PlexServerClient : IPlexServerClient
    {
        private readonly IApiService apiService;
        private readonly ClientOptions clientOptions;

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
        public async Task<MediaContainer> GetHomeRecentlyAddedAsync(string authToken, string plexServerHost,
            int start = 0, int count = 50)
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
        public async Task<MediaContainer> GetLibraryRecentlyAddedAsync(string authToken, string plexServerHost,
            SearchType libraryType, string key, int start = 0, int count = 50)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/sections/{key}/recentlyAdded", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddQueryParam("type", ((int)libraryType).ToString())
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AddRequestHeaders(ClientUtilities.GetClientLimitHeaders(start, count))
                    .AcceptJson()
                    .Build();

            var wrapper = await this.apiService.InvokeApiAsync<GenericWrapper<MediaContainer>>(apiRequest);
            return wrapper.Container;
        }

        /// <inheritdoc/>
        public async Task<MediaContainer> GetHomeOnDeckAsync(string authToken, string plexServerHost, int start,
            int count)
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

        /// <inheritdoc/>
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
        public async Task<HubMediaContainer> GetLibraryHubAsync(string authToken, string plexServerHost, string key,
            int count = 10)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "includeEmpty", "1" },
                { "includeMeta", "1" },
                { "includeFeatureTags", "1" },
                { "includeTypeFirst", "1" },
                { "includeStations", "1" },
                { "includeExternalMedia", "1" },
                { "includeExternalMetadata", "1" },
                { "includeRecentChannels", "1" },
                { "excludePlaylists", "1" },
                { "count", count.ToString() }
            };

            return await this.FetchWithWrapper<HubMediaContainer>(plexServerHost, $"hubs/sections/{key}",
                authToken, HttpMethod.Get, queryParams);
        }

        /// <inheritdoc/>
        public async Task<MediaContainer> GetMediaMetadataAsync(string authToken, string plexServerHost, string key)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "includeExternalMedia", "1" },
                { "skipRefresh", "1" },
                { "includePreferences", "1" },
                { "includeExtras", "1" },
                { "includeStations", "1" },
                { "includeChapters", "1" },
            };

            return await this.FetchWithWrapper<MediaContainer>(plexServerHost, $"library/metadata/{key}",
                authToken, HttpMethod.Get, queryParams);
        }

        /// <inheritdoc/>
        public async Task<MediaContainer> GetChildrenMetadataAsync(string authToken, string plexServerHost, int id)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "includeExternalMedia", "1" },
                { "skipRefresh", "1" },
                { "includePreferences", "1" },
                { "includeExtras", "1" },
                { "includeStations", "1" },
                { "includeChapters", "1" },
                { "includeGuids", "1" }
            };

            // var apiRequest =
            //     new ApiRequestBuilder(plexServerHost, $"library/metadata/{id}/children", HttpMethod.Get)
            //         .AddPlexToken(authToken)
            //         .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
            //         .AcceptJson()
            //         .Build();

            return await this.FetchWithWrapper<MediaContainer>(plexServerHost, $"library/metadata/{id}/children",
                authToken, HttpMethod.Get, queryParams);

            // var plexMediaContainer = await this.apiService.InvokeApiAsync<MediaContainer>(apiRequest);
            //
            // return plexMediaContainer;
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
        public async Task<SessionContainer> GetSessionsAsync(string authToken, string plexServerHost)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "includeExternalMedia", "1" },
                { "includePreferences", "1" },
                { "includeExtras", "1" },
                { "includeStations", "1" },
                { "includeChapters", "1" },
                { "includeGuids", "1" }
            };
            return await this.FetchWithWrapper<SessionContainer>(plexServerHost, "status/sessions",
                authToken, HttpMethod.Get, queryParams);
        }

        /// <inheritdoc/>
        public Task<SessionContainer> GetSessionByPlayerIdAsync(string authToken, string plexServerHost,
            string playerKey)
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
        public async Task<HistoryMediaContainer> GetPlayHistory(string authToken, string plexServerHost, int start = 0,
            int count = 100, DateTime? minDate = null, int? accountId = null)
        {
            var queryParams = new Dictionary<string, string>
            {
                { "X-Plex-Container-Start", start.ToString() }, { "X-Plex-Container-Size", count.ToString() }
            };

            if (minDate != null)
            {
                var dateTimeOffset = new DateTimeOffset(minDate.Value);
                var unixMinDate = dateTimeOffset.ToUnixTimeSeconds();
                queryParams.Add("viewedAt>", unixMinDate.ToString());
            }

            if (accountId != null)
            {
                queryParams.Add("accountID", accountId.ToString());
            }

            return await this.FetchWithWrapper<HistoryMediaContainer>(plexServerHost, "status/sessions/history/all",
                authToken, HttpMethod.Get, queryParams);
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
            await this.FetchWithWrapper<TranscodeContainer>(plexServerHost, "transcode/sessions", authToken,
                HttpMethod.Get);

        /// <inheritdoc/>
        public async Task<PlaylistContainer> GetPlaylists(string authToken, string plexServerHost) =>
            await this.FetchWithWrapper<PlaylistContainer>(plexServerHost, "playlists", authToken, HttpMethod.Get);

        /// <inheritdoc/>
        public async Task<object> GetLogs(string authToken, string plexServerHost) =>
            await this
                .FetchWithWrapper<object>(plexServerHost, "logs", authToken, HttpMethod.Get);

        public async Task<TransientTokenContainer> GetTransientToken(string authToken, string plexServerHost)
        {
            var queryParams =
                new Dictionary<string, string> { { "type", "delegation" }, { "scope", "all" }, };

            return await this
                .FetchWithWrapper<TransientTokenContainer>(plexServerHost, "security/token", authToken, HttpMethod.Get,
                    queryParams);
        }

        /// <inheritdoc/>
        public Task<object> InviteFriend(string authToken, string plexServerHost, string sections, bool allowSync,
            bool allowCameraUpload,
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
