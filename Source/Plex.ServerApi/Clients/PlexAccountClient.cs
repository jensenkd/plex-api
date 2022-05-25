namespace Plex.ServerApi.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Api;
    using Interfaces;
    using PlexModels;
    using PlexModels.Account;
    using PlexModels.Account.Announcements;
    using PlexModels.Account.Discover;
    using PlexModels.Account.Resources;
    using PlexModels.Account.User;
    using PlexModels.OAuth;
    using PlexModels.Watchlist;
    using PlexAccount = Models.PlexAccount;
    using User = Models.User;

    /// <summary>
    ///
    /// </summary>
    public class PlexAccountClient : IPlexAccountClient
    {
        private readonly IApiService apiService;
        private readonly ClientOptions clientOptions;
        private const string BaseUri = "https://plex.tv/api/v2/";

        /// <summary>
        /// Initializes a new instance of the <see cref="PlexAccountClient"/> class.
        /// </summary>
        /// <param name="clientOptions">Plex Client Options.</param>
        /// <param name="apiService">Api Service.</param>
        public PlexAccountClient(ClientOptions clientOptions, IApiService apiService)
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
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AddRequestHeaders(ClientUtilities.GetClientMetaHeaders(this.clientOptions))
                    .Build();

            var oAuthPin = await this.apiService.InvokeApiAsync<OAuthPin>(apiRequest);
            oAuthPin.Url =
                $"https://app.plex.tv/auth#?context[device][product]={this.clientOptions.Product}&context[device][environment]=bundled&context[device][layout]=web&context[device][platform]={this.clientOptions.Platform}&context[device][device]={this.clientOptions.DeviceName}&clientID={this.clientOptions.ClientId}&forwardUrl={redirectUrl}&code={oAuthPin.Code}";

            return oAuthPin;
        }

        /// <inheritdoc/>
        public async Task<OAuthPin> GetAuthTokenFromOAuthPinAsync(string pinId)
        {
            var apiRequest =
               new ApiRequestBuilder(BaseUri, $"pins/{pinId}", HttpMethod.Get)
                   .AcceptJson()
                   .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
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
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AddRequestHeaders(ClientUtilities.GetClientMetaHeaders(this.clientOptions))
                    .AcceptJson()
                    .AddJsonBody(userRequest)
                    .Build();

            var account = await this.apiService.InvokeApiAsync<PlexAccount>(apiRequest);

            return account?.User;
        }

        /// <inheritdoc/>
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
        public async Task<PlexModels.Account.PlexAccount> GetPlexHomeAccountAsync(string authToken, string userUUID)
        {

            var apiRequest =
                new ApiRequestBuilder($"https://plex.tv/api/v2/home/users/{userUUID}/switch.json", string.Empty, HttpMethod.Post)
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AddRequestHeaders(ClientUtilities.GetClientMetaHeaders(this.clientOptions))
                    .AddPlexToken(authToken)
                    .AcceptJson()
                    .Build();

            var account = await this.apiService.InvokeApiAsync<PlexModels.Account.PlexAccount>(apiRequest);

            if (account == null)
            {
                throw new ApplicationException("Switching User failed.");
            }

            return account;
        }

        /// <inheritdoc/>
        public async Task<PlexModels.Account.PlexAccount> GetPlexAccountAsync(string authToken)
        {
            var apiRequest = new ApiRequestBuilder(BaseUri + "user.json", string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .Build();

            var account = await this.apiService.InvokeApiAsync<PlexModels.Account.PlexAccount>(apiRequest);

            return account;
        }

        /// <inheritdoc/>
        public async Task<AccountServerContainer> GetAccountServersAsync(string authToken)
        {
            var apiRequest = new ApiRequestBuilder("https://plex.tv/pms/servers.xml", string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .Build();

            var serverContainer = await this.apiService.InvokeApiAsync<AccountServerContainer>(apiRequest);

            return serverContainer;
        }

        /// <inheritdoc/>
        public async Task<ResourceContainer> GetResourcesAsync(string authToken)
        {
            var queryParams = new Dictionary<string, string> {{"includeHttps", "1"}, {"includeRelay", "1"}};

            var apiRequest = new ApiRequestBuilder("https://plex.tv/", "api/resources", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddQueryParams(queryParams)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .AcceptJson()
                .Build();

            var resources = await this.apiService.InvokeApiAsync<ResourceContainer>(apiRequest);
            return resources;
        }

        /// <inheritdoc/>
        public async Task<AnnouncementContainer> GetPlexAnnouncementsAsync(string authToken)
        {
            var apiRequest = new ApiRequestBuilder("https://plex.tv/api/announcements.xml", string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .Build();

            var announcementContainer = await this.apiService.InvokeApiAsync<AnnouncementContainer>(apiRequest);

            return announcementContainer;
        }

        /// <inheritdoc/>
        public async Task<List<Friend>> GetFriendsAsync(string authToken)
        {
            var apiRequest = new ApiRequestBuilder(BaseUri + "friends.json", string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .Build();

            var friends = await this.apiService.InvokeApiAsync<List<Friend>>(apiRequest);
            return friends;
        }

        /// <inheritdoc/>
        public async Task<UserContainer> GetUsers(string authToken)
        {
            var apiRequest = new ApiRequestBuilder("https://plex.tv/api/users", string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .AddRequestHeaders(ClientUtilities.GetClientMetaHeaders(this.clientOptions))
                .Build();

            var container = await this.apiService.InvokeApiAsync<UserContainer>(apiRequest);
            return container;
        }

        /// <inheritdoc/>
        public async Task OptOut(string authToken, bool playback, bool library)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"optOutPlayback", playback ? "1" : "0"},
                {"optOutLibraryStats", library ? "1" : "0"}
            };

            var apiRequest = new ApiRequestBuilder("https://plex.tv/api/v2/user/privacy", string.Empty, HttpMethod.Put)
                .AddPlexToken(authToken)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .AddRequestHeaders(ClientUtilities.GetClientMetaHeaders(this.clientOptions))
                .AddQueryParams(queryParams)
                .AcceptJson()
                .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        /// <inheritdoc/>
        public async Task<List<Device>> GetDevices(string authToken)
        {
            var apiRequest =
                new ApiRequestBuilder("https://plex.tv/devices.json",string.Empty, HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                    .AddRequestHeaders(ClientUtilities.GetClientMetaHeaders(this.clientOptions))
                    .AcceptJson()
                    .Build();

            var devices = await this.apiService.InvokeApiAsync<List<Device>>(apiRequest);

            return devices;
        }

        /// <inheritdoc/>
        public async Task<object> LinkDeviceToAccountByPin(string pinCode)
        {
            var apiRequest =
                new ApiRequestBuilder("https://plex.tv/api/v2/pins/link", string.Empty,HttpMethod.Put)
                    .AddContentHeader("Content-Type", "application/x-www-form-urlencoded")
                    .AddRequestHeaders(ClientUtilities.GetClientMetaHeaders(this.clientOptions))
                    .AddJsonBody(new {Code = pinCode})
                    .AcceptJson()
                    .Build();

            return await this.apiService.InvokeApiAsync<object>(apiRequest);
        }

        /// <inheritdoc/>
        public async Task<WatchlistContainer> GetWatchList(string authToken, string filter, string sort, string libraryType)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"includeCollections", "1"},
                {"includeExternalMedia", "1"}
            };

            if (!string.IsNullOrEmpty(libraryType))
            {
                queryParams.Add("libType", libraryType);
            }

            if (!string.IsNullOrEmpty(sort))
            {
                queryParams.Add("sort", sort);
            }

            if (!string.IsNullOrEmpty(filter))
            {
                queryParams.Add("filter", filter);
            }
            else
            {
                queryParams.Add("filter", "all");
            }

            var apiRequest =
                new ApiRequestBuilder("https://metadata.provider.plex.tv/library/sections/watchlist", string.Empty, HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientMetaHeaders(this.clientOptions))
                    .AddQueryParams(queryParams)
                    .AcceptJson()
                    .Build();

            var wrapper = await this.apiService.InvokeApiAsync<GenericWrapper<WatchlistContainer>>(apiRequest);
            return wrapper.Container;
        }

        /// <inheritdoc/>
        public async Task<object> GetHistory(string authToken, int maxResults = 999999)
        {
            var queryParams = new Dictionary<string, string>
            {

                {"includeMetadata", "1"},
                {"includeExternalMedia", "1"}
            };

            var apiRequest =
                new ApiRequestBuilder("https://metadata.provider.plex.tv/library/sections/watchlist", string.Empty, HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientMetaHeaders(this.clientOptions))
                    .AddQueryParams(queryParams)
                    .AcceptJson()
                    .Build();

            var wrapper = await this.apiService.InvokeApiAsync<GenericWrapper<WatchlistContainer>>(apiRequest);
            return wrapper.Container;
        }

        /// <inheritdoc/>
        public async Task<DiscoverSearchContainer> SearchDiscover(string authToken, string query, int limit = 30)
        {
            var queryParams = new Dictionary<string, string>
            {
                {"query", query},
                {"limit", limit.ToString()},
                {"searchTypes", "movies,tv"},
                {"includeMetadata", "1"}
            };

            var apiRequest =
                new ApiRequestBuilder("https://metadata.provider.plex.tv/library/search", string.Empty, HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientMetaHeaders(this.clientOptions))
                    .AddQueryParams(queryParams)
                    .AcceptJson()
                    .Build();

            var wrapper = await this.apiService.InvokeApiAsync<GenericWrapper<DiscoverSearchContainer>>(apiRequest);
            return wrapper.Container;
        }

        /// <inheritdoc/>
        public async Task<WatchlistUserState> OnWatchlist(string authToken, string ratingKey)
        {
            var apiRequest =
                new ApiRequestBuilder($"https://metadata.provider.plex.tv/library/metadata/{ratingKey}/userState", string.Empty, HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientMetaHeaders(this.clientOptions))
                    .AcceptJson()
                    .Build();

            var wrapper = await this.apiService.InvokeApiAsync<GenericWrapper<WatchlistUserStateContainer>>(apiRequest);

            return wrapper.Container.UserState;
        }

        /// <inheritdoc/>
        public async Task AddToWatchlist(string authToken, string ratingKey)
        {
            if (string.IsNullOrEmpty(ratingKey))
            {
                throw new ApplicationException("RatingKey is required");
            }

            var queryParams = new Dictionary<string, string>
            {
                {"ratingKey", ratingKey}
            };

            var apiRequest =
                new ApiRequestBuilder($"https://metadata.provider.plex.tv/actions/addToWatchlist", string.Empty, HttpMethod.Put)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientMetaHeaders(this.clientOptions))
                    .AddQueryParams(queryParams)
                    .AcceptJson()
                    .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }

        /// <inheritdoc/>
        public async Task RemoveFromWatchlist(string authToken, string ratingKey)
        {

            if (string.IsNullOrEmpty(ratingKey))
            {
                throw new ApplicationException("RatingKey is required");
            }

            var queryParams = new Dictionary<string, string>
            {
                {"ratingKey", ratingKey}
            };

            var apiRequest =
                new ApiRequestBuilder($"https://metadata.provider.plex.tv/actions/removeFromWatchlist", string.Empty, HttpMethod.Put)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(ClientUtilities.GetClientMetaHeaders(this.clientOptions))
                    .AddQueryParams(queryParams)
                    .AcceptJson()
                    .Build();

            await this.apiService.InvokeApiAsync(apiRequest);
        }
    }
}
