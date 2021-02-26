namespace Plex.Api
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;
    using Models.Friends;
    using Models.OAuth;
    using Models.Server;
    using Models.Status;
    using ResourceModels;

    /// <summary>
    /// Inteface for Plex Client.
    /// </summary>
    public interface IPlexClient
    {
        /// <summary>
        /// Create Pin.
        /// </summary>
        /// <param name="redirectUrl">Redirect Url.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<OAuthPin> CreateOAuthPinAsync(string redirectUrl);

        /// <summary>
        /// Get Pin.
        /// </summary>
        /// <param name="pinId">Pin Id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<OAuthPin> GetAuthTokenFromOAuthPinAsync(string pinId);

        /// <summary>
        /// Sign into the Plex API
        /// This is for authenticating users credentials with Plex.
        /// <para>NOTE: Plex "Managed" users do not work.</para>
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<User> SignInAsync(string username, string password);

        /// <summary>
        /// Get Plex Account.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<User> GetAccountAsync(string authToken);

        /// <summary>
        /// Get Plex Resources.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<Resource>> GetResourcesAsync(string authToken);

        /// <summary>
        /// http://[PMS_IP_Address]:32400/library/sections?X-Plex-Token=YourTokenGoesHere
        /// Retrieves a list of servers tied to your Plex Account.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<Server>> GetServersAsync(string authToken);

        /// <summary>
        /// Retuns all the Plex friends for this account.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<Friend>> GetFriendsAsync(string authToken);

        /// <summary>
        /// Get Plex Libraries on given server.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Server Host.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PlexMediaContainer> GetLibrariesAsync(string authToken, string plexServerHost);

        /// <summary>
        /// Returns a Plex Library.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <param name="libraryKey">Library Key.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PlexMediaContainer> GetLibraryAsync(string authToken, string plexServerHost, string libraryKey);

        /// <summary>
        /// Returns Metadata for a Plex Library.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <param name="libraryKey">Library Key.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PlexMediaContainer> GetMetadataForLibraryAsync(string authToken, string plexServerHost, string libraryKey);

        /// <summary>
        /// Get Recently Added items to given Plex Library.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <param name="libraryKey">Library Key.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PlexMediaContainer> GetRecentlyAddedAsync(string authToken, string plexServerHost, string libraryKey);

        /// <summary>
        /// Get On Deck items from Plex Server instance.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PlexMediaContainer> GetOnDeckAsync(string authToken, string plexServerHost);

        /// <summary>
        /// Get Metadata for given Plex Item.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <param name="metadataId">Metadata Unique Identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PlexMediaContainer> GetMetadataAsync(string authToken, string plexServerHost, int metadataId);

        /// <summary>
        /// Get Child Metadata items for a given Metadata Id.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <param name="metadataId">Metadata Unique Identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PlexMediaContainer> GetChildrenMetadataAsync(string authToken, string plexServerHost, int metadataId);

        /// <summary>
        /// Get Plex Server Info.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PlexMediaContainer> GetPlexInfoAsync(string authToken, string plexServerHost);

        /// <summary>
        /// http://[PMS_IP_Address]:32400/status/sessions?X-Plex-Token=YourTokenGoesHere
        /// Retrieves a list of active sessions on the Plex Media Server instance.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<Session>> GetSessionsAsync(string authToken, string plexServerHost);

        /// <summary>
        /// Get Session Information for given Plex Player.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="playerKey">Plex Player Key.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Session> GetSessionByPlayerIdAsync(string authToken, string plexServerHost, string playerKey);

        /// <summary>
        /// Marks the Item in plex as 'Played'.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="ratingKey">Rating Key of the item.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task UnScrobbleItemAsync(string authToken, string plexServerHost, string ratingKey);

        /// <summary>
        /// Scrobble given Plex Item.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="ratingKey">Rating Key of the item.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task ScrobbleItemAsync(string authToken, string plexServerHost, string ratingKey);

        /// <summary>
        /// Search the Plex Media Server.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <param name="query">Search Query.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PlexMediaContainer> SearchAsync(string authToken, string plexServerHost, string query);

        /// <summary>
        /// Get All Collections for a Given Library.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="libraryKey">Library Key.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<CollectionModel>> GetCollectionsAsync(string authToken, string plexServerHost, string libraryKey);

        /// <summary>
        /// Get a Single Plex Collection.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="collectionKey">Rating Key for the Collection.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<CollectionModel> GetCollectionAsync(string authToken, string plexServerHost, string collectionKey);

        /// <summary>
        /// Get Collection Tags for a Movie.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="movieKey">Movie Key.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<string>> GetCollectionTagsForMovieAsync(string authToken, string plexServerHost, string movieKey);

        /// <summary>
        /// Add Collection to a Movie.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="libraryKey">Library Key.</param>
        /// <param name="movieKey">Rating Key of the Movie to add Collection to.</param>
        /// <param name="collectionName">Name of Collection.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddCollectionToMovieAsync(string authToken, string plexServerHost, string libraryKey, string movieKey, string collectionName);

        /// <summary>
        /// Remove a Collection from a Movie.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="libraryKey">Library Key.</param>
        /// <param name="movieKey">Rating Key of the Movie to add Collection to.</param>
        /// <param name="collectionName">Name of Collection.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task DeleteCollectionFromMovieAsync(string authToken, string plexServerHost, string libraryKey, string movieKey, string collectionName);

        /// <summary>
        /// Update Collection.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="libraryKey">Plex Library Key.</param>
        /// <param name="collectionModel">Plex Collection Model for Updating.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task UpdateCollectionAsync(string authToken, string plexServerHost, string libraryKey, CollectionModel collectionModel);

        /// <summary>
        /// Get All Movies attached to a Collection.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="collectionKey">Rating Key for the Collection.</param>
        /// <returns>List of Movies.</returns>
        Task<List<Metadata>> GetCollectionMoviesAsync(string authToken, string plexServerHost, string collectionKey);

        /// <summary>
        /// Start Library Scan for given Plex Library.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="libraryKey">Library Key.</param>
        /// <param name="forceMetadataRefresh">Should Force Metadata Refres.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task ScanLibraryAsync(string authToken, string plexServerHost, string libraryKey, bool forceMetadataRefresh = false);
    }
}
