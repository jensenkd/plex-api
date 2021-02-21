using System.Text.Json.Serialization;
using Plex.Api.Helpers;

namespace Plex.Api.Models
{
    /// <summary>
    ///
    /// </summary>
    public class MediaRole
    {
        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Thumb { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Tag { get; set; }
    }
}
