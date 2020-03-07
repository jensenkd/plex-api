using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class MediaContainer
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }
        
        [JsonPropertyName("totalSize")]
        public int TotalSize { get; set; }
        
        [JsonPropertyName("allowSync")]
        public bool AllowSync { get; set; }
        
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }
        
        [JsonPropertyName("mediaTagPrefix")]
        public string MediaTagPrefix { get; set; }
        
        [JsonPropertyName("mediaTagVersion")]
        public int MediaTagVersion { get; set; }
        
        [JsonPropertyName("title1")]
        public string Title1 { get; set; }
        
        [JsonPropertyName("art")]
        public string Art { get; set; }
        
        [JsonPropertyName("librarySectionId")]
        public int LibrarySectionId { get; set; }
        
        [JsonPropertyName("librarySectionTitle")]
        public string LibrarySectionTitle { get; set; }
        
        [JsonPropertyName("librarySectionUuid")]
        public string LibrarySectionUuid { get; set; }
        
        [JsonPropertyName("nocache")]
        public bool Nocache { get; set; }
        
        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }
        
        [JsonPropertyName("title2")]
        public string Title2 { get; set; }
        
        [JsonPropertyName("viewGroup")]
        public string ViewGroup { get; set; }
        
        [JsonPropertyName("viewMode")]
        public int ViewMode { get; set; }
        
        [JsonPropertyName("Metadata")]
        public Metadata[] Metadata { get; set; }
        
        [JsonPropertyName("Directory")]
        public List<Directory> Directory { get; set; }
    }
}