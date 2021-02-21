using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    /// <summary>
    ///
    /// </summary>
    public class Subscription
    {
        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("plan")]
        public object Plan { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("features")]
        public object Features { get; set; }
    }
}
