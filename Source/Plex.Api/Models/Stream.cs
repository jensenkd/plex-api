namespace Plex.Api.Models
{
    using System.Text.Json.Serialization;
    using Helpers;

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
        /// Stream Id
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long Id { get; set; }

        /// <summary>
        /// Stream Type
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int StreamType { get; set; }

        /// <summary>
        /// Is Default?
        /// </summary>
        [JsonPropertyName("_default")]
        public bool Default { get; set; }

        /// <summary>
        /// Video Codec
        /// </summary>
        public string Codec { get; set; }

        /// <summary>
        /// Index
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long Index { get; set; }

        /// <summary>
        /// Bitrate
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long Bitrate { get; set; }

        /// <summary>
        /// Bit Depth
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long BitDepth { get; set; }

        /// <summary>
        /// Chroma Location
        /// </summary>
        public string ChromaLocation { get; set; }

        /// <summary>
        /// Chroma SubSampling
        /// </summary>
        public string ChromaSubsampling { get; set; }

        /// <summary>
        /// Color Primaries
        /// </summary>
        public string ColorPrimaries { get; set; }

        /// <summary>
        /// Color Range
        /// </summary>
        public string ColorRange { get; set; }

        /// <summary>
        /// Color Space
        /// </summary>
        public string ColorSpace { get; set; }

        /// <summary>
        /// Color Trc
        /// </summary>
        public string ColorTrc { get; set; }

        /// <summary>
        /// Frame Rate
        /// </summary>
        [JsonConverter(typeof(DoubleValueConverter))]
        public double FrameRate { get; set; }

        /// <summary>
        /// Has Scaling Matrix?
        /// </summary>
        [JsonConverter(typeof(BooleanValueConverter))]
        public bool HasScalingMatrix { get; set; }

        /// <summary>
        /// Height
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long Height { get; set; }

        /// <summary>
        /// Level
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Level { get; set; }

        /// <summary>
        /// Profile
        /// </summary>
        public string Profile { get; set; }

        /// <summary>
        /// Ref Frames
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long RefFrames { get; set; }

        /// <summary>
        /// Scan Type
        /// </summary>
        public string ScanType { get; set; }

        /// <summary>
        /// Stream Identifier
        /// </summary>
        public string StreamIdentifier { get; set; }

        /// <summary>
        /// Width
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Width { get; set; }

        /// <summary>
        /// Display Title
        /// </summary>
        public string DisplayTitle { get; set; }

        /// <summary>
        /// Selected
        /// </summary>
        [JsonConverter(typeof(BooleanValueConverter))]
        public bool Selected { get; set; }

        /// <summary>
        /// Channels
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long Channels { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Language Code
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// Sampling Rate
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long SamplingRate { get; set; }

        /// <summary>
        /// Audio Channel Layout
        /// </summary>
        public string AudioChannelLayout { get; set; }


        // Tv Episode
        /// <summary>
        /// Anamorphic
        /// </summary>
        public bool Anamorphic { get; set; }

        /// <summary>
        /// Pixel Aspect Ration
        /// </summary>
        public string PixelAspectRatio { get; set; }
    }
}
