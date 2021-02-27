namespace Plex.Api.Models.Session
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Session Container Object
    /// </summary>
    public class SessionContainer
    {
        /// <summary>
        /// Size
        /// </summary>
        [JsonPropertyName("size")]
        public long Size { get; set; }

        /// <summary>
        /// Metadata Items
        /// </summary>
        [JsonPropertyName("Metadata")]
        public List<Session> Sessions { get; set; }
    }
}
