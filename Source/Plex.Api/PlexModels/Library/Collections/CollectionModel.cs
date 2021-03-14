namespace Plex.Api.PlexModels.Library.Collections
{
    /// <summary>
    /// Collection Model
    /// </summary>
    public class CollectionModel
    {
        /// <summary>
        /// Plex Rating Key
        /// </summary>
        public string RatingKey { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Guid
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Title Sort Field
        /// </summary>
        public string TitleSort { get; set; }

        /// <summary>
        /// Content Rating
        /// </summary>
        public string ContentRating { get; set; }

        /// <summary>
        /// Sub Type
        /// </summary>
        public string Subtype { get; set; }

        /// <summary>
        /// Collection Mode
        /// </summary>
        public string CollectionMode { get; set; }

        /// <summary>
        /// Collection Sort
        /// </summary>
        public string CollectionSort { get; set; }

        /// <summary>
        /// Summary
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Thumbnail
        /// </summary>
        public string Thumb { get; set; }

        /// <summary>
        /// Added At Date
        /// </summary>
        public long AddedAt { get; set; }

        /// <summary>
        /// Updated At Date
        /// </summary>
        public long UpdatedAt { get; set; }

        /// <summary>
        /// Child Count
        /// </summary>
        public int ChildCount { get; set; }

        /// <summary>
        /// Max Year
        /// </summary>
        public int MaxYear { get; set; }

        /// <summary>
        /// Min Year
        /// </summary>
        public int MinYear { get; set; }
    }
}
