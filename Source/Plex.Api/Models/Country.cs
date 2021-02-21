using System.Text.Json.Serialization;
using Plex.Api.Helpers;

namespace Plex.Api.Models
{
    /// <summary>
    ///
    /// </summary>
    public class Country
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
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}
