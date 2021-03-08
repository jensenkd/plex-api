namespace Plex.Api.ApiModels.Libraries
{
    using System;
    using System.Collections.Generic;
    using Clients.Interfaces;
    using PlexModels.Library;
    using ResourceModels;

    /// <summary>
    /// Movie Library
    /// </summary>
    public class MovieLibrary : LibraryBase
    {

        public MovieLibrary(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, Server server)
            : base(plexServerClient, plexLibraryClient, server)
        { }

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
            await this.PlexServerClient.AddCollectionToLibraryItemAsync(this.Server.AccessToken, this.Server.Uri.ToString(), this.Key, ratingKey,
                collectionName);

        /// <summary>
        /// Untag a library item with a Collection Name
        /// </summary>
       /// <param name="ratingKey">Item Rating Key.</param>
        /// <param name="collectionName">Collection name to remove from item.</param>
        public async void RemoveCollectionFromItem(string ratingKey, string collectionName) =>
            await this.PlexServerClient.DeleteCollectionFromLibraryItemAsync(this.Server.AccessToken, this.Server.Uri.ToString(), this.Key, ratingKey,
                collectionName);

        /// <summary>
        /// Update Collection
        /// </summary>
        /// <param name="collectionModel">Collection Model</param>
        public async void UpdateCollection(CollectionModel collectionModel) =>
            await this.PlexServerClient.UpdateCollectionAsync(this.Server.AccessToken, this.Server.Uri.ToString(), this.Key, collectionModel);


    }
}
