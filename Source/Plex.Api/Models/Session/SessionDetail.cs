namespace Plex.Api.Models.Session
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Session Detail Object
    /// </summary>
    public class SessionDetail
    {
        /// <summary>
        /// Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Bandwidth
        /// </summary>
        [JsonPropertyName("bandwidth")]
        public long Bandwidth { get; set; }

        /// <summary>
        /// Location
        /// </summary>
        [JsonPropertyName("location")]
        public string Location { get; set; }
    }
}
