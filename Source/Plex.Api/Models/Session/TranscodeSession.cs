namespace Plex.Api.Models.Session
{
    using System.Text.Json.Serialization;
    using Helpers;

    /// <summary>
    /// Transcode Session
    /// </summary>
    public class TranscodeSession
    {
        /// <summary>
        /// Key
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Is Throttled?
        /// </summary>
        [JsonPropertyName("throttled")]
        public bool Throttled { get; set; }

        /// <summary>
        /// Is Complete?
        /// </summary>
        [JsonPropertyName("complete")]
        public bool Complete { get; set; }

        /// <summary>
        /// Progress
        /// </summary>
        [JsonConverter(typeof(DoubleValueConverter))]
        [JsonPropertyName("progress")]
        public double Progress { get; set; }

        /// <summary>
        /// Speed
        /// </summary>
        [JsonConverter(typeof(DoubleValueConverter))]
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        /// <summary>
        /// Duration
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        /// <summary>
        /// Context
        /// </summary>
        [JsonPropertyName("context")]
        public string Context { get; set; }

        /// <summary>
        /// Source Video Codec
        /// </summary>
        [JsonPropertyName("sourceVideoCodec")]
        public string SourceVideoCodec { get; set; }

        /// <summary>
        /// Source Audio Codec
        /// </summary>
        [JsonPropertyName("sourceAudioCodec")]
        public string SourceAudioCodec { get; set; }

        /// <summary>
        /// Video Decision
        /// </summary>
        [JsonPropertyName("videoDecision")]
        public string VideoDecision { get; set; }

        /// <summary>
        /// Audio Decision
        /// </summary>
        [JsonPropertyName("audioDecision")]
        public string AudioDecision { get; set; }

        /// <summary>
        /// Protocol
        /// </summary>
        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// Container
        /// </summary>
        [JsonPropertyName("container")]
        public string Container { get; set; }

        /// <summary>
        /// Video Codec
        /// </summary>
        [JsonPropertyName("videoCodec")]
        public string VideoCodec { get; set; }

        /// <summary>
        /// Audio Codec
        /// </summary>
        [JsonPropertyName("audioCodec")]
        public string AudioCodec { get; set; }

        /// <summary>
        /// Audio Channels
        /// </summary>
        [JsonPropertyName("audioChannels")]
        public long AudioChannels { get; set; }

        /// <summary>
        /// Is Transcode Hardware Requested
        /// </summary>
        [JsonPropertyName("transcodeHwRequested")]
        public bool TranscodeHwRequested { get; set; }

        /// <summary>
        /// Is Transcode Hardware Full Pipeline
        /// </summary>
        [JsonPropertyName("transcodeHwFullPipeline")]
        public bool TranscodeHwFullPipeline { get; set; }

        /// <summary>
        /// Timestamp
        /// </summary>
        [JsonPropertyName("timeStamp")]
        public string TimeStamp { get; set; }

        /// <summary>
        /// Max Offset Available
        /// </summary>
        [JsonPropertyName("maxOffsetAvailable")]
        public string MaxOffsetAvailable { get; set; }

        /// <summary>
        /// Min Offset Available
        /// </summary>
        [JsonPropertyName("minOffsetAvailable")]
        public string MinOffsetAvailable { get; set; }
    }
}
