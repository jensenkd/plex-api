using System.Text.Json.Serialization;
using Plex.Api.Helpers;

namespace Plex.Api.Models
{
    /// <summary>
    /// Country Object
    /// </summary>
    public class Country
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonPropertyName("id")]
        [JsonConverter(typeof(IntValueConverter))]
        public int Id { get; set; }

        /// <summary>
        /// Tag
        /// </summary>
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}
