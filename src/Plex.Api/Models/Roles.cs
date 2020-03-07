using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class Roles
    {
        [JsonPropertyName("roles")]
        public List<object> Role { get; set; }
    }
}