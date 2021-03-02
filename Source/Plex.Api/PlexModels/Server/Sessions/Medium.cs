namespace Plex.Api.PlexModels.Server.Sessions
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Medium    
    {
        [JsonPropertyName("aspectRatio")]
        public string AspectRatio { get; set; } 

        [JsonPropertyName("audioChannels")]
        public string AudioChannels { get; set; } 

        [JsonPropertyName("audioCodec")]
        public string AudioCodec { get; set; } 

        [JsonPropertyName("bitrate")]
        public string Bitrate { get; set; } 

        [JsonPropertyName("container")]
        public string Container { get; set; } 

        [JsonPropertyName("duration")]
        public string Duration { get; set; } 

        [JsonPropertyName("height")]
        public string Height { get; set; } 

        [JsonPropertyName("id")]
        public string Id { get; set; } 

        [JsonPropertyName("videoCodec")]
        public string VideoCodec { get; set; } 

        [JsonPropertyName("videoFrameRate")]
        public string VideoFrameRate { get; set; } 

        [JsonPropertyName("videoProfile")]
        public string VideoProfile { get; set; } 

        [JsonPropertyName("videoResolution")]
        public string VideoResolution { get; set; } 

        [JsonPropertyName("width")]
        public string Width { get; set; } 

        [JsonPropertyName("selected")]
        public bool Selected { get; set; } 

        [JsonPropertyName("Part")]
        public List<Part> Part { get; set; } 

        [JsonPropertyName("audioProfile")]
        public string AudioProfile { get; set; } 

        [JsonPropertyName("optimizedForStreaming")]
        public string OptimizedForStreaming { get; set; } 

        [JsonPropertyName("protocol")]
        public string Protocol { get; set; } 
    }
}