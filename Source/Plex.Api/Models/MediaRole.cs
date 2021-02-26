using System.Text.Json.Serialization;
using Plex.Api.Helpers;

namespace Plex.Api.Models
{
    /// <summary>
    /// Media Role Object
    /// </summary>
    public class MediaRole
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonConverter(typeof(IntValueConverter))]
        public int Id { get; set; }

        /// <summary>
        /// Filter
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Thumb
        /// </summary>
        public string Thumb { get; set; }

        /// <summary>
        /// Tag
        /// </summary>
        public string Tag { get; set; }
    }
}
