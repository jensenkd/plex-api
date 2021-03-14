namespace Plex.ServerApi.PlexModels.Media
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class MediaType
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("Filter")]
        public List<MediaFilter> Filter { get; set; }

        [JsonPropertyName("Sort")]
        public List<MediaSort> Sort { get; set; }

        [JsonPropertyName("Field")]
        public List<MediaField> Field { get; set; }
    }
}
