using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class PlexMediaContainer
    {
        [JsonPropertyName("MediaContainer")]
        public MediaContainer MediaContainer { get; set; }
    }
}