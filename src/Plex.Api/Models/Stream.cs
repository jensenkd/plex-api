using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class Stream
    {
        public int Id { get; set; }
        public int StreamType { get; set; }
        [JsonPropertyName("_default")]
        public bool Default { get; set; }
        public string Codec { get; set; }
        public int Index { get; set; }
        public int Bitrate { get; set; }
        public int BitDepth { get; set; }
        public string ChromaSubsampling { get; set; }
        public float FrameRate { get; set; }
        public bool HasScalingMatrix { get; set; }
        public int Height { get; set; }
        public string Level { get; set; }
        public string Profile { get; set; }
        public int RefFrames { get; set; }
        public string ScanType { get; set; }
        public int Width { get; set; }
        public int Channels { get; set; }
        public string Language { get; set; }
        public string LanguageCode { get; set; }
        public string AudioChannelLayout { get; set; }
        public int SamplingRate { get; set; }
        public bool Selected { get; set; }
    }
}