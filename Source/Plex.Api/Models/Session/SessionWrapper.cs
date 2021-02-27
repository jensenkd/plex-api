namespace Plex.Api.Models.Session
{
    using System.Text.Json.Serialization;

    /// <summary>
    ///
    /// </summary>
    public class SessionWrapper
    {
        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("MediaContainer")]
        public SessionContainer SessionContainer { get; set; }
    }
}
