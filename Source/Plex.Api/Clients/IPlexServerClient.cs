namespace Plex.Api.Clients
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models.Session;
    using PlexModels.Account;
    using PlexModels.Hubs;
    using PlexModels.Library;
    using PlexModels.Media;
    using PlexModels.Providers;
    using PlexModels.Server;
    using PlexModels.Server.Clients;
    using PlexModels.Server.DeviceContainer;
    using PlexModels.Server.History;
    using PlexModels.Server.Releases;
    using ResourceModels;
    using Metadata = PlexModels.Media.Metadata;

    /// <summary>
    /// Inteface for Plex Client.
    /// </summary>
    public interface IPlexServerClient
    {
        /// <summary>
        /// Get Server Providers
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <param name="plexServerHost">Plex Server Host</param>
        /// <returns>Provider Wrapper</returns>
        Task<ProviderContainer> GetServerProvidersAsync(string authToken, string plexServerHost);

        /// <summary>
        /// Get Recently Added items to given Plex Library.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <param name="start">Offset number to start with (0 = first record)</param>
        /// <param name="count">Total Number of record to return</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<MediaContainer> GetHomeRecentlyAddedAsync(string authToken, string plexServerHost, int start = 0, int count = 50);

        /// <summary>
        /// Get On Deck items from Plex Server instance.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <param name="start">Offset number to start with (0 = first record)</param>
        /// <param name="count">Total Number of record to return</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<MediaContainer> GetHomeOnDeckAsync(string authToken, string plexServerHost, int start, int count);

        /// <summary>
        /// Get Home Continue Watacing items from Plex Server instance.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <param name="start">Offset number to start with (0 = first record)</param>
        /// <param name="count">Total Number of record to return</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<MediaContainer> GetHomeContinueWatchingAsync(string authToken, string plexServerHost, int start, int count);

        /// <summary>
        /// Get Plex Server Info.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PlexServer> GetPlexServerInfo(string authToken, string plexServerHost);

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
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="plexServerHost"></param>
        /// <param name="sections"></param>
        /// <param name="allowSync"></param>
        /// <param name="allowCameraUpload"></param>
        /// <param name="allowChannels"></param>
        /// <param name="filterMovies"></param>
        /// <param name="filterTelevision"></param>
        /// <param name="filterMusic"></param>
        /// <returns></returns>
        Task<object> InviteFriend(string authToken, string plexServerHost, string sections, bool allowSync, bool allowCameraUpload, bool allowChannels, string filterMovies, string filterTelevision, string filterMusic);

        /// <summary>
        /// Returns a list of all Devices for this server.
        /// </summary>
        /// <returns></returns>
        Task<DeviceContainer> GetDevices(string authToken, string plexServerHost);




        // TODO Move to Library Client

        /// <summary>
        /// Get Plex Library Sections on given server.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Server Host.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<LibraryContainer> GetLibrariesAsync(string authToken, string plexServerHost);

        /// <summary>
        /// Get Library Hub from Plex Server instance.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <param name="key">Library Key</param>
        /// <param name="count">Total Number of record to return</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<HubMediaContainer> GetLibraryHubAsync(string authToken, string plexServerHost, string key, int count = 10);

        /// <summary>
        /// Get Library Recently Added Items from Plex Server instance.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <param name="key">Library Key</param>
        /// <param name="start">Offset number to start with (0 = first record)</param>
        /// <param name="count">Total Number of record to return</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<MediaContainer> GetLibraryRecentlyAddedAsync(string authToken, string plexServerHost, string key, int start, int count);

        /// <summary>
        /// Get Metadata for given Plex Rating Key.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <param name="key">Rating Key.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<MediaContainer> GetMediaMetadataAsync(string authToken, string plexServerHost, string key);



        /// <summary>
        /// Get Child Metadata items for a given Metadata Id.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Plex Host Uri.</param>
        /// <param name="id">Metadata Unique Identifier.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<MediaContainer> GetChildrenMetadataAsync(string authToken, string plexServerHost, int id);


        /// <summary>
        /// Marks the Item in plex as 'Played'.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Rating Key of the item.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task UnScrobbleItemAsync(string authToken, string plexServerHost, string key);

        /// <summary>
        /// Scrobble given Plex Item.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Rating Key of the item.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task ScrobbleItemAsync(string authToken, string plexServerHost, string key);

        /// <summary>
        /// Get All Collections for a Given Library.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Library Key.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<CollectionModel>> GetCollectionsAsync(string authToken, string plexServerHost, string key);

        /// <summary>
        /// Get a Single Plex Collection.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Rating Key for the Collection.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<CollectionModel> GetCollectionAsync(string authToken, string plexServerHost, string key);

        /// <summary>
        /// Add Collection to a Movie.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="libraryKey">Library Key.</param>
        /// <param name="ratingKey">Rating Key to add Collection to.</param>
        /// <param name="collectionName">Name of Collection.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddCollectionToLibraryItemAsync(string authToken, string plexServerHost, string libraryKey, string ratingKey, string collectionName);

        /// <summary>
        /// Remove a Collection from a Movie.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="libraryKey">Library Key.</param>
        /// <param name="ratingKey">Rating Key to add Collection to.</param>
        /// <param name="collectionName">Name of Collection.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task DeleteCollectionFromLibraryItemAsync(string authToken, string plexServerHost, string libraryKey, string ratingKey, string collectionName);

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
        Task<MediaContainer> GetCollectionMoviesAsync(string authToken, string plexServerHost, string collectionKey);

        /// <summary>
        /// Start Library Scan for given Plex Library.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="libraryKey">Library Key.</param>
        /// <param name="forceMetadataRefresh">Should Force Metadata Refres.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task ScanLibraryAsync(string authToken, string plexServerHost, string libraryKey, bool forceMetadataRefresh = false);

        /// <summary>
        /// Get Library Play History for given Server.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="start">Starting Record</param>
        /// <param name="count">Count of Records</param>
        /// <param name="minDate">Starting Date</param>
        /// <returns>MediaContainer</returns>
        Task<HistoryMediaContainer> GetPlayHistory(string authToken, string plexServerHost, int start = 0, int count = 100, DateTime? minDate = null);

        /// <summary>
        /// Get Clients connected to a given Server
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <returns>ClientMediaContainer</returns>
        Task<ClientMediaContainer> GetClients(string authToken, string plexServerHost);

        /// <summary>
        ///
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="hostUrl"></param>
        /// <returns></returns>
        Task<ReleaseContainer> CheckForUpdate(string accessToken, string hostUrl);
    }
}
