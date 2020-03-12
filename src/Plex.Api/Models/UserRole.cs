using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class UserRole
    {
        [JsonPropertyName("Roles")]
        public List<string> Roles { get; set; }
    }
}