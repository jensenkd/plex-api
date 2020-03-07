using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class PlexAuthentication
    {
        [JsonPropertyName("user")]
        public User User { get; set; }
    }
}
