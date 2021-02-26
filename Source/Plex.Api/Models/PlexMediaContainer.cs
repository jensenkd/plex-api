namespace Plex.Api.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Plex Media Container
    /// </summary>
    public class PlexMediaContainer
    {
        /// <summary>
        /// Media Container
        /// </summary>
        [JsonPropertyName("MediaContainer")]
        public MediaContainer MediaContainer { get; set; }
    }
}
