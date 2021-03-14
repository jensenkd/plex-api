namespace Plex.ServerApi.PlexModels.Media
{
    using System.Text.Json.Serialization;

    public class Stream
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("streamType")] public int StreamType { get; set; }

        [JsonPropertyName("default")] public bool Default { get; set; }

        [JsonPropertyName("codec")] public string Codec { get; set; }

        [JsonPropertyName("index")] public int Index { get; set; }

        [JsonPropertyName("bitrate")] public int Bitrate { get; set; }

        [JsonPropertyName("language")] public string Language { get; set; }

        [JsonPropertyName("languageCode")] public string LanguageCode { get; set; }

        [JsonPropertyName("bitDepth")] public int BitDepth { get; set; }

        [JsonPropertyName("chromaLocation")] public string ChromaLocation { get; set; }

        [JsonPropertyName("chromaSubsampling")]
        public string ChromaSubsampling { get; set; }

        [JsonPropertyName("codedHeight")] public int CodedHeight { get; set; }

        [JsonPropertyName("codedWidth")] public int CodedWidth { get; set; }

        [JsonPropertyName("colorPrimaries")] public string ColorPrimaries { get; set; }

        [JsonPropertyName("colorRange")] public string ColorRange { get; set; }

        [JsonPropertyName("colorSpace")] public string ColorSpace { get; set; }

        [JsonPropertyName("colorTrc")] public string ColorTrc { get; set; }

        [JsonPropertyName("frameRate")] public double FrameRate { get; set; }

        [JsonPropertyName("hasScalingMatrix")] public bool HasScalingMatrix { get; set; }

        [JsonPropertyName("height")] public int Height { get; set; }

        [JsonPropertyName("level")] public int Level { get; set; }

        [JsonPropertyName("profile")] public string Profile { get; set; }

        [JsonPropertyName("refFrames")] public int RefFrames { get; set; }

        [JsonPropertyName("scanType")] public string ScanType { get; set; }

        [JsonPropertyName("separateFields")] public string SeparateFields { get; set; }

        [JsonPropertyName("title")] public string Title { get; set; }

        [JsonPropertyName("width")] public int Width { get; set; }

        [JsonPropertyName("displayTitle")] public string DisplayTitle { get; set; }

        [JsonPropertyName("extendedDisplayTitle")]
        public string ExtendedDisplayTitle { get; set; }

        [JsonPropertyName("selected")] public bool? Selected { get; set; }

        [JsonPropertyName("channels")] public int? Channels { get; set; }

        [JsonPropertyName("audioChannelLayout")]
        public string AudioChannelLayout { get; set; }

        [JsonPropertyName("samplingRate")] public int? SamplingRate { get; set; }

        [JsonPropertyName("key")] public string Key { get; set; }
    }
}
