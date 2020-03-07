using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class Country
    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}