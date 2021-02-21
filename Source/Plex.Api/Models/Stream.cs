namespace Plex.Api.Models
{
    using System.Text.Json.Serialization;
    using Plex.Api.Helpers;

    /// <summary>
    /// Attributes:
    ///     part (:class:`~Plex.Api.Models.Part`): Media part this stream belongs to.
    ///     codec (str): Codec of this stream (ex: srt, ac3, mpeg4).
    ///     codecID (str): Codec ID (ex: XVID).
    ///     id (int): Unique stream ID on this server.
    ///     index (int): Unknown
    ///     language (str): Stream language (ex: English, ไทย).
    ///     languageCode (str): Ascii code for language (ex: eng, tha).
    ///     selected (bool): True if this stream is selected.
    ///     streamType (int): Stream type (1=:class:`~plexapi.media.VideoStream`,
    ///     2=:class:`~plexapi.media.AudioStream`, 3=:class:`~plexapi.media.SubtitleStream`).
    ///     type (int): Alias for streamType.
    /// </summary>
    public class Stream
    {
        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int StreamType { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("_default")]
        public bool Default { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Codec { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long Index { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long Bitrate { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long BitDepth { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ChromaLocation { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ChromaSubsampling { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ColorPrimaries { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ColorRange { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ColorSpace { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ColorTrc { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(DoubleValueConverter))]
        public double FrameRate { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(BooleanValueConverter))]
        public bool HasScalingMatrix { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long Height { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Level { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Profile { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long RefFrames { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ScanType { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string StreamIdentifier { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Width { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string DisplayTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(BooleanValueConverter))]
        public bool Selected { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long Channels { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long SamplingRate { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string AudioChannelLayout { get; set; }


        // Tv Episode
        /// <summary>
        ///
        /// </summary>
        public bool Anamorphic { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string PixelAspectRatio { get; set; }
    }
}
