namespace Plex.Api.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    ///
    /// </summary>
    public class UserRole
    {
        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Roles")]
        public List<string> Roles { get; set; }
    }
}
