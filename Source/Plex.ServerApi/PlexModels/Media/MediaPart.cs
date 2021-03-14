namespace Plex.ServerApi.PlexModels.Media
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Represents a single media part (often a single file) for the media this belongs to.
    /// </summary>
    public class MediaPart
    {
        /// <summary>
        /// The unique ID for this media part on the server.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// API URL (ex: /library/parts/46618/1389985872/file.mkv).
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// The duration of the file in milliseconds.
        /// </summary>
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        /// <summary>
        /// The path to this file on disk (ex: /media/Movies/Cars (2006)/Cars (2006).mkv)
        /// </summary>
        [JsonPropertyName("file")]
        public string File { get; set; }

        /// <summary>
        /// The size of the file in bytes (ex: 733884416).
        /// </summary>
        [JsonPropertyName("size")]
        public object Size { get; set; }

        /// <summary>
        /// The audio profile of the file.
        /// </summary>
        [JsonPropertyName("audioProfile")]
        public string AudioProfile { get; set; }

        /// <summary>
        /// The container type of the file (ex: avi).
        /// </summary>
        [JsonPropertyName("container")]
        public string Container { get; set; }

        /// <summary>
        /// The video profile of the file.
        /// </summary>
        [JsonPropertyName("videoProfile")]
        public string VideoProfile { get; set; }

        /// <summary>
        /// True if the file (track) has an embedded thumbnail.
        /// </summary>
        [JsonPropertyName("hasThumbnail")]
        public string HasThumbnail { get; set; }

        /// <summary>
        /// List of stream objects.
        /// </summary>
        [JsonPropertyName("Stream")]
        public List<Stream> Stream { get; set; }
    }
}
