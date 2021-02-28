namespace Plex.Api.PlexModels.Media
{
    using System.Text.Json.Serialization;

    public class MediaSort    {
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("activeDirection")]
        public string ActiveDirection { get; set; }

        [JsonPropertyName("default")]
        public string Default { get; set; }

        [JsonPropertyName("defaultDirection")]
        public string DefaultDirection { get; set; }

        [JsonPropertyName("descKey")]
        public string DescKey { get; set; }

        [JsonPropertyName("firstCharacterKey")]
        public string FirstCharacterKey { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}