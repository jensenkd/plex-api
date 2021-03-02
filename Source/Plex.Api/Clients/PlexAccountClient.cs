namespace Plex.Api.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Api;
    using PlexModels.Account;
    using PlexModels.Account.User;
    using PlexModels.OAuth;
    using PlexModels.Resources;
    using PlexAccount = Models.PlexAccount;
    using User = Models.User;

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
                $"https://app.plex.tv/auth#?context[device][product]={this.clientOptions.Product}&context[device][environment]=bundled&context[device][layout]=desktop&context[device][platform]={this.clientOptions.Platform}&context[device][device]={this.clientOptions.DeviceName}&clientID={this.clientOptions.ClientId}&forwardUrl={redirectUrl}&code={oAuthPin.Code}";

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
        public async Task<List<Resource>> GetResourcesAsync(string authToken)
        {
            var apiRequest = new ApiRequestBuilder(BaseUri + "resources.json", string.Empty, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(ClientUtilities.GetClientIdentifierHeader(this.clientOptions.ClientId))
                .Build();

            var resources = await this.apiService.InvokeApiAsync<List<Resource>>(apiRequest);
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
    }
}
