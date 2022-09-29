namespace Plex.ServerApi.PlexModels.Server.Sessions
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Part
    {
        [JsonPropertyName("container")]
        public string Container { get; set; }

        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        [JsonPropertyName("file")]
        public string File { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("videoProfile")]
        public string VideoProfile { get; set; }

        [JsonPropertyName("decision")]
        public string Decision { get; set; }

        [JsonPropertyName("selected")]
        public bool Selected { get; set; }

        [JsonPropertyName("Stream")]
        public List<Stream> Stream { get; set; }

        [JsonPropertyName("audioProfile")]
        public string AudioProfile { get; set; }

        [JsonPropertyName("bitrate")]
        public int Bitrate { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("optimizedForStreaming")]
        public bool OptimizedForStreaming { get; set; }

        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
}
