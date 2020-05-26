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
    public interface IPlexClient
    {
        Task<OAuthPin> CreateOAuthPin(string redirectUrl);
        Task<OAuthPin> GetAuthTokenFromOAuthPin(string pinId);
        Task<User> SignIn(string username, string password);
        Task<User> GetAccount(string authToken);
        Task<List<Resource>> GetResources(string authToken);
        Task<List<Server>> GetServers(string authToken);
        Task<List<Friend>> GetFriends(string authToken);
        Task<PlexMediaContainer> GetLibraries(string authToken, string plexServerHost);
        Task<PlexMediaContainer> GetLibrary(string authToken, string plexServerHost, string libraryKey);
        Task<PlexMediaContainer> GetMetadataForLibrary(string authToken, string plexServerHost, string libraryKey);
        Task<PlexMediaContainer> GetRecentlyAdded(string authToken, string plexServerHost, string libraryKey);
        Task<PlexMediaContainer> GetMetadata(string authToken, string plexServerHost, int metadataId);
        Task<PlexMediaContainer> GetChildrenMetadata(string authToken, string plexServerHost, int metadataId);
        Task<PlexMediaContainer> GetPlexInfo(string authToken, string plexServerHost);
        Task<List<Session>> GetSessions(string authToken, string plexServerHost);
        Task<Session> GetSessionByPlayerId(string authToken, string plexServerHost, string playerKey);
        
        // Collections
        Task<List<CollectionModel>> GetCollections(string authToken, string plexServerHost, string libraryKey);
        Task<CollectionModel> GetCollection(string authToken, string plexServerHost, string collectionKey);
        Task<List<string>> GetCollectionTagsForMovie(string authToken, string plexServerHost, string movieKey);
        Task AddCollectionToMovie(string authToken, string plexServerHost, string libraryKey, string movieKey, string collectionName);
        Task DeleteCollectionFromMovie(string authToken, string plexServerHost, string libraryKey, string movieKey,
            string collectionName);
        Task UpdateCollection(string authToken, string plexServerHost, string libraryKey,
            CollectionModel collectionModel);
        Task<List<Metadata>> GetCollectionMovies(string authToken, string plexServerHost, string collectionKey);

    }
}