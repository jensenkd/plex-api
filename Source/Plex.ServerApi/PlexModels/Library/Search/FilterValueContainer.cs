namespace Plex.ServerApi.PlexModels.Library.Search
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class FilterValueContainer
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("allowSync")]
        public bool AllowSync { get; set; }

        [JsonPropertyName("art")]
        public string Art { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

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

        [JsonPropertyName("Directory")]
        public List<FilterValue> FilterValues { get; set; }
    }
}
