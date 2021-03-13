namespace Plex.Api.ApiModels.Libraries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Automapper;
    using Clients.Interfaces;
    using Enums;
    using Filters;
    using Helpers.Mappings;
    using PlexModels.Hubs;
    using PlexModels.Library.Search;
    using PlexModels.Media;

    /// <summary>
    ///
    /// </summary>
    public class LibraryBase
    {
        /// <summary>
        /// Filters
        /// </summary>
        private List<FilterModel> _filters;

        /// <summary>
        ///
        /// </summary>
        public readonly IPlexServerClient _plexServerClient;

        /// <summary>
        ///
        /// </summary>
        public readonly IPlexLibraryClient _plexLibraryClient;

        /// <summary>
        ///
        /// </summary>
        protected readonly Server _server;

        /// <summary>
        /// This will become the Base Object for All Plex Libraries.
        /// When we instantiate a library, we will pull all the Filter Fields, Sorts and Operators
        /// </summary>
        /// <param name="plexServerClient"></param>
        /// <param name="plexLibraryClient"></param>
        /// <param name="server"></param>
        public LibraryBase(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, Server server)
        {
            this._plexServerClient = plexServerClient ?? throw new ArgumentNullException(nameof(plexServerClient));
            this._plexLibraryClient = plexLibraryClient ?? throw new ArgumentNullException(nameof(plexLibraryClient));
            this._server = server ?? throw new ArgumentNullException(nameof(server));
        }

        public bool HasFilters { get; }

        public string Uuid { get; set; }

        public string Agent { get; set; }

        public bool AllowSync { get; set; }

        public string Art { get; set; }

        public string Composite { get; set; }

        public DateTime CreatedAt { get; set; }

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
        /// Library Filter Fields
        /// </summary>
        public List<FilterModel> FilterFields
        {
            get
            {
                if (this._filters != null)
                {
                    return this._filters;
                }

                var filterContainer = this._plexLibraryClient.GetFilterFields(this._server.AccessToken, this._server.Uri.ToString(),
                    this.Key).Result;

                this._filters = LibraryFilterMapper.GetFilterModelsFromFilterContainer(filterContainer);

                return this._filters;
            }
        }

        /// <summary>
        /// Get Filter Values for given FieldType and FieldKey
        /// </summary>
        /// <param name="fieldType">Field Type (movie, library, artist, album)</param>
        /// <param name="fieldKey">Field Key (ex: genre, year)</param>
        /// <param name="title">Title of Field Value</param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<FilterValue>> GetFilterValues(string fieldType, string fieldKey, string title)
        {
            // // Check to see if these values are already in cache.
            // if (this._filterValues.ContainsKey(fieldType + "_" + fieldKey))
            // {
            //     if (!string.IsNullOrEmpty(title))
            //     {
            //         return this._filterValues[fieldType + "_" + fieldKey]
            //             .Where(c=>c.Title.Contains(title))
            //             .ToList();
            //     }
            //     return this._filterValues[fieldType + "_" + fieldKey];
            // }

            // Get Filter
            var filterField  = this.FilterFields
                .SingleOrDefault(g=> g.Type == fieldType);

            if (filterField == null)
            {
                throw new ApplicationException("Invalid Filter FieldType: " + fieldType);
            }

            if (filterField.FilterFields == null || !filterField.FilterFields.Any())
            {
                throw new ApplicationException("Invalid Filter FieldKey: " + fieldKey);
            }

            var item = filterField.FilterFields
                .SingleOrDefault(t => t.FieldKey == fieldKey);

            if (item == null)
            {
                throw new ApplicationException("Invalid Filter FieldKey: " + fieldKey);
            }

            var filterValueContainer = await this._plexLibraryClient.GetLibraryFilterValues(this._server.AccessToken,
                this._server.Uri.ToString(), this.Key, item.UriKey);

           // this._filterValues.Add(fieldType + "_" + fieldKey, filterValueContainer.FilterValues);

            if (!string.IsNullOrEmpty(title))
            {
                return filterValueContainer.FilterValues
                    .Where(c=>c.Title.Contains(title))
                    .ToList();
            }

            return filterValueContainer.FilterValues;
        }

        // /// <summary>
        // /// Get Filters available for this Library
        // /// </summary>
        // /// <returns>List of FilterField</returns>
        // public async Task<List<FilterModel>> FilterFields()
        // {
        //      var filterFieldContainer = await this.PlexLibraryClient.GetFilterFields(this.Server.AccessToken, this.Server.Uri.ToString(),
        //         this.Key);
        //
        //     return LibraryFilterMapper.GetFilterModelsFromFilterContainer(filterFieldContainer);
        // }

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
        /// <exception cref="InvalidOperatorException">An invalid Filter Operator was used for a given Filter Field.</exception>
        /// <returns>MediaContainer</returns>
        protected async Task<MediaContainer> Search(bool includeExtendedMetadata, string title, string sort, SearchType libraryType,
            List<FilterRequest> filters, int start, int count)
        {
            // TODO Validate Operators if used [InvalidOperatorException]
            var librarySummaryContainer =
                await this._plexLibraryClient.LibrarySearch(this._server.AccessToken, this._server.Uri.ToString(),
                title, this.Key, sort, libraryType, filters, start, count);

            if (librarySummaryContainer != null && librarySummaryContainer.Size > 0)
            {
                if (includeExtendedMetadata)
                {
                    for (var i = 0; i < librarySummaryContainer.Media.Count; i++)
                    {
                        var mediaContainer = await this._plexLibraryClient.GetItem(this._server.AccessToken,
                            this._server.Uri.ToString(),
                            librarySummaryContainer.Media[i].RatingKey);
                        librarySummaryContainer.Media[i] = mediaContainer.Media.First();
                    }
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
            await this._plexServerClient.GetLibraryRecentlyAddedAsync(this._server.AccessToken,
                this._server.Uri.ToString(), libraryType, this.Key, start, count);

        /// <summary>
        /// Return list of Hubs on this library along with their Metadata items
        /// </summary>
        /// <param name="count">Max count of items on each hub</param>
        /// <returns></returns>
        public async Task<HubMediaContainer> Hubs(int count = 10) =>
            await this._plexServerClient.GetLibraryHubAsync(this._server.AccessToken, this._server.Uri.ToString(),
                this.Key, count);

        /// <summary>
        /// Empty Trash for this Library
        /// </summary>
        public async Task EmptyTrash() =>
            await this._plexLibraryClient.EmptyTrash(this._server.AccessToken, this._server.Uri.ToString(), this.Key);

        /// <summary>
        /// Scan for new items on this Library
        /// </summary>
        public async Task ScanForNewItems(bool forceMetadataRefresh) =>
            await this._plexLibraryClient.ScanForNewItems(this._server.AccessToken, this._server.Uri.ToString(), this.Key,
                forceMetadataRefresh);

        /// <summary>
        /// Cancel running Scan on this library
        /// </summary>
        public async Task CancelScan() =>
            await this._plexLibraryClient.CancelScanForNewItems(this._server.AccessToken, this._server.Uri.ToString(),
                this.Key);

        /// <summary>
        /// Get Total Number of Items in Library
        /// </summary>
        /// <returns>Size of library</returns>
        public async Task<int> Size() =>
            await this._plexLibraryClient.GetLibrarySize(this._server.AccessToken, this._server.Uri.ToString(), this.Key);

        /// <summary>
        /// Get Folders for this Library
        /// </summary>
        /// <returns>List of Folders</returns>
        public async Task<object> Folders() =>
            await this._plexLibraryClient.GetLibraryFolders(this._server.AccessToken, this._server.Uri.ToString(),
                this.Key);

        /// <summary>
        /// Get Library Collections
        /// </summary>
        /// <returns>List of Collection Models</returns>
        protected async Task<List<CollectionModel>> Collections()
        {
            var collectionContainer = await this._plexLibraryClient.GetCollectionsAsync(this._server.AccessToken, this._server.Uri.ToString(), this.Key);

            var collections =
                ObjectMapper.Mapper.Map<List<PlexModels.Library.Collections.Collection>, List<CollectionModel>>(collectionContainer.Collections);

            return collections;
        }

    }
}
