namespace Plex.Api.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// User Role Object
    /// </summary>
    public class UserRole
    {
        /// <summary>
        /// Roles
        /// </summary>
        [JsonPropertyName("Roles")]
        public List<string> Roles { get; set; }
    }
}
