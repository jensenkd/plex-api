using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class Medium
    {
        public string VideoResolution { get; set; }
        public int Id { get; set; }
        public int Duration { get; set; }
        public int Bitrate { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float AspectRatio { get; set; }
        public int AudioChannels { get; set; }
        public string AudioCodec { get; set; }
        public string VideoCodec { get; set; }
        public string Container { get; set; }
        public string VideoFrameRate { get; set; }
        public string AudioProfile { get; set; }
        public string VideoProfile { get; set; }
        
        [JsonPropertyName("Part")]
        public Part[] Part { get; set; }
    }
}