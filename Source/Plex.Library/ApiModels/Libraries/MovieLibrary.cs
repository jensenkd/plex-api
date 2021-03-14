namespace Plex.Library.ApiModels.Libraries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ServerApi.Clients.Interfaces;
    using ServerApi.Enums;
    using ServerApi.PlexModels.Library;
    using ServerApi.PlexModels.Library.Collections;
    using ServerApi.PlexModels.Library.Search;
    using ServerApi.PlexModels.Media;
    using Servers;

    /// <summary>
    /// Movie Library
    /// </summary>
    public class MovieLibrary : LibraryBase
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="plexServerClient"></param>
        /// <param name="plexLibraryClient"></param>
        /// <param name="server"></param>
        public MovieLibrary(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, Server server)
            : base(plexServerClient, plexLibraryClient, server)
        {
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime ScannedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool Content { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool Directory { get; set; }

        /// <summary>
        ///
        /// </summary>
        public long ContentChangedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Hidden { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? EnableAutoPhotoTags { get; set; }

        /// <summary>
        ///
        /// </summary>
        public List<LibraryLocation> Location { get; set; }

        /// <summary>
        /// Returns recently added items for this library
        /// </summary>
        /// <param name="start">Starting record (default 0)</param>
        /// <param name="count">Only return the specified number of results (default 100).</param>
        /// <returns></returns>
        public async Task<MediaContainer> RecentlyAdded(int start = 0, int count = 100) =>
            await this.RecentlyAdded(SearchType.Movie, start, count);

        /// <summary>
        /// Search Movies.
        /// </summary>
        /// <param name="title">Title to search for</param>
        /// <param name="sort">Sort order.</param>
        /// <param name="filters">Filters</param>
        /// <param name="start">Starting record (default 0)</param>
        /// <param name="count">Only return the specified number of results (default 100).</param>
        /// <returns></returns>
        public async Task<MediaContainer> SearchMovies(string title, string sort, List<FilterRequest> filters,
            int start = 0, int count = 100) =>
            await this.Search(true, title, sort, SearchType.Movie, filters, start, count);

        /// <summary>
        /// Get All Movies
        /// </summary>
        /// <param name="sort">Sort field:dir</param>
        /// <param name="start">Starting record (default 0)</param>
        /// <param name="count">Only return the specified number of results (default 100).</param>
        /// <returns></returns>
        public async Task<MediaContainer> AllMovies(string sort, int start = 0, int count = 100) =>
            await this.Search(true, string.Empty, sort, SearchType.Movie, null, start, count);

        /// <summary>
        /// Get Movie Collections
        /// </summary>
        /// <returns></returns>
        public async Task<List<CollectionModel>> Collections(string title) =>
            await this.GetCollections(title);

        /// <summary>
        ///
        /// </summary>
        /// <param name="collectionKey"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<CollectionModel> Collection(string collectionKey)
        {
            if (string.IsNullOrEmpty(collectionKey))
            {
                throw new ArgumentNullException(nameof(collectionKey));
            }

            return await this.GetCollectionByKey(collectionKey);
        }

        /// <summary>
        /// Get Media Items associated with a Collection by Collection Key
        /// </summary>
        /// <param name="collectionKey">Collection Key (unique identifier)</param>
        /// <returns>List of Media Items</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<MediaContainer> CollectionItemsByKey(string collectionKey)
        {
            if (string.IsNullOrEmpty(collectionKey))
            {
                throw new ArgumentNullException(nameof(collectionKey));
            }

            return await this._plexLibraryClient.GetCollectionItemsAsync(this._server.AccessToken,
                this._server.Uri.ToString(), collectionKey);
        }

        /// <summary>
        /// Get Media Items associated with a Collection by Collection Name
        /// </summary>
        /// <param name="collectionName">Collection Name</param>
        /// <returns>List of Media Items</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<MediaContainer> CollectionItemsByName(string collectionName)
        {
            if (string.IsNullOrEmpty(collectionName))
            {
                throw new ArgumentNullException(nameof(collectionName));
            }

            return await this._plexLibraryClient.GetCollectionItemsByCollectionName(this._server.AccessToken,
                this._server.Uri.ToString(), this.Key, collectionName);
        }

        /// <summary>
        /// Get Metadata for items associated with a Collection by Collection Key
        /// </summary>
        /// <param name="collectionKey">Collection Key (unique identifier)</param>
        /// <returns>List of Media Items</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<MediaContainer> CollectionItemsMetadataByKey(string collectionKey)
        {
            if (string.IsNullOrEmpty(collectionKey))
            {
                throw new ArgumentNullException(nameof(collectionKey));
            }

            return await this._plexLibraryClient.GetCollectionItemMetadataByKey(this._server.AccessToken,
                this._server.Uri.ToString(), collectionKey);
        }

        /// <summary>
        /// Get Metadata for items associated with a Collection by Collection Name
        /// </summary>
        /// <param name="collectionName">Collection Name</param>
        /// <returns>List of Media Items</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<MediaContainer> CollectionItemsMetadataByName(string collectionName)
        {
            if (string.IsNullOrEmpty(collectionName))
            {
                throw new ArgumentNullException(nameof(collectionName));
            }

            var collections = await this.GetCollections(collectionName);
            if (collections == null || !collections.Any())
            {
                throw new ApplicationException("No Collections available for : " + collectionName);
            }

            return await this._plexLibraryClient.GetCollectionItemMetadataByKey(this._server.AccessToken,
                this._server.Uri.ToString(), collections.First().RatingKey);
        }

        /// <summary>
        /// Tag a library item with a Collection Name
        /// </summary>
        /// <param name="ratingKey">Item Rating Key.</param>
        /// <param name="collectionName">Collection name to add to item.</param>
        public async Task AddCollectionToItem(string ratingKey, string collectionName) =>
            await this._plexLibraryClient.AddCollectionToLibraryItemAsync(this._server.AccessToken,
                this._server.Uri.ToString(), this.Key, ratingKey,
                collectionName);

        /// <summary>
        /// Untag a library item with a Collection Name
        /// </summary>
        /// <param name="ratingKey">Item Rating Key.</param>
        /// <param name="collectionName">Collection name to remove from item.</param>
        public async Task RemoveCollectionFromItem(string ratingKey, string collectionName) =>
            await this._plexLibraryClient.DeleteCollectionFromLibraryItemAsync(this._server.AccessToken,
                this._server.Uri.ToString(), this.Key, ratingKey,
                collectionName);

        /// <summary>
        /// Update Collection
        /// </summary>
        /// <param name="collectionModel">Collection Model</param>
        public async void UpdateCollection(CollectionModel collectionModel) =>
            await this._plexLibraryClient.UpdateCollectionAsync(this._server.AccessToken, this._server.Uri.ToString(),
                this.Key, collectionModel);
    }
}
