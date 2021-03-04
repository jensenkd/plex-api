namespace Plex.Api.PlexModels.Media
{
    using System.Text.Json.Serialization;

    public class MediaField
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("subType")]
        public string SubType { get; set; }
    }
}
