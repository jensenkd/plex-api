namespace Plex.ServerApi.PlexModels.Media
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Container object for all MediaPart objects. Provides useful data about the
    /// video or audio this media belong to such as video framerate, resolution, etc.
    /// </summary>
    public class Medium
    {
        /// <summary>
        /// The unique ID for this media on the server.
        /// </summary>
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// The duration of the media in milliseconds (ex: 6990483).
        /// </summary>
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        /// <summary>
        /// The bitrate of the media (ex: 1624).
        /// </summary>
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonPropertyName("bitrate")]
        public long Bitrate { get; set; }

        /// <summary>
        /// The width of the video in pixels (ex: 608).
        /// </summary>
        [JsonPropertyName("width")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int Width { get; set; }

        /// <summary>
        /// The height of the media in pixels (ex: 256).
        /// </summary>
        [JsonPropertyName("height")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int Height { get; set; }

        /// <summary>
        /// The aspect ratio of the media (ex: 2.35).
        /// </summary>
        [JsonPropertyName("aspectRatio")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public double AspectRatio { get; set; }

        /// <summary>
        /// The number of audio channels of the media (ex: 6).
        /// </summary>
        [JsonPropertyName("audioChannels")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int AudioChannels { get; set; }

        /// <summary>
        /// The audio codec of the media (ex: ac3).
        /// </summary>
        [JsonPropertyName("audioCodec")]
        public string AudioCodec { get; set; }

        /// <summary>
        /// The video codec of the media (ex: ac3).
        /// </summary>
        [JsonPropertyName("videoCodec")]
        public string VideoCodec { get; set; }

        /// <summary>
        /// The video resolution of the media (ex: sd).
        /// </summary>
        [JsonPropertyName("videoResolution")]
        public string VideoResolution { get; set; }

        /// <summary>
        /// The container of the media (ex: avi).
        /// </summary>
        [JsonPropertyName("container")]
        public string Container { get; set; }

        /// <summary>
        /// The video frame rate of the media (ex: 24p).
        /// </summary>
        [JsonPropertyName("videoFrameRate")]
        public string VideoFrameRate { get; set; }

        /// <summary>
        /// The audio profile of the media (ex: dts).
        /// </summary>
        [JsonPropertyName("audioProfile")]
        public string AudioProfile { get; set; }

        /// <summary>
        /// The video profile of the media (ex: high).
        /// </summary>
        [JsonPropertyName("videoProfile")]
        public string VideoProfile { get; set; }


       //***** Photo Only Attributes ******//

       /// <summary>
       /// The apeture used to take the photo.
       /// </summary>
       [JsonPropertyName("aperture")]
       public string Aperture { get; set; }

       /// <summary>
       /// The exposure used to take the photo.
       /// </summary>
       [JsonPropertyName("exposure")]
       public string Exposure { get; set; }

       /// <summary>
       /// The iso used to take the photo.
       /// </summary>
       [JsonPropertyName("iso")]
       public string Iso { get; set; }

       /// <summary>
       /// The lens used to take the photo.
       /// </summary>
       [JsonPropertyName("lens")]
       public string Lens { get; set; }

       /// <summary>
       /// The make of the camera used to take the photo.
       /// </summary>
       [JsonPropertyName("make")]
       public string Make { get; set; }

       /// <summary>
       /// The model of the camera used to take the photo.
       /// </summary>
       [JsonPropertyName("model")]
       public string Model { get; set; }

       [JsonPropertyName("Part")]
       public List<MediaPart> Part { get; set; }
    }
}
