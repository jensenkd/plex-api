namespace Plex.ServerApi.PlexModels.Server.Sessions
{
    using System.Text.Json.Serialization;

    public class Stream
    {
        [JsonPropertyName("bitDepth")]
        public int BitDepth { get; set; }

        [JsonPropertyName("bitrate")]
        public long Bitrate { get; set; }

        [JsonPropertyName("chromaLocation")]
        public string ChromaLocation { get; set; }

        [JsonPropertyName("chromaSubsampling")]
        public string ChromaSubsampling { get; set; }

        [JsonPropertyName("codec")]
        public string Codec { get; set; }

        [JsonPropertyName("default")]
        public bool Default { get; set; }

        [JsonPropertyName("displayTitle")]
        public string DisplayTitle { get; set; }

        [JsonPropertyName("extendedDisplayTitle")]
        public string ExtendedDisplayTitle { get; set; }

        [JsonPropertyName("frameRate")]
        public float FrameRate { get; set; }

        [JsonPropertyName("hasScalingMatrix")]
        public string HasScalingMatrix { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("languageCode")]
        public string LanguageCode { get; set; }

        [JsonPropertyName("level")]
        public string Level { get; set; }

        [JsonPropertyName("profile")]
        public string Profile { get; set; }

        [JsonPropertyName("refFrames")]
        public string RefFrames { get; set; }

        [JsonPropertyName("scanType")]
        public string ScanType { get; set; }

        [JsonPropertyName("streamType")]
        public int StreamType { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("audioChannelLayout")]
        public string AudioChannelLayout { get; set; }

        [JsonPropertyName("channels")]
        public int Channels { get; set; }

        [JsonPropertyName("samplingRate")]
        public long SamplingRate { get; set; }

        [JsonPropertyName("selected")]
        public bool Selected { get; set; }

        [JsonPropertyName("decision")]
        public string Decision { get; set; }

        [JsonPropertyName("bitrateMode")]
        public string BitrateMode { get; set; }
    }
}
