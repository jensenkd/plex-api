using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    /// <summary>
    /// Subscription Model
    /// </summary>
    public class Subscription
    {
        /// <summary>
        /// Is Active?
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Plan Oject
        /// </summary>
        [JsonPropertyName("plan")]
        public object Plan { get; set; }

        /// <summary>
        /// Features Object
        /// </summary>
        [JsonPropertyName("features")]
        public object Features { get; set; }
    }
}
