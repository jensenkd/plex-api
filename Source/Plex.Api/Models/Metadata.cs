using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Plex.Api.Helpers;

namespace Plex.Api.Models
{
    /// <summary>
    ///
    /// </summary>
    public class Metadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Metadata"/> class.
        /// </summary>
        /// <param name="titleSort"></param>
        /// <param name="grandparentRatingKey"></param>
        public Metadata(string titleSort, string grandparentRatingKey)
        {
            this.TitleSort = titleSort;
            this.GrandparentRatingKey = grandparentRatingKey;
        }

        //Movie
        /// <summary>
        ///
        /// </summary>
        public string RatingKey { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string LibrarySectionTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("librarySectionID")]
        public int LibrarySectionId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string LibrarySectionKey { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Studio { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ContentRating { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        ///
        /// </summary>
        public float Rating { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int LastViewedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string TagLine { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Thumb { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Art { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string OriginallyAvailableAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int AddedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int UpdatedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ChapterSource { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string RatingImage { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ExternalProvider { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ExternalProviderId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        ///
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
        ///
        /// </summary>
        [JsonPropertyName("Media")]
        public List<Medium> Media { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Genre")]
        public Genre[] Genres { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Director")]
        public Director[] Directors { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Writer")]
        public Writer[] Writers { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Producer")]
        public List<Producer> Producer { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Country")]
        public Country[] Countries { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Role")]
        public List<MediaRole> Roles { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Similar")]
        public List<Similar> Similar { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Field")]
        public List<Field> Field { get; set; }


        //Library Sections
        /// <summary>
        ///
        /// </summary>
        public string TitleSort { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Banner { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int LeafCount { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ViewedLeafCount { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int ChildCount { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Theme { get; set; }


        //TV Show Seasons
        /// <summary>
        ///
        /// </summary>
        public string ParentRatingKey { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string ParentKey { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string ParentTitle { get; set; }
        /// <summary>
        ///
        /// </summary>
        public int ParentIndex { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string ParentThumb { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string ParentTheme { get; set; }


        //TV Show Episode
        /// <summary>
        ///
        /// </summary>
        public string GrandparentRatingKey { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string GrandparentKey { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string GrandparentTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string GrandparentThumb { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string GrandparentArt { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string GrandparentTheme { get; set; }


        //Movie Section
        /// <summary>
        ///
        /// </summary>
        public string PrimaryExtraKey { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Collection")]
        public List<Collection> Collection { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string OriginalTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int? ViewOffset { get; set; }

        /// <summary>
        ///
        /// </summary>
        public float PlexRating { get; set; }
    }
}
