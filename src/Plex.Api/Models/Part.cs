using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class Part
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Duration { get; set; }
        public string File { get; set; }
        public string Size { get; set; }
        public string AudioProfile { get; set; }
        public string Container { get; set; }
        public string VideoProfile { get; set; }
        
        [JsonPropertyName("Stream")]
        public Stream[] Stream { get; set; }
    }
}