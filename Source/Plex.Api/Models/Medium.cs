using System.Text.Json.Serialization;
using Plex.Api.Helpers;

namespace Plex.Api.Models
{
    /// <summary>
    /// Attributes:
    ///     TAG (str): 'Media'
    ///     server (:class:`~plexapi.server.PlexServer`): PlexServer object this is from.
    ///     initpath (str): Relative path requested when retrieving specified data.
    ///     video (str): Video this media belongs to.
    ///     aspectRatio (float): Aspect ratio of the video (ex: 2.35).
    ///     audioChannels (int): Number of audio channels for this video (ex: 6).
    ///     audioCodec (str): Audio codec used within the video (ex: ac3).
    ///     bitrate (int): Bitrate of the video (ex: 1624)
    ///     container (str): Container this video is in (ex: avi).
    ///     duration (int): Length of the video in milliseconds (ex: 6990483).
    ///     height (int): Height of the video in pixels (ex: 256).
    ///     id (int): Plex ID of this media item (ex: 46184).
    ///     has64bitOffsets (bool): True if video has 64 bit offsets (?).
    ///     optimizedForStreaming (bool): True if video is optimized for streaming.
    ///     target (str): Media version target name.
    ///     title (str): Media version title.
    ///     videoCodec (str): Video codec used within the video (ex: ac3).
    ///     videoFrameRate (str): Video frame rate (ex: 24p).
    ///     videoResolution (str): Video resolution (ex: sd).
    ///     videoProfile (str): Video profile (ex: high).
    ///     width (int): Width of the video in pixels (ex: 608).
    ///     parts (list&lt;:class:`~plexapi.media.MediaPart`&gt;): List of MediaParts in this video.
    /// </summary>
    public class Medium
    {
        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(DoubleValueConverter))]
        public double AspectRatio { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string AudioProfile { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string VideoProfile { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int AudioChannels { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string AudioCodec { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Bitrate { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Container { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long Duration { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Height { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int OptimizedForStreaming { get; set; } // TODO Convert to boolean at some point.

        /// <summary>
        ///
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string VideoCodec { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string VideoFrameRate { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string VideoResolution { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Width { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Part")]
        public Part[] Part { get; set; }
    }
}
