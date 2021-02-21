namespace Plex.Api.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    ///
    /// </summary>
    public class PlexMediaContainer
    {
        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("MediaContainer")]
        public MediaContainer MediaContainer { get; set; }
    }
}
