namespace Plex.ServerApi.PlexModels.Media
{
    using System.Text.Json.Serialization;

    public class MediaFilter
    {
        [JsonPropertyName("filter")]
        public string Filter { get; set; }

        [JsonPropertyName("filterType")]
        public string FilterType { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("advanced")]
        public bool? Advanced { get; set; }
    }
}
