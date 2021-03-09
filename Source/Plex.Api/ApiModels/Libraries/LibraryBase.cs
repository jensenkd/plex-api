namespace Plex.Api.ApiModels.Libraries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Clients.Interfaces;
    using Enums;
    using PlexModels.Hubs;
    using PlexModels.Library.Search;
    using PlexModels.Media;

    /// <summary>
    ///
    /// </summary>
    public class LibraryBase
    {
        /// <summary>
        ///
        /// </summary>
        public readonly IPlexServerClient PlexServerClient;

        /// <summary>
        ///
        /// </summary>
        public readonly IPlexLibraryClient PlexLibraryClient;

        /// <summary>
        ///
        /// </summary>
        protected readonly Server Server;

        /// <summary>
        ///
        /// </summary>
        /// <param name="plexServerClient"></param>
        /// <param name="plexLibraryClient"></param>
        /// <param name="server"></param>
        public LibraryBase(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, Server server)
        {
            this.PlexServerClient = plexServerClient ?? throw new ArgumentNullException(nameof(plexServerClient));
            this.PlexLibraryClient = plexLibraryClient ?? throw new ArgumentNullException(nameof(plexLibraryClient));
            this.Server = server ?? throw new ArgumentNullException(nameof(server));
        }

        public string Uuid { get; set; }

        public string Agent { get; set; }

        public bool AllowSync { get; set; }

        public string Art { get; set; }

        public string Composite { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Filters { get; set; }

        public string Key { get; set; }

        public string Language { get; set; }

        public bool Refreshing { get; set; }

        public string Scanner { get; set; }

        public string Thumb { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<string> Locations { get; set; }

        /// <summary>
        /// Get Filters available for this Library
        /// </summary>
        /// <returns>FilterContainer</returns>
        public async Task<FilterContainer> SearchFilters() =>
            await this.PlexLibraryClient.GetSearchFilters(this.Server.AccessToken, this.Server.Uri.ToString(),
                this.Key);

        /// <summary>
        /// Matching Library Items with Metadata
        /// </summary>
        /// <param name="includeExtendedMetadata"></param>
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
        protected async Task<MediaContainer> Search(bool includeExtendedMetadata, string title, string sort, SearchType libraryType,
            Dictionary<string, string> filters, int start = 0, int count = 100)
        {
            var librarySummaryContainer =
                await this.PlexLibraryClient.LibrarySearch(this.Server.AccessToken, this.Server.Uri.ToString(),
                title, this.Key, sort, libraryType, filters, start, count);

            if (librarySummaryContainer != null && librarySummaryContainer.Size > 0)
            {
                if (includeExtendedMetadata)
                {
                    for (var i = 0; i < librarySummaryContainer.Media.Count; i++)
                    {
                        var mediaContainer = await this.PlexLibraryClient.GetItem(this.Server.AccessToken,
                            this.Server.Uri.ToString(),
                            librarySummaryContainer.Media[i].RatingKey);
                        librarySummaryContainer.Media[i] = mediaContainer.Media.First();
                    }
                }
            }

            return librarySummaryContainer;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<MediaContainer> All(bool includeExtendedMetadata, string sort, int start = 0,
            int count = 100)
        {
            var librarySummaryContainer =
                await this.PlexLibraryClient.GetAll(this.Server.AccessToken, this.Server.Uri.ToString(), this.Key, sort,
                    start, count);

            if (includeExtendedMetadata)
            {
                for (var i = 0; i < librarySummaryContainer.Media.Count; i++)
                {
                    var mediaContainer = await this.PlexLibraryClient.GetItem(this.Server.AccessToken,
                        this.Server.Uri.ToString(),
                        librarySummaryContainer.Media[i].RatingKey);
                    librarySummaryContainer.Media[i] = mediaContainer.Media.First();
                }
            }

            return librarySummaryContainer;
        }

        /// <summary>
        /// Returns recently added items for this library
        /// </summary>
        /// <param name="libraryType">Library Type</param>
        /// <param name="start">Offset number to start with (0 is first record)</param>
        /// <param name="count">Max number of items to return</param>
        /// <returns></returns>
        protected async Task<MediaContainer> RecentlyAdded(SearchType libraryType, int start, int count) =>
            await this.PlexServerClient.GetLibraryRecentlyAddedAsync(this.Server.AccessToken,
                this.Server.Uri.ToString(), libraryType, this.Key, start, count);

        /// <summary>
        /// Return list of Hubs on this library along with their Metadata items
        /// </summary>
        /// <param name="count">Max count of items on each hub</param>
        /// <returns></returns>
        public async Task<HubMediaContainer> Hubs(int count = 10) =>
            await this.PlexServerClient.GetLibraryHubAsync(this.Server.AccessToken, this.Server.Uri.ToString(),
                this.Key, count);

        /// <summary>
        /// Empty Trash for this Library
        /// </summary>
        public async Task EmptyTrash() =>
            await this.PlexLibraryClient.EmptyTrash(this.Server.AccessToken, this.Server.Uri.ToString(), this.Key);

        /// <summary>
        /// Scan for new items on this Library
        /// </summary>
        public async Task ScanForNewItems(bool forceMetadataRefresh) =>
            await this.PlexLibraryClient.ScanForNewItems(this.Server.AccessToken, this.Server.Uri.ToString(), this.Key,
                forceMetadataRefresh);

        /// <summary>
        /// Cancel running Scan on this library
        /// </summary>
        public async Task CancelScan() =>
            await this.PlexLibraryClient.CancelScanForNewItems(this.Server.AccessToken, this.Server.Uri.ToString(),
                this.Key);

        /// <summary>
        /// Get Total Number of Items in Library
        /// </summary>
        /// <returns>Size of library</returns>
        public async Task<int> Size() =>
            await this.PlexLibraryClient.GetLibrarySize(this.Server.AccessToken, this.Server.Uri.ToString(), this.Key);

        /// <summary>
        /// Get Folders for this Library
        /// </summary>
        /// <returns>List of Folders</returns>
        public async Task<object> Folders()
        {
            return await this.PlexLibraryClient.GetLibraryFolders(this.Server.AccessToken, this.Server.Uri.ToString(),
                this.Key);
        }
    }
}
