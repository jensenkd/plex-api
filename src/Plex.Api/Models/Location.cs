using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    /// <summary>
    /// Generic Location Object used on various Plex Objects
    /// </summary>
    public class Location
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("path")]
        public string Path { get; set; }
    }
}