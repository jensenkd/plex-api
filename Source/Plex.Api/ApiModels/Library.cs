namespace Plex.Api.ApiModels
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Clients;
    using Clients.Interfaces;
    using PlexModels.Hubs;
    using PlexModels.Library;
    using PlexModels.Library.Search;
    using PlexModels.Media;
    using ResourceModels;

    public class Library : BaseApi
    {
        private readonly IPlexServerClient plexServerClient;
        private readonly IPlexLibraryClient plexLibraryClient;
        private readonly Server server;

        public Library(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, Server server)
        {
            this.plexServerClient = plexServerClient ?? throw new ArgumentNullException(nameof(plexServerClient));
            this.plexLibraryClient = plexLibraryClient ?? throw new ArgumentNullException(nameof(plexLibraryClient));
            this.server = server ?? throw new ArgumentNullException(nameof(server));
        }

        public bool AllowSync { get; set; }
        public string Art { get; set; }
        public string Composite { get; set; }
        public bool Filters { get; set; }
        public bool Refreshing { get; set; }
        public string Thumb { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Agent { get; set; }
        public string Scanner { get; set; }
        public string Language { get; set; }
        public string Uuid { get; set; }
        public int UpdatedAt { get; set; }
        public int CreatedAt { get; set; }
        public int ScannedAt { get; set; }
        public bool Content { get; set; }
        public bool Directory { get; set; }
        public int ContentChangedAt { get; set; }
        public int Hidden { get; set; }
        public bool? EnableAutoPhotoTags { get; set; }

        public List<LibraryLocation> Location { get; set; }

        /// <summary>
        /// Get Filters available for this Library
        /// </summary>
        /// <returns>FilterContainer</returns>
        public async Task<FilterContainer> SearchFilters() =>
            await this.plexLibraryClient.GetSearchFilters(this.server.AccessToken, this.server.Uri.ToString(), this.Key);

        /// <summary>
        /// Matching Library Items with Metadata
        /// </summary>
        /// <param name="title">General string query to search for (optional).</param>
        /// <param name="sort">column:dir; column can be any of {addedAt, originallyAvailableAt, lastViewedAt,
        /// titleSort, rating, mediaHeight, duration}. dir can be asc or desc (optional).</param>
        /// <param name="libraryType">Filter results to a spcifiec libtype (movie, show, episode, artist,
        /// album, track; optional).</param>
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
        public async Task<MediaContainer> Search(string title, string sort, string libraryType, Dictionary<string, string> filters, int start = 0, int count = 100) =>
            await this.plexLibraryClient.LibrarySearch(this.server.AccessToken, this.server.Uri.ToString(), title, this.Key, sort, libraryType, filters, start, count);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<MediaContainer> All(string sort, int start = 0, int count = 100) =>
            await this.plexLibraryClient.GetAll(this.server.AccessToken, this.server.Uri.ToString(), this.Key, sort, start, count);

        /// <summary>
        /// Returns recently added items for this library
        /// </summary>
        /// <param name="start">Offset number to start with (0 is first record)</param>
        /// <param name="count">Max number of items to return</param>
        /// <returns></returns>
        public async Task<MediaContainer> RecentlyAdded(int start, int count) =>
            await this.plexServerClient.GetLibraryRecentlyAddedAsync(this.server.AccessToken, this.server.Uri.ToString(), this.Key, start, count);

        /// <summary>
        /// Return list of Hubs on this library along with their Metadata items
        /// </summary>
        /// <param name="count">Max count of items on each hub</param>
        /// <returns></returns>
        public async Task<HubMediaContainer> Hubs(int count = 10) =>
            await this.plexServerClient.GetLibraryHubAsync(this.server.AccessToken, this.server.Uri.ToString(), this.Key, count);

        /// <summary>
        /// Empty Trash for this Library
        /// </summary>
        public async Task EmptyTrash() =>
            await this.plexLibraryClient.EmptyTrash(this.server.AccessToken, this.server.Uri.ToString(), this.Key);

        /// <summary>
        /// Scan for new items on this Library
        /// </summary>
        public async Task ScanForNewItems(bool forceMetadataRefresh) =>
            await this.plexLibraryClient.ScanForNewItems(this.server.AccessToken, this.server.Uri.ToString(), this.Key, forceMetadataRefresh);

        /// <summary>
        /// Cancel running Scan on this library
        /// </summary>
        public async Task CancelScan() =>
            await this.plexLibraryClient.CancelScanForNewItems(this.server.AccessToken, this.server.Uri.ToString(), this.Key);

        /// <summary>
        /// Tag a library item with a Collection Name
        /// </summary>
        /// <param name="ratingKey">Item Rating Key.</param>
        /// <param name="collectionName">Collection name to add to item.</param>
        public async void AddCollectionToItem(string ratingKey, string collectionName) =>
            await this.plexServerClient.AddCollectionToLibraryItemAsync(this.server.AccessToken, this.server.Uri.ToString(), this.Key, ratingKey,
                collectionName);

        /// <summary>
        /// Untag a library item with a Collection Name
        /// </summary>
       /// <param name="ratingKey">Item Rating Key.</param>
        /// <param name="collectionName">Collection name to remove from item.</param>
        public async void RemoveCollectionFromItem(string ratingKey, string collectionName) =>
            await this.plexServerClient.DeleteCollectionFromLibraryItemAsync(this.server.AccessToken, this.server.Uri.ToString(), this.Key, ratingKey,
                collectionName);

        /// <summary>
        /// Update Collection
        /// </summary>
        /// <param name="collectionModel">Collection Model</param>
        public async void UpdateCollection(CollectionModel collectionModel) =>
            await this.plexServerClient.UpdateCollectionAsync(this.server.AccessToken, this.server.Uri.ToString(), this.Key, collectionModel);

    }
}
