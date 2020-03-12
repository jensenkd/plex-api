using System.ComponentModel;
using System.Text.Json.Serialization;
using Plex.Api.Helpers;

namespace Plex.Api.Models
{
    public class Role
    {
        [JsonPropertyName("id")]
        [JsonConverter(typeof(IntValueConverter))]
        public int Id { get; set; }

        [JsonPropertyName("role")]
        public string RoleName { get; set; }
        
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}