using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class Writer
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("filter")]
        public string Filter { get; set; }
        
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}