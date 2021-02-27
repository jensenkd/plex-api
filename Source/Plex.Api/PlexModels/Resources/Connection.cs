namespace Plex.Api.PlexModels.Resources
{
    using System.Text.Json.Serialization;

    public class Connection    {
        [JsonPropertyName("protocol")]
        public string Protocol { get; set; } 

        [JsonPropertyName("address")]
        public string Address { get; set; } 

        [JsonPropertyName("port")]
        public int Port { get; set; } 

        [JsonPropertyName("uri")]
        public string Uri { get; set; } 

        [JsonPropertyName("local")]
        public bool Local { get; set; } 

        [JsonPropertyName("relay")]
        public bool Relay { get; set; } 

        [JsonPropertyName("IPv6")]
        public bool IPv6 { get; set; } 
    }
}