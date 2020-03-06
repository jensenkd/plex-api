using Newtonsoft.Json;

namespace Kineticmedia.Plex.Api.Models
{
    public class Metadata
    {
        [JsonProperty("ratingKey")]
        public int RatingKey { get; set; }
        
        [JsonProperty("key")]
        public string Key { get; set; }
        
        [JsonProperty("studio")]
        public string studio { get; set; }

        [JsonProperty("type")]
        public string type { get; set; }
    
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("contentRating")]
        public string ContentRating { get; set; }
        
        [JsonProperty("summary")]
        public string Summary { get; set; }
        
        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("rating")]
        public float Rating { get; set; }
        //public int viewCount { get; set; }
        //public int lastViewedAt { get; set; }
        [JsonProperty("year")]
        public int Year { get; set; }
       
        public string thumb { get; set; }
        
        public string art { get; set; }
        
        public string banner { get; set; }
        
        public string theme { get; set; }
        
        //public string duration { get; set; }
        //public string originallyAvailableAt { get; set; }
        
        public int leafCount { get; set; }
        
        public int viewedLeafCount { get; set; }
        
        public int childCount { get; set; }
        
        //public long addedAt { get; set; }
        //public int updatedAt { get; set; }
        
        public Genre[] Genre { get; set; }
        //public Role[] Role { get; set; }
        
        public string primaryExtraKey { get; set; }
        
        public int parentRatingKey { get; set; }
        
        public int grandparentRatingKey { get; set; }
        public string guid { get; set; }
        
        public int librarySectionID { get; set; }
        
        public string librarySectionKey { get; set; }
        
        public string grandparentKey { get; set; }
        
        public string parentKey { get; set; }
        
        public string grandparentTitle { get; set; }
        
        public string parentTitle { get; set; }
        
        public int parentIndex { get; set; }
        
        public string parentThumb { get; set; }
        
        public string grandparentThumb { get; set; }
        
        public string grandparentArt { get; set; }
        
        public string grandparentTheme { get; set; }
        
        public string chapterSource { get; set; }
        public Medium[] Media { get; set; }
        //    public Director[] Director { get; set; }
        //    public Writer[] Writer { get; set; }
    }
}