using System.Text.Json.Serialization;
using Plex.Api.Helpers;

namespace Plex.Api.Models
{
    /// <summary>
    /// Director Plex Object
    /// </summary>
    public class Director
    {
        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("id")]
        [JsonConverter(typeof(IntValueConverter))]
        public int Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("filter")]
        public string Filter { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}
