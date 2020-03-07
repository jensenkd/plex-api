using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class LibrariesWrapper
    {
        [JsonPropertyName("MediaContainer")]
        public LibrarySummary Libraries { get; set; }
    }
    
    public class LibrarySummary
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }
        
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
        
        [JsonPropertyName("Directory")]
        public List<Directory> Libraries { get; set; } = new List<Directory>();
    }
    
    public class LibraryWrapper
    {
        [JsonPropertyName("MediaContainer")]
        public Library Library { get; set; }
    }

    public class Library
    {
        [JsonPropertyName("size")]
        public long Size { get; set; }
        
        [JsonPropertyName("allowSync")]
        public bool AllowSync { get; set; }
        
        [JsonPropertyName("art")]
        public string Art { get; set; }
        
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }
        
        [JsonPropertyName("librarySectionID")]
        public int LibrarySectionId { get; set; }
        
        [JsonPropertyName("librarySectionTitle")]
        public string LibrarySectionTitle { get; set; }
        
        [JsonPropertyName("librarySectionUUID")]
        public string LibrarySectionUuid { get; set; }
        
        [JsonPropertyName("mediaTagPrefix")]
        public string MediaTagPrefix { get; set; }
        
        [JsonPropertyName("mediaTagVersion")]
        public int MediaTagVersion { get; set; }
        
        [JsonPropertyName("nocache")]
        public bool Nocache { get; set; }
        
        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }
        
        [JsonPropertyName("title1")]
        public string Title1 { get; set; }

        [JsonPropertyName("title2")]
        public string Title2 { get; set; }
        
        [JsonPropertyName("viewGroup")]
        public string ViewGroup { get; set; }
        
        [JsonPropertyName("viewMode")]
        public int ViewMode { get; set; }
        
        [JsonPropertyName("Metadata")]
        public Metadata[] LibraryItems { get; set; }
    }
}