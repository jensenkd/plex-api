using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class Role
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}