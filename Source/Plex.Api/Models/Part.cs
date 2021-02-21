using System.Text.Json.Serialization;
using Plex.Api.Helpers;

namespace Plex.Api.Models
{
    /// <summary>
    /// Attributes:
    ///     TAG (str): 'Part'
    ///     server (:class:`~plexapi.server.PlexServer`): PlexServer object this is from.
    ///     initpath (str): Relative path requested when retrieving specified data.
    ///     media (:class:`~plexapi.media.Media`): Media object this part belongs to.
    ///     container (str): Container type of this media part (ex: avi).
    ///     duration (int): Length of this media part in milliseconds.
    ///     file (str): Path to this file on disk (ex: /media/Movies/Cars.(2006)/Cars.cd2.avi)
    ///     id (int): Unique ID of this media part.
    ///     indexes (str, None): None or SD.
    ///     key (str): Key used to access this media part (ex: /library/parts/46618/1389985872/file.avi).
    ///     size (int): Size of this file in bytes (ex: 733884416).
    ///     streams (list&lt;:class:`~plexapi.media.MediaPartStream`&gt;): List of streams in this media part.
    ///     exists (bool): Determine if file exists
    ///     accessible (bool): Determine if file is accessible
    /// </summary>
    public class Part
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Part"/> class.
        /// </summary>
        /// <param name="stream"></param>
        public Part(Stream[] stream)
        {
            this.Stream = stream;
        }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Duration { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string File { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        public long Size { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Container { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string VideoProfile { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Stream[] Stream { get; set; }

        // TV Show Episode
        /// <summary>
        ///
        /// </summary>
        public string AudioProfile { get; set; }

        // Movie Section
        /// <summary>
        ///
        /// </summary>
        public string HasThumbnail { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Indexes { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool? HasChapterTextStream { get; set; }
    }
}
