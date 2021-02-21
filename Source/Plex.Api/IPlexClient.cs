using System.Collections.Generic;
using System.Threading.Tasks;
using Plex.Api.Models;
using Plex.Api.Models.Friends;
using Plex.Api.Models.OAuth;
using Plex.Api.Models.Server;
using Plex.Api.Models.Status;
using Plex.Api.ResourceModels;

namespace Plex.Api
{
    /// <summary>
    ///
    /// </summary>
    public interface IPlexClient
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="redirectUrl"></param>
        /// <returns></returns>
        Task<OAuthPin> CreateOAuthPin(string redirectUrl);

        /// <summary>
        ///
        /// </summary>
        /// <param name="pinId"></param>
        /// <returns></returns>
        Task<OAuthPin> GetAuthTokenFromOAuthPin(string pinId);

        /// <summary>
        ///
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<User> SignIn(string username, string password);

        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns></returns>
        Task<User> GetAccount(string authToken);

        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns></returns>
        Task<List<Resource>> GetResources(string authToken);

        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns></returns>
        Task<List<Server>> GetServers(string authToken);

        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns></returns>
        Task<List<Friend>> GetFriends(string authToken);

        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <returns></returns>
        Task<PlexMediaContainer> GetLibraries(string authToken, string plexServerHost);

        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="libraryKey"></param>
        /// <returns></returns>
        Task<PlexMediaContainer> GetLibrary(string authToken, string plexServerHost, string libraryKey);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="libraryKey"></param>
        /// <returns></returns>
        Task<PlexMediaContainer> GetMetadataForLibrary(string authToken, string plexServerHost, string libraryKey);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="libraryKey"></param>
        /// <returns></returns>
        Task<PlexMediaContainer> GetRecentlyAdded(string authToken, string plexServerHost, string libraryKey);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <returns></returns>
        Task<PlexMediaContainer> GetOnDeck(string authToken, string plexServerHost);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="metadataId"></param>
        /// <returns></returns>
        Task<PlexMediaContainer> GetMetadata(string authToken, string plexServerHost, int metadataId);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="metadataId"></param>
        /// <returns></returns>
        Task<PlexMediaContainer> GetChildrenMetadata(string authToken, string plexServerHost, int metadataId);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <returns></returns>
        Task<PlexMediaContainer> GetPlexInfo(string authToken, string plexServerHost);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <returns></returns>
        Task<List<Session>> GetSessions(string authToken, string plexServerHost);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="playerKey"></param>
        /// <returns></returns>
        Task<Session> GetSessionByPlayerId(string authToken, string plexServerHost, string playerKey);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="ratingKey"></param>
        /// <returns></returns>
        Task UnScrobbleItem(string authToken, string plexServerHost, string ratingKey);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="ratingKey"></param>
        /// <returns></returns>
        Task ScrobbleItem(string authToken, string plexServerHost, string ratingKey);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<PlexMediaContainer> Search(string authToken, string plexServerHost, string query);

        // Collections
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="libraryKey"></param>
        /// <returns></returns>
        Task<List<CollectionModel>> GetCollections(string authToken, string plexServerHost, string libraryKey);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="collectionKey"></param>
        /// <returns></returns>
        Task<CollectionModel> GetCollection(string authToken, string plexServerHost, string collectionKey);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="movieKey"></param>
        /// <returns></returns>
        Task<List<string>> GetCollectionTagsForMovie(string authToken, string plexServerHost, string movieKey);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="libraryKey"></param>
        /// <param name="movieKey"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        Task AddCollectionToMovie(string authToken, string plexServerHost, string libraryKey, string movieKey, string collectionName);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="libraryKey"></param>
        /// <param name="movieKey"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        Task DeleteCollectionFromMovie(string authToken, string plexServerHost, string libraryKey, string movieKey,
            string collectionName);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="libraryKey"></param>
        /// <param name="collectionModel"></param>
        /// <returns></returns>
        Task UpdateCollection(string authToken, string plexServerHost, string libraryKey,
            CollectionModel collectionModel);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="collectionKey"></param>
        /// <returns></returns>
        Task<List<Metadata>> GetCollectionMovies(string authToken, string plexServerHost, string collectionKey);
        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="libraryKey"></param>
        /// <param name="forceMetadataRefresh"></param>
        /// <returns></returns>
        Task ScanLibrary(string authToken, string plexServerHost, string libraryKey, bool forceMetadataRefresh = false);

    }
}
