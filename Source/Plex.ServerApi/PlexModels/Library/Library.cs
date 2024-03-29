namespace Plex.ServerApi.PlexModels.Library
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Library
    {
        [JsonPropertyName("allowSync")]
        public bool AllowSync { get; set; }

        [JsonPropertyName("art")]
        public string Art { get; set; }

        [JsonPropertyName("composite")]
        public string Composite { get; set; }

        [JsonPropertyName("filters")]
        public bool HasFilters { get; set; }

        [JsonPropertyName("refreshing")]
        public bool Refreshing { get; set; }

        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("agent")]
        public string Agent { get; set; }

        [JsonPropertyName("scanner")]
        public string Scanner { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [JsonPropertyName("updatedAt")]
        public long UpdatedAt { get; set; }

        [JsonPropertyName("createdAt")]
        public long CreatedAt { get; set; }

        [JsonPropertyName("scannedAt")]
        public long ScannedAt { get; set; }

        [JsonPropertyName("content")]
        public bool Content { get; set; }

        [JsonPropertyName("directory")]
        public bool Directory { get; set; }

        [JsonPropertyName("contentChangedAt")]
        public long ContentChangedAt { get; set; }

        [JsonPropertyName("hidden")]
        public int Hidden { get; set; }

        [JsonPropertyName("enableAutoPhotoTags")]
        public bool? EnableAutoPhotoTags { get; set; }

        [JsonPropertyName("Location")]
        public List<LibraryLocation> Location { get; set; }
    }
}
