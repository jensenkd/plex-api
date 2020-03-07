using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class Metadata
    {    
        [JsonPropertyName("ratingKey")]
        public string RatingKey { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }
        
        [JsonPropertyName("studio")]
        public string Studio { get; set; }
        
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("contentRating")]
        public string ContentRating { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }
        
        [JsonPropertyName("index")]
        public int Index { get; set; }
        
        [JsonPropertyName("rating")]
        public float Rating { get; set; }
        
        [JsonPropertyName("viewCount")]
        public int ViewCount { get; set; }
        
        [JsonPropertyName("lastViewedAt")]
        public int LastViewedAt { get; set; }
        
        [JsonPropertyName("year")]
        public int Year { get; set; }
        
        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }
        
        [JsonPropertyName("art")]
        public string Art { get; set; }
        
        [JsonPropertyName("banner")]
        public string Banner { get; set; }
        
        [JsonPropertyName("theme")]
        public string Theme { get; set; }
        
        [JsonPropertyName("leafCount")]
        public int LeafCount { get; set; }
        
        [JsonPropertyName("viewedLeafCount")]
        public int ViewedLeafCount { get; set; }
        
        [JsonPropertyName("childCount")]
        public int ChildCount { get; set; }
        
        [JsonPropertyName("primaryExtraKey")]
        public string PrimaryExtraKey { get; set; }
        
        [JsonPropertyName("parentRatingKey")]
        public int ParentRatingKey { get; set; }
        
        [JsonPropertyName("grandparentRatingKey")]
        public int GrandparentRatingKey { get; set; }

        [JsonPropertyName("guid")]
        public string Guid { get; set; }
        
        [JsonPropertyName("librarySectionId")]
        public int LibrarySectionId { get; set; }
        
        [JsonPropertyName("librarySectionKey")]
        public string LibrarySectionKey { get; set; }
        
        [JsonPropertyName("grandparentKey")]
        public string GrandparentKey { get; set; }
        
        [JsonPropertyName("parentKey")]
        public string ParentKey { get; set; }
        
        [JsonPropertyName("grandparentTitle")]
        public string GrandparentTitle { get; set; }
        
        [JsonPropertyName("parentTitle")]
        public string ParentTitle { get; set; }
        
        [JsonPropertyName("parentIndex")]
        public int ParentIndex { get; set; }
        
        [JsonPropertyName("parentThumb")]
        public string ParentThumb { get; set; }
 
        [JsonPropertyName("grandparentThumb")]
        public string GrandparentThumb { get; set; }
        
        [JsonPropertyName("grandparentArt")]
        public string GrandparentArt { get; set; }
        
        [JsonPropertyName("grandparentTheme")]
        public string GrandparentTheme { get; set; }
        
        [JsonPropertyName("chapterSource")]
        public string ChapterSource { get; set; }
        
        [JsonPropertyName("Media")]
        public Medium[] MediaItems { get; set; }
        
        [JsonPropertyName("Genre")]
        public Genre[] Genres { get; set; }
        
        [JsonPropertyName("Director")]
        public Director[] Directors { get; set; }
        
        [JsonPropertyName("Writer")]
        public Writer[] Writers { get; set; }
        
        [JsonPropertyName("Country")]
        public Country[] Countries { get; set; }

    }
}