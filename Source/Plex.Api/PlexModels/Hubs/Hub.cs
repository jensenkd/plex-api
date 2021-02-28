namespace Plex.Api.PlexModels.Hubs
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Media;

    public class Hub
    {
        [JsonPropertyName("hubKey")]
        public string HubKey { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("hubIdentifier")]
        public string HubIdentifier { get; set; }

        [JsonPropertyName("context")]
        public string Context { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("more")]
        public bool More { get; set; }

        [JsonPropertyName("style")]
        public string Style { get; set; }

        [JsonPropertyName("Metadata")]
        public List<Metadata> Metadata { get; set; }

        [JsonPropertyName("random")]
        public bool? Random { get; set; }
    }
}
