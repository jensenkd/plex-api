namespace Plex.Api.PlexModels.Library.Search
{
    using System.Text.Json.Serialization;

    public class Filter    {
        [JsonPropertyName("filter")]
        public string FilterName { get; set; }

        [JsonPropertyName("filterType")]
        public string FilterType { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
