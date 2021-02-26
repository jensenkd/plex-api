using System.Collections.Generic;
using System.Text.Json.Serialization;
using Plex.Api.Helpers;

namespace Plex.Api.Models
{
    /// <summary>
    /// Metadata Object
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Metadata"/> class.
        /// </summary>
        /// <param name="titleSort">Title Sort</param>
        /// <param name="grandparentRatingKey">Grandparent Rating Key</param>
        public Metadata(string titleSort, string grandparentRatingKey)
        {
            this.TitleSort = titleSort;
            this.GrandparentRatingKey = grandparentRatingKey;
        }

        //Movie
        /// <summary>
        /// Rating Key
        /// </summary>
        public string RatingKey { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Library Section Title
        /// </summary>
        public string LibrarySectionTitle { get; set; }

        /// <summary>
        /// Library Section Id
        /// </summary>
        [JsonPropertyName("librarySectionID")]
        public int LibrarySectionId { get; set; }

        /// <summary>
        /// Library Section Key
        /// </summary>
        public string LibrarySectionKey { get; set; }

        /// <summary>
        /// Studio
        /// </summary>
        public string Studio { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Content Rating
        /// </summary>
        public string ContentRating { get; set; }

        /// <summary>
        /// Summary
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Rating
        /// </summary>
        public float Rating { get; set; }

        /// <summary>
        /// View Count
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// Last Viewed At
        /// </summary>
        public int LastViewedAt { get; set; }

        /// <summary>
        /// Year
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Tag Line
        /// </summary>
        public string TagLine { get; set; }

        /// <summary>
        /// Thumb
        /// </summary>
        public string Thumb { get; set; }

        /// <summary>
        /// Art
        /// </summary>
        public string Art { get; set; }

        /// <summary>
        /// Duration
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Originally Available At
        /// </summary>
        public string OriginallyAvailableAt { get; set; }

        /// <summary>
        /// Added At
        /// </summary>
        public int AddedAt { get; set; }

        /// <summary>
        /// Updated At
        /// </summary>
        public int UpdatedAt { get; set; }

        /// <summary>
        /// Chapter Source
        /// </summary>
        public string ChapterSource { get; set; }

        /// <summary>
        /// Rating Image
        /// </summary>
        public string RatingImage { get; set; }

        /// <summary>
        /// External Provider
        /// </summary>
        public string ExternalProvider { get; set; }

        /// <summary>
        /// External Provider Id
        /// </summary>
        public string ExternalProviderId { get; set; }

        /// <summary>
        /// Guid
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// Plex Guid
        /// </summary>
        [JsonPropertyName("Guid")]
        public PlexGuid[] PlexGuid { get; set; }

        //[JsonPropertyName("guid")]
        // public string ExternalProviderInfo
        // {
        //     set
        //     {
        //         var match = Regex.Match(value, @"\.(?<provider>[a-z]+)://(?<id>[^\?]+)");
        //         Guid = value;
        //         ExternalProvider = match.Groups["provider"].Value;
        //         ExternalProviderId = match.Groups["id"].Value;
        //     }
        // }

        /// <summary>
        /// Media Items
        /// </summary>
        [JsonPropertyName("Media")]
        public List<Medium> Media { get; set; }

        /// <summary>
        /// Genre Items
        /// </summary>
        [JsonPropertyName("Genre")]
        public Genre[] Genres { get; set; }

        /// <summary>
        /// Director Items
        /// </summary>
        [JsonPropertyName("Director")]
        public Director[] Directors { get; set; }

        /// <summary>
        /// Writer Items
        /// </summary>
        [JsonPropertyName("Writer")]
        public Writer[] Writers { get; set; }

        /// <summary>
        /// Producer Items
        /// </summary>
        [JsonPropertyName("Producer")]
        public List<Producer> Producer { get; set; }

        /// <summary>
        /// Country Items
        /// </summary>
        [JsonPropertyName("Country")]
        public Country[] Countries { get; set; }

        /// <summary>
        /// Role Items
        /// </summary>
        [JsonPropertyName("Role")]
        public List<MediaRole> Roles { get; set; }

        /// <summary>
        /// Similar Items
        /// </summary>
        [JsonPropertyName("Similar")]
        public List<Similar> Similar { get; set; }

        /// <summary>
        /// Field Items
        /// </summary>
        [JsonPropertyName("Field")]
        public List<Field> Field { get; set; }


        //Library Sections
        /// <summary>
        /// Title Sort
        /// </summary>
        public string TitleSort { get; set; }

        /// <summary>
        /// Index
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Banner
        /// </summary>
        public string Banner { get; set; }

        /// <summary>
        /// Leaf Count
        /// </summary>
        public int LeafCount { get; set; }

        /// <summary>
        /// Viewed Leaf Count
        /// </summary>
        public int ViewedLeafCount { get; set; }

        /// <summary>
        /// Child Count
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int ChildCount { get; set; }

        /// <summary>
        /// Theme
        /// </summary>
        public string Theme { get; set; }


        //TV Show Seasons
        /// <summary>
        /// Parent Rating Key
        /// </summary>
        public string ParentRatingKey { get; set; }

        /// <summary>
        /// Parent Key
        /// </summary>
        public string ParentKey { get; set; }

        /// <summary>
        /// Parent Title
        /// </summary>
        public string ParentTitle { get; set; }

        /// <summary>
        /// Parent Index
        /// </summary>
        public int ParentIndex { get; set; }

        /// <summary>
        /// Parent Thumbnail
        /// </summary>
        public string ParentThumb { get; set; }

        /// <summary>
        /// Parent Theme
        /// </summary>
        public string ParentTheme { get; set; }


        //TV Show Episode
        /// <summary>
        /// Grandparent Rating Key
        /// </summary>
        public string GrandparentRatingKey { get; set; }

        /// <summary>
        /// Grandparent Key
        /// </summary>
        public string GrandparentKey { get; set; }

        /// <summary>
        /// Grandparent Title
        /// </summary>
        public string GrandparentTitle { get; set; }

        /// <summary>
        /// Grandparent Thumb
        /// </summary>
        public string GrandparentThumb { get; set; }

        /// <summary>
        /// Grandparent Art
        /// </summary>
        public string GrandparentArt { get; set; }

        /// <summary>
        /// Grandparent Theme
        /// </summary>
        public string GrandparentTheme { get; set; }


        //Movie Section
        /// <summary>
        /// Primary Extra Key
        /// </summary>
        public string PrimaryExtraKey { get; set; }

        /// <summary>
        /// Collection Items
        /// </summary>
        [JsonPropertyName("Collection")]
        public List<Collection> Collection { get; set; }

        /// <summary>
        /// Original Title
        /// </summary>
        public string OriginalTitle { get; set; }

        /// <summary>
        /// View Offset
        /// </summary>
        public int? ViewOffset { get; set; }

        /// <summary>
        /// Plex Rating
        /// </summary>
        public float PlexRating { get; set; }
    }
}
