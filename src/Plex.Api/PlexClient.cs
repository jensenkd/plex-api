using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Plex.Api.Api;
using Plex.Api.Automapper;
using Plex.Api.Models;
using Plex.Api.Models.Friends;
using Plex.Api.Models.OAuth;
using Plex.Api.Models.Server;
using Plex.Api.Models.Status;
using Plex.Api.ResourceModels;

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
        public async Task<OAuthPin> CreateOAuthPin(string redirectUrl)
        {
            var apiRequest =
                new ApiRequestBuilder(_baseUri, "pins", HttpMethod.Post)
                    .AcceptJson()
                    .AddQueryParam("strong", "true")
                    .AddRequestHeaders(GetClientIdentifierHeader())
                    .AddRequestHeaders(GetClientMetaHeaders())
                    .Build();

            var oAuthPin = await _apiService.InvokeApiAsync<OAuthPin>(apiRequest);
            oAuthPin.Url =
                $"https://app.plex.tv/auth#?context[device][product]={_clientOptions.Product}&context[device][environment]=bundled&context[device][layout]=desktop&context[device][platform]={_clientOptions.Platform}&context[device][device]={_clientOptions.DeviceName}&clientID={_clientOptions.ClientId}&forwardUrl={redirectUrl}&code={oAuthPin.Code}";

            return oAuthPin;
        }

        /// <summary>
        /// Get Pin
        /// </summary>
        /// <param name="pinId"></param>
        /// <returns></returns>
        public async Task<OAuthPin> GetAuthTokenFromOAuthPin(string pinId)
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

        public async Task<List<Resource>> GetResources(string authToken)
        {
            var apiRequest = new ApiRequestBuilder("https://plex.tv/pms/resources.xml", "", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .Build();

            ResourceContainer resourceContainer = await _apiService.InvokeApiAsync<ResourceContainer>(apiRequest);

            return resourceContainer?.Devices;
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
        /// <param name="libraryKey">Library Key</param>
        /// <returns></returns>
        public async Task<PlexMediaContainer> GetLibrary(string authToken, string plexServerHost, string libraryKey)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, $"library/sections/{libraryKey}/all", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var plexMediaContainer = await _apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            if (plexMediaContainer.MediaContainer.Identifier == "com.plexapp.plugins.library")
            {
                foreach (var item in plexMediaContainer.MediaContainer.Metadata)
                {
                    var directItem = await GetMetadata(authToken, plexServerHost, int.Parse(item.RatingKey));
                    item.PlexGuid = directItem.MediaContainer.Metadata.First().PlexGuid;
                }

            }

            return plexMediaContainer;
        }

        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Plex Host Uri</param>
        /// <param name="libraryKey">Library Key</param>
        public async Task<PlexMediaContainer> GetMetadataForLibrary(string authToken, string plexServerHost,
            string libraryKey)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/sections/{libraryKey}/all", HttpMethod.Get)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(GetClientIdentifierHeader())
                    .AcceptJson()
                    .Build();

            var plexMediaContainer = await _apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            if (plexMediaContainer.MediaContainer.Identifier == "com.plexapp.plugins.library")
            {
                foreach (var item in plexMediaContainer.MediaContainer.Metadata)
                {
                    var directItem = await GetMetadata(authToken, plexServerHost, int.Parse(item.RatingKey));
                    item.PlexGuid = directItem.MediaContainer.Metadata.First().PlexGuid;
                }

            }

            return plexMediaContainer;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Plex Host Uri</param>
        /// <param name="libraryKey">Library Key</param>
        /// <returns></returns>
        public async Task<PlexMediaContainer> GetRecentlyAdded(string authToken, string plexServerHost,
            string libraryKey)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/sections/{libraryKey}/recentlyAdded", HttpMethod.Get)
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
        public async Task<PlexMediaContainer> GetOnDeck(string authToken, string plexServerHost)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/onDeck", HttpMethod.Get)
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
        public async Task<PlexMediaContainer> GetChildrenMetadata(string authToken, string plexServerHost,
            int metadataId)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, $"library/metadata/{metadataId}/children", HttpMethod.Get)
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

        public Task<Session> GetSessionByPlayerId(string authToken, string plexServerHost, string playerKey)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Marks the Item in plex as 'Played'
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance</param>
        /// <param name="ratingKey">Rating Key of the item</param>
        /// <returns></returns>
        public async Task UnScrobbleItem(string authToken, string plexServerHost, string ratingKey)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost,
                    ":/unscrobble?identifier=com.plexapp.plugins.library&key=" + ratingKey,
                    HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            await _apiService.InvokeApiAsync(apiRequest);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance</param>
        /// <param name="ratingKey">Rating Key of the item</param>
        public async Task ScrobbleItem(string authToken, string plexServerHost, string ratingKey)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost,
                    ":/scrobble?identifier=com.plexapp.plugins.library&key=" + ratingKey,
                    HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            await _apiService.InvokeApiAsync(apiRequest);
        }

        /// <summary>
        /// Search the Plex Media Server
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Plex Host Uri</param>
        /// <param name="query">Search Query</param>
        /// <returns></returns>
        public async Task<PlexMediaContainer> Search(string authToken, string plexServerHost, string query)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "search", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddQueryParams(GetClientIdentifierHeader())
                .AddQueryParam("query", query)
                .AcceptJson()
                .Build();

            var plexMediaContainer = await _apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            return plexMediaContainer;
        }

        /// <summary>
        /// Get All Collections for a Given Library
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance</param>
        /// <param name="libraryKey">Library Key</param>
        /// <returns></returns>
        public async Task<List<CollectionModel>> GetCollections(string authToken, string plexServerHost,
            string libraryKey)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost,
                    "library/sections/" + libraryKey +
                    "/collections?includeCollections=1&includeAdvanced=1&includeMeta=1", HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var container = await _apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            var collections =
                ObjectMapper.Mapper.Map<List<Metadata>, List<CollectionModel>>(container.MediaContainer.Metadata);

            return collections;
        }

        /// <summary>
        /// Delete Collection from Plex
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance</param>
        /// <param name="ratingKey">Rating Key of the Collection to delete</param>
        /// <returns></returns>
        public async Task DeleteCollection(string authToken, string plexServerHost, string ratingKey)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "library/metadata/" + ratingKey, HttpMethod.Delete)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(GetClientIdentifierHeader())
                    .AcceptJson()
                    .Build();

            await _apiService.InvokeApiAsync(apiRequest);
        }

        /// <summary>
        /// Update Collection
        /// </summary>
        /// <returns></returns>
        public async Task UpdateCollection(string authToken, string plexServerHost, string libraryKey,
            CollectionModel collectionModel)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "library/sections/" + libraryKey + "/all", HttpMethod.Put)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(GetClientIdentifierHeader())
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
                        {"contentRating.locked", "1"}
                    })
                    .Build();

            await _apiService.InvokeApiAsync(apiRequest);
        }

        /// <summary>
        /// Get Collection
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance</param>
        /// <param name="collectionKey">Rating Key for the Collection</param>
        /// <returns></returns>
        public async Task<CollectionModel> GetCollection(string authToken, string plexServerHost, string collectionKey)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "library/metadata/" + collectionKey, HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var container = await _apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            var collection =
                ObjectMapper.Mapper.Map<Metadata, CollectionModel>(container.MediaContainer.Metadata.FirstOrDefault());

            return collection;
        }

        /// <summary>
        /// Get Collection Tags for a Movie
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance</param>
        /// <param name="movieKey">Movie Key</param>
        /// <returns></returns>
        public async Task<List<string>> GetCollectionTagsForMovie(string authToken, string plexServerHost,
            string movieKey)
        {
            var movieContainer = await GetMetadata(authToken, plexServerHost, int.Parse(movieKey));
            var movie = movieContainer.MediaContainer.Metadata.FirstOrDefault();

            if (movie != null && movie.Collection.Any())
            {
                return movie.Collection.Select(c => c.Tag)
                    .OrderBy(c => c)
                    .ToList();
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// Get All Movies attached to a Collection
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance</param>
        /// <param name="collectionKey">Rating Key for the Collection</param>
        /// <returns>List of Movies</returns>
        public async Task<List<Metadata>> GetCollectionMovies(string authToken, string plexServerHost,
            string collectionKey)
        {
            var apiRequest = new ApiRequestBuilder(plexServerHost, "library/metadata/" + collectionKey + "/children",
                    HttpMethod.Get)
                .AddPlexToken(authToken)
                .AddRequestHeaders(GetClientIdentifierHeader())
                .AcceptJson()
                .Build();

            var container = await _apiService.InvokeApiAsync<PlexMediaContainer>(apiRequest);

            var items = container.MediaContainer.Metadata;

            return items;
        }

        /// <summary>
        /// Add Collection to a Movie
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance</param>
        /// <param name="libraryKey">Library Key</param>
        /// <param name="movieKey">Rating Key of the Movie to add Collection to</param>
        /// <param name="collectionName">Name of Collection</param>
        /// <returns></returns>
        public async Task AddCollectionToMovie(string authToken, string plexServerHost, string libraryKey,
            string movieKey,
            string collectionName)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "library/sections/" + libraryKey + "/all", HttpMethod.Put)
                    .AddPlexToken(authToken)
                    .AddRequestHeaders(GetClientIdentifierHeader())
                    .AcceptJson()
                    .AddQueryParams(new Dictionary<string, string>()
                    {
                        {"type", "1"},
                        {"id", movieKey},
                        {"includeExternalMedia", "1"},
                        {"collection[0].tag.tag", collectionName},
                        {"collection.locked", "1"}
                    })
                    .Build();

            await _apiService.InvokeApiAsync(apiRequest);
        }

        /// <summary>
        /// Remove a Collection from a Movie
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance</param>
        /// <param name="libraryKey">Library Key</param>
        /// <param name="movieKey">Rating Key of the Movie to add Collection to</param>
        /// <param name="collectionName">Name of Collection</param>
        /// <returns></returns>
        public async Task DeleteCollectionFromMovie(string authToken, string plexServerHost, string libraryKey,
            string movieKey,
            string collectionName)
        {
            var apiRequest =
                new ApiRequestBuilder(plexServerHost, "library/sections/" + libraryKey + "/all", HttpMethod.Put)
                    .AddPlexToken(authToken)
                    .AddQueryParams(GetClientIdentifierHeader())
                    .AcceptJson()
                    .AddJsonBody(new Dictionary<string, string>()
                    {
                        {"type", "1"},
                        {"id", movieKey},
                        {"includeExternalMedia", "1"},
                        {"collection.locked", "1"},
                        {"collection[0].tag.tag-", collectionName}
                    })
                    .Build();

            await _apiService.InvokeApiAsync(apiRequest);
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
                ["X-Plex-Client-Identifier"] = _clientOptions.ClientId
            };

            return plexHeaders;
        }

        private Dictionary<string, string> GetClientMetaHeaders()
        {
            var plexHeaders = new Dictionary<string, string>
            {
                ["X-Plex-Product"] = _clientOptions.Product,
                ["X-Plex-Version"] = _clientOptions.Version,
                ["X-Plex-Device"] = _clientOptions.DeviceName,
                ["X-Plex-Platform"] = _clientOptions.Platform
            };

            return plexHeaders;
        }
    }
}