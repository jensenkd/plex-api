using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Plex.Api.Api;
using Plex.Api.Models;
using Plex.Api.Models.Friends;
using Plex.Api.Models.OAuth;
using Plex.Api.Models.Server;
using Plex.Api.Models.Status;

namespace Plex.Api
{
    public class PlexClient : IPlexClient
    {
        private readonly IApiService _apiService;
        private readonly ClientOptions _clientOptions;
        private readonly string _baseUri = "https://plex.tv/api/v2/";
        
        public PlexClient(ClientOptions clientOptions, IApiService apiService)
        {
            _apiService = apiService;
            _clientOptions = clientOptions;
        }
        
        /// <summary>
        /// Create Pin
        /// </summary>
        /// <returns></returns>
        public async Task<OAuthPin> CreatePin()
        {
            var apiRequest =
                new ApiRequestBuilder(_baseUri, "pins", HttpMethod.Post)
                    .AcceptJson()
                    .AddQueryParam("strong", "true")
                    .AddRequestHeaders(GetClientIdentifierHeader())
                    .AddRequestHeaders(GetClientMetaHeaders())
                    .Build();

            var oauthPin = await _apiService.InvokeApiAsync<OAuthPin>(apiRequest);

            return oauthPin;
        }
        
        /// <summary>
        /// Get Pin
        /// </summary>
        /// <param name="pinId"></param>
        /// <returns></returns>
        public async Task<OAuthPin> GetPin(int pinId)
        {
            var apiRequest =
                new ApiRequestBuilder(_baseUri, $"pins/{pinId}", HttpMethod.Get)
                    .AcceptJson()
                    .AddRequestHeaders(GetClientIdentifierHeader())
                    .Build();

            var oauthPin = await _apiService.InvokeApiAsync<OAuthPin>(apiRequest);

            return oauthPin;
        }
     
        /// <summary>
        /// Sign into the Plex API
        /// This is for authenticating users credentials with Plex
        /// <para>NOTE: Plex "Managed" users do not work</para>
        /// </summary>
        /// <returns></returns>
        public async Task<User> SignIn(string username, string password)
        {
            var userRequest = new PlexUserRequest
            {
                User = new UserRequest
                {
                    Login = username,
                    Password = password
                }
            };
            
            var apiRequest =
                new ApiRequestBuilder("https://plex.tv/users/sign_in.json", string.Empty, HttpMethod.Post)
                    .AddRequestHeaders(GetClientIdentifierHeader())
                    .AddRequestHeaders(GetClientMetaHeaders())
                    .AcceptJson()
                    .AddJsonBody(userRequest)
                    .Build();

            PlexAccount account = await _apiService.InvokeApiAsync<PlexAccount>(apiRequest);

            return account?.User;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public async Task<User> GetAccount(string authToken)
        {
            var apiRequest = new ApiRequestBuilder("https://plex.tv/users/account.json", "", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .Build();

            var account = await _apiService.InvokeApiAsync<PlexAccount>(apiRequest);

            return account?.User;
        }
        
        /// <summary>
        /// http://[PMS_IP_Address]:32400/library/sections?X-Plex-Token=YourTokenGoesHere
        /// Retrieves a list of servers tied to your Plex Account
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <returns></returns>
        public async Task<List<Server>> GetServers(string authToken)
        {
            var apiRequest = new ApiRequestBuilder("https://plex.tv/pms/servers.xml", "", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .Build();

            ServerContainer serverContainer = await _apiService.InvokeApiAsync<ServerContainer>(apiRequest);

            return serverContainer?.Servers;
        }
        
        /// <summary>
        /// Retuns all the Plex friends for this account
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public async Task<List<Friend>> GetFriends(string authToken)
        {
            var apiRequest = new ApiRequestBuilder("https://plex.tv/pms/friends/all", "", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .Build();

            FriendContainer friendContainer = await _apiService.InvokeApiAsync<FriendContainer>(apiRequest);

            return friendContainer?.Friends.ToList();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <returns></returns>
        public async Task<PlexMediaContainer> GetLibraries(string authToken, string plexServerHost)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "library/sections", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var plexMediaContainer = await _apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            return plexMediaContainer;
        }
        
        /// <summary>
        /// Returns a Library
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Plex Host Uri</param>
        /// <param name="key">Library Key</param>
        /// <returns></returns>
        public async Task<PlexMediaContainer> GetLibrary(string authToken, string plexServerHost, string key)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, $"library/sections/{key}/all", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var plexMediaContainer = await _apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            return plexMediaContainer;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Plex Host Uri</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<PlexMediaContainer> GetRecentlyAdded(string authToken, string plexServerHost, string key)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, $"library/sections/{key}/recentlyAdded", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var plexMediaContainer = await _apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            return plexMediaContainer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Plex Host Uri</param>
        /// <param name="metadataId">Metadata Unique Identifier</param>
        /// <returns></returns>
        public async Task<PlexMediaContainer> GetMetadata(string authToken, string plexServerHost, int metadataId)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, $"library/metadata/{metadataId}", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var plexMediaContainer = await _apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            return plexMediaContainer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Plex Host Uri</param>
        /// <param name="metadataId">Metadata Unique Identifier</param>
        /// <returns></returns>
        public async Task<PlexMediaContainer> GetChildrenMetadata(string authToken, string plexServerHost, int metadataId)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, $"library/metadata/{metadataId}/children", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var plexMediaContainer = await _apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            return plexMediaContainer;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Plex Host Uri</param>
        /// <returns></returns>
        public async Task<PlexMediaContainer> GetPlexInfo(string authToken, string plexServerHost)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var plexMediaContainer = await _apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            return plexMediaContainer;
        }
        
        /// <summary>
        /// http://[PMS_IP_Address]:32400/status/sessions?X-Plex-Token=YourTokenGoesHere
        /// Retrieves a list of active sessions on the Plex Media Server instance
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance</param>
        /// <returns></returns>
        public async Task<List<Session>> GetSessions(string authToken, string plexServerHost)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "status/sessions", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var sessionWrapper = await _apiService.InvokeApiAsync<SessionWrapper>(apiRequest);
            
            return sessionWrapper.SessionContainer.Sessions?.ToList();
        }
  
        private Dictionary<string, string> GetClientLimitHeaders(int from, int to)
        {
            var plexHeaders = new Dictionary<string, string>
            {
                ["X-Plex-Container-Start"] = from.ToString(),
                ["X-Plex-Container-Size"] = to.ToString()
            };

            return plexHeaders;
        }
        
        private Dictionary<string, string> GetClientIdentifierHeader()
        {
            var plexHeaders = new Dictionary<string, string>
            {
                ["X-Plex-Client-Identifier"] = _clientOptions.ClientId.ToString("N")
            };

            return plexHeaders;
        }

        private Dictionary<string, string> GetClientMetaHeaders()
        {
            var plexHeaders = new Dictionary<string, string>
            {
                ["X-Plex-Product"] = _clientOptions.ApplicationName,
                ["X-Plex-Version"] = _clientOptions.Version,
                ["X-Plex-Device"] = _clientOptions.DeviceName,
                ["X-Plex-Platform"] = "Web"
            };

            return plexHeaders;
        }
    }
}