namespace Plex.ServerApi.Clients.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Enums;
    using PlexModels.Folders;
    using PlexModels.Hubs;
    using PlexModels.Library.Collections;
    using PlexModels.Library.Search;
    using PlexModels.Library.Search.Plex.Api.PlexModels.Library.Search;
    using PlexModels.Media;
    using PlexModels.PlayQueues;
    using PlexModels.Server;

    /// <summary>
    /// Inteface for Plex Library Client
    /// </summary>
    public interface IPlexLibraryClient
    {
        /// <summary>
        /// Empty Trash on Server for given Library
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Library Key</param>
        Task EmptyTrash(string authToken, string plexServerHost, string key);

        /// <summary>
        /// Scan library for newly added items
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Library Key</param>
        /// <param name="forceMetadataRefresh">Force refresh the metadata for all items in the library, regardless of
        /// whether they already have metadata.</param>
        Task ScanForNewItems(string authToken, string plexServerHost, string key, bool forceMetadataRefresh);

        /// <summary>
        /// Cancels library scan for given library
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Library Key</param>
        Task CancelScanForNewItems(string authToken, string plexServerHost, string key);

        /// <summary>
        /// Return all the Filter Options for a given Library
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Library Key</param>
        /// <returns></returns>
        Task<FilterFieldContainer> GetFilterFields(string authToken, string plexServerHost, string key);

        /// <summary>
        /// Hub Search across everything
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="title">Title</param>
        /// <returns></returns>
        Task<HubMediaContainer> HubLibrarySearch(string authToken, string plexServerHost, string title);

        /// <summary>
        /// Search for items in this library
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="title">General string query to search for (optional).</param>
        /// <param name="libraryKey">Library Key</param>
        /// <param name="sort">column:dir; column can be any of {addedAt, originallyAvailableAt, lastViewedAt,
        /// titleSort, rating, mediaHeight, duration}. dir can be asc or desc (optional).</param>
        /// <param name="libraryType">Type of Library to sarch (movie, show, episode)</param>
        /// <param name="filters">
        /// Any of the available filters for the current library section. Partial string matches allowed. Multiple matches OR together.
        /// Negative filtering also possible, just add an exclamation mark to the end of filter name, e.g. resolution!=1x1.
        ///        unwatched: Display or hide unwatched content (True, False). [all]
        ///        duplicate: Display or hide duplicate items (True, False). [movie]
        ///        actor: List of actors to search ([actor_or_id, …]). [movie]
        ///        collection: List of collections to search within ([collection_or_id, …]). [all]
        ///        contentRating: List of content ratings to search within ([rating_or_key, …]). [movie,tv]
        ///        country: List of countries to search within ([country_or_key, …]). [movie,music]
        ///        decade: List of decades to search within ([yyy0, …]). [movie]
        ///        director: List of directors to search ([director_or_id, …]). [movie]
        ///        genre: List Genres to search within ([genere_or_id, …]). [all]
        ///        network: List of TV networks to search within ([resolution_or_key, …]). [tv]
        ///        resolution: List of video resolutions to search within ([resolution_or_key, …]). [movie]
        ///        studio: List of studios to search within ([studio_or_key, …]). [music]
        ///        year: List of years to search within ([yyyy, …]). [all]
        /// </param>
        /// <param name="start">Starting record (default 0)</param>
        /// <param name="count">Only return the specified number of results (default 100).</param>
        /// <returns>MediaContainer</returns>
        Task<MediaContainer> LibrarySearch(string authToken, string plexServerHost, string title, string libraryKey,
            string sort, SearchType libraryType, List<FilterRequest> filters = null, int start = 0, int count = 100);

        /// <summary>
        /// Get Extras for Item in Library
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Library Item Key</param>
        /// <returns></returns>
        Task<MediaContainer> GetExtras(string authToken, string plexServerHost, string key);

        /// <summary>
        /// Get Item from Library
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Item Key</param>
        /// <returns></returns>
        Task<MediaContainer> GetItem(string authToken, string plexServerHost, string key);

        /// <summary>
        /// Get Total Size of the Library
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Library Key</param>
        /// <returns></returns>
        Task<int> GetLibrarySize(string authToken, string plexServerHost, string key);

        /// <summary>
        /// Get File Folders for this Library
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Library Key</param>
        /// <returns></returns>
        Task<FolderContainer> GetLibraryFolders(string authToken, string plexServerHost, string key);

        /// <summary>
        /// Get Search Filter Values for this Library for given types
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="key">Library Key</param>
        /// <param name="filterUri">Field Type value (genre, collection, title, etc..)</param>
        Task<FilterValueContainer> GetLibraryFilterValues(string authToken, string plexServerHost, string key,
            string filterUri);

        /// <summary>
        /// Get Filters for this Library
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="librarykey">Library Key</param>
        Task<FilterContainer> GetLibraryFilters(string authToken, string plexServerHost, string librarykey);

        /// <summary>
        /// Get All Collections for a Given Library.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="libraryKey">Library Key.</param>
        /// <param name="title">Title of Collection (optional)</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<CollectionContainer> GetCollectionsAsync(string authToken, string plexServerHost, string libraryKey,
            string title);

        /// <summary>
        /// Get a Single Plex Collection.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="collectionKey">Rating Key for the Collection.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<CollectionContainer> GetCollectionAsync(string authToken, string plexServerHost, string collectionKey);

        /// <summary>
        /// Add Collection to a Movie.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="libraryKey">Library Key.</param>
        /// <param name="ratingKey">Rating Key to add Collection to.</param>
        /// <param name="collectionName">Name of Collection.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddCollectionToLibraryItemAsync(string authToken, string plexServerHost, string libraryKey,
            string ratingKey, string collectionName);

        /// <summary>
        /// Remove a Collection from a Movie.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="libraryKey">Library Key.</param>
        /// <param name="ratingKey">Rating Key to add Collection to.</param>
        /// <param name="collectionName">Name of Collection.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task DeleteCollectionFromLibraryItemAsync(string authToken, string plexServerHost, string libraryKey,
            string ratingKey, string collectionName);

        /// <summary>
        /// Update Collection.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="libraryKey">Plex Library Key.</param>
        /// <param name="collectionModel">Plex Collection Model for Updating.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task UpdateCollectionAsync(string authToken, string plexServerHost, string libraryKey,
            CollectionModel collectionModel);

        /// <summary>
        /// Get All Items attached to a Collection by Collection Key
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="collectionKey">Key for the Collection.</param>
        /// <returns>List of Items in the collection.</returns>
        Task<MediaContainer> GetCollectionItemsAsync(string authToken, string plexServerHost, string collectionKey);

        /// <summary>
        /// /// Get All Items attached to a Collection by Collection Name
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="libraryKey">Library Key</param>
        /// <param name="collectionName">Name of the Collection.</param>
        /// <returns>List of Items in the collection.</returns>
        Task<MediaContainer> GetCollectionItemsByCollectionName(string authToken, string plexServerHost,
            string libraryKey, string collectionName);

        /// <summary>
        /// Get Collection Item Metadata by Collection Key
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Instance.</param>
        /// <param name="collectionKey">Collection Key.</param>
        /// <returns></returns>
        Task<MediaContainer> GetCollectionItemMetadataByKey(string authToken, string plexServerHost, string collectionKey);

        /// <summary>
        /// Creates a PlayQueue for a given library item.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Host Instance.</param>
        /// <param name="hostIdentifier">MachineIdentifier of the Plex Server Host Instance.</param>
        /// <param name="type">Type of media (video, music).</param>
        /// <param name="key">Rating Key of media item.</param>
        /// <param name="isRepeat">If true, media items will repeat.</param>
        /// <param name="isShuffle">If true, items will shuffle-play</param>
        /// <param name="isContinous">If true, additional videos will play when this item completes</param>
        /// <returns></returns>
        Task<PlayQueueContainer> CreatePlayQueue(string authToken, string plexServerHost, string hostIdentifier, string type,
            string key, bool isRepeat, bool isShuffle, bool isContinous);

        /// <summary>
        /// Send PlayQueue to player for playing
        /// </summary>
        /// <param name="hostIdentifier"></param>
        /// <param name="playQueue">PlayQueue object containing media items to play</param>
        /// <param name="type">Type of media (video, music).</param>
        /// <param name="playerIdentifier">Player Identifier</param>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="plexServerHost">Full Uri of Plex Media Server Host Instance.</param>
        /// <param name="transientToken">Transient Token</param>
        /// <param name="offset">Offset in milliseconds to use in media playback</param>
        /// <returns></returns>
        Task SendPlayQueueToPlayer(string plexServerHost, string authToken, string hostIdentifier, PlayQueueContainer playQueue,
            string type, string playerIdentifier, string transientToken, long offset);
    }
}
