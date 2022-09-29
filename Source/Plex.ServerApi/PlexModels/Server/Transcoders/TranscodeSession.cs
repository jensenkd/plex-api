namespace Plex.ServerApi.PlexModels.Server.Transcoders
{
    using System.Text.Json.Serialization;

    public class TranscodeSession
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("throttled")]
        public bool Throttled { get; set; }

        [JsonPropertyName("complete")]
        public bool Complete { get; set; }

        [JsonPropertyName("progress")]
        public double Progress { get; set; }

        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("speed")]
        public float Speed { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("remaining")]
        public int Remaining { get; set; }

        [JsonPropertyName("context")]
        public string Context { get; set; }

        [JsonPropertyName("sourceVideoCodec")]
        public string SourceVideoCodec { get; set; }

        [JsonPropertyName("sourceAudioCodec")]
        public string SourceAudioCodec { get; set; }

        [JsonPropertyName("videoDecision")]
        public string VideoDecision { get; set; }

        [JsonPropertyName("audioDecision")]
        public string AudioDecision { get; set; }

        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        [JsonPropertyName("container")]
        public string Container { get; set; }

        [JsonPropertyName("videoCodec")]
        public string VideoCodec { get; set; }

        [JsonPropertyName("audioCodec")]
        public string AudioCodec { get; set; }

        [JsonPropertyName("audioChannels")]
        public int AudioChannels { get; set; }

        [JsonPropertyName("transcodeHwRequested")]
        public bool TranscodeHwRequested { get; set; }

        [JsonPropertyName("transcodeHwFullPipeline")]
        public bool TranscodeHwFullPipeline { get; set; }

        [JsonPropertyName("timeStamp")]
        public double TimeStamp { get; set; }

        [JsonPropertyName("maxOffsetAvailable")]
        public double MaxOffsetAvailable { get; set; }

        [JsonPropertyName("minOffsetAvailable")]
        public double MinOffsetAvailable { get; set; }
    }
}
