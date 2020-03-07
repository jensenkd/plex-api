
using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class Metadata
    {
        public string RatingKey { get; set; }
        public string Key { get; set; }
        public string Studio { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string ContentRating { get; set; }
        public string Summary { get; set; }
        public int Index { get; set; }
        public float Rating { get; set; }
        public int ViewCount { get; set; }
        public int LastViewedAt { get; set; }
        public int Year { get; set; }
        public string Thumb { get; set; }
        public string Art { get; set; }
        public string Banner { get; set; }
        public string Theme { get; set; }
        public int LeafCount { get; set; }
        public int ViewedLeafCount { get; set; }
        public int ChildCount { get; set; }
        public string PrimaryExtraKey { get; set; }
        public int ParentRatingKey { get; set; }
        public int GrandparentRatingKey { get; set; }
        public string Guid { get; set; }
        public int LibrarySectionId { get; set; }
        public string LibrarySectionKey { get; set; }
        public string GrandparentKey { get; set; }
        public string ParentKey { get; set; }
        public string GrandparentTitle { get; set; }
        public string ParentTitle { get; set; }
        public int ParentIndex { get; set; }
        public string ParentThumb { get; set; }
        public string GrandparentThumb { get; set; }
        public string GrandparentArt { get; set; }
        public string GrandparentTheme { get; set; }
        public string ChapterSource { get; set; }
        
        [JsonPropertyName("Media")]
        public Medium[] Media { get; set; }
        
        [JsonPropertyName("Genre")]
        public Genre[] Genre { get; set; }
    }
}