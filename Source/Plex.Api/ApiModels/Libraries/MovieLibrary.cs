namespace Plex.Api.ApiModels.Libraries
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Clients.Interfaces;
    using Enums;
    using PlexModels.Library;
    using PlexModels.Media;
    using ResourceModels;

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
        public int ContentChangedAt { get; set; }

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
        /// Tag a library item with a Collection Name
        /// </summary>
        /// <param name="ratingKey">Item Rating Key.</param>
        /// <param name="collectionName">Collection name to add to item.</param>
        public async void AddCollectionToItem(string ratingKey, string collectionName) =>
            await this.PlexServerClient.AddCollectionToLibraryItemAsync(this.Server.AccessToken,
                this.Server.Uri.ToString(), this.Key, ratingKey,
                collectionName);

        /// <summary>
        /// Untag a library item with a Collection Name
        /// </summary>
        /// <param name="ratingKey">Item Rating Key.</param>
        /// <param name="collectionName">Collection name to remove from item.</param>
        public async void RemoveCollectionFromItem(string ratingKey, string collectionName) =>
            await this.PlexServerClient.DeleteCollectionFromLibraryItemAsync(this.Server.AccessToken,
                this.Server.Uri.ToString(), this.Key, ratingKey,
                collectionName);

        /// <summary>
        /// Update Collection
        /// </summary>
        /// <param name="collectionModel">Collection Model</param>
        public async void UpdateCollection(CollectionModel collectionModel) =>
            await this.PlexServerClient.UpdateCollectionAsync(this.Server.AccessToken, this.Server.Uri.ToString(),
                this.Key, collectionModel);

        /// <summary>
        /// Returns recently added items for this library
        /// </summary>
        /// <param name="start">Offset number to start with (0 is first record)</param>
        /// <param name="count">Max number of items to return</param>
        /// <returns></returns>
        public async Task<MediaContainer> RecentlyAdded(int start = 0, int count = 100) =>
            await this.RecentlyAdded(SearchType.Movie, start, count);

        /// <summary>
        ///
        /// </summary>
        /// <param name="title"></param>
        /// <param name="sort"></param>
        /// <param name="filters"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<MediaContainer> SearchMovies(string title, string sort, Dictionary<string, string> filters, int start = 0, int count = 100) =>
            await this.Search(true, title, sort, SearchType.Movie, filters, start, count);

        /// <summary>
        ///
        /// </summary>
        /// <param name="title"></param>
        /// <param name="sort"></param>
        /// <param name="filters"></param>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<MediaContainer> SearchActors(string title, string sort, Dictionary<string, string> filters, int start = 0, int count = 100) =>
            await this.Search(true, title, sort, SearchType.Person, filters, start, count);
    }
}
