namespace Plex.Api.Clients
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Api;
    using PlexModels.Hubs;
    using PlexModels.Library.Search;
    using PlexModels.Media;

    public class PlexLibraryClient : IPlexLibraryClient
    {
        private readonly IApiService apiService;
        private readonly ClientOptions clientOptions;
        private const string BaseUri = "https://plex.tv/api/v2/";

        /// <summary>
        /// Initializes a new instance of the <see cref="PlexLibraryClient"/> class.
        /// </summary>
        /// <param name="clientOptions">Plex Client Options.</param>
        /// <param name="apiService">Api Service.</param>
        public PlexLibraryClient(ClientOptions clientOptions, IApiService apiService)
        {
            this.apiService = apiService;
            this.clientOptions = clientOptions;
        }

        /// <inheritdoc/>
        public async Task EmptyTrash(string authToken, string plexServerHost, string key)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/sections/{key}/emptyTrash", HttpMethod.Put)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AcceptJson()
                    .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        /// <inheritdoc/>
        public async Task ScanForNewItems(string authToken, string plexServerHost, string key)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/sections/{key}/refresh", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AcceptJson()
                    .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        /// <inheritdoc/>
        public async Task CancelScanForNewItems(string authToken, string plexServerHost, string key)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/sections/{key}/refresh", HttpMethod.Delete)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AcceptJson()
                    .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        /// <inheritdoc/>
        public async Task<FilterContainer> GetSearchFilters(string authToken, string plexServerHost, string key)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, $"library/sections/{key}/filters", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .AcceptJson()
                .Build();

            var filterContainer = await this.apiService.InvokeApiAsync<FilterContainerWrapper>(apiRequest);

            return filterContainer.FilterContainer;
        }

        /// <inheritdoc/>
        public async Task<HubMediaContainer> HubLibrarySearch(string authToken, string plexServerHost, string title)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"query", title},
                {"includeCollections", "1"},
                {"includeExternalMedia", "1"}
            };

            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "hubs/search", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AddQueryParams(queryParams)
                    .AcceptJson()
                    .Build();

            var hubMediaContainerWrapper = await this.apiService.InvokeApiAsync<HubMediaContainerWrapper>(apiRequest);

            return hubMediaContainerWrapper.HubMediaContainer;
        }

        /// <inheritdoc/>
        public async Task<MediaContainer> LibrarySearch(string authToken, string plexServerHost, string title, string libraryKey, string sort, string libraryType, int start = 0, int count = 100)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"title", title},
                {"sort", sort},
                {"libtype", libraryType},
                {"container_start", start.ToString()},
                {"max_results", count.ToString()}
            };

            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/sections/{libraryKey}/all", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AddQueryParams(queryParams)
                    .AcceptJson()
                    .Build();

            var mediaContainerWrapper = await this.apiService.InvokeApiAsync<MediaContainerWrapper>(apiRequest);

            return mediaContainerWrapper.MediaContainer;
        }
    }
}
