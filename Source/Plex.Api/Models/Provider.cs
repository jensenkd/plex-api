namespace Plex.Api.Models
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Provider Object
    /// </summary>
    public class Provider
    {
        /// <summary>
        /// Identifier
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Base Url
        /// </summary>
        [JsonPropertyName("baseURL")]
        public string BaseUrl { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Icon
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// Source Title
        /// </summary>
        public string SourceTitle { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
    }
}
