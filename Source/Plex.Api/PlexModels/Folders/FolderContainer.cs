namespace Plex.Api.PlexModels.Folders
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class FolderContainer
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("allowSync")]
        public bool AllowSync { get; set; }

        [JsonPropertyName("art")]
        public string Art { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("librarySectionID")]
        public int LibrarySectionID { get; set; }

        [JsonPropertyName("librarySectionTitle")]
        public string LibrarySectionTitle { get; set; }

        [JsonPropertyName("librarySectionUUID")]
        public string LibrarySectionUUID { get; set; }

        [JsonPropertyName("mediaTagPrefix")]
        public string MediaTagPrefix { get; set; }

        [JsonPropertyName("mediaTagVersion")]
        public int MediaTagVersion { get; set; }

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
        public List<Folder> Folders { get; set; }
    }
}
