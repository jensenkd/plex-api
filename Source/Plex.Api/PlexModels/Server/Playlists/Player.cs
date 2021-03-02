namespace Plex.Api.PlexModels.Server.Playlists
{
    using System.Text.Json.Serialization;

    public class Player    
    {
        [JsonPropertyName("address")]
        public string Address { get; set; } 

        [JsonPropertyName("device")]
        public string Device { get; set; } 

        [JsonPropertyName("machineIdentifier")]
        public string MachineIdentifier { get; set; } 

        [JsonPropertyName("model")]
        public string Model { get; set; } 

        [JsonPropertyName("platform")]
        public string Platform { get; set; } 

        [JsonPropertyName("platformVersion")]
        public string PlatformVersion { get; set; } 

        [JsonPropertyName("product")]
        public string Product { get; set; } 

        [JsonPropertyName("profile")]
        public string Profile { get; set; } 

        [JsonPropertyName("remotePublicAddress")]
        public string RemotePublicAddress { get; set; } 

        [JsonPropertyName("state")]
        public string State { get; set; } 

        [JsonPropertyName("title")]
        public string Title { get; set; } 

        [JsonPropertyName("vendor")]
        public string Vendor { get; set; } 

        [JsonPropertyName("version")]
        public string Version { get; set; } 

        [JsonPropertyName("local")]
        public bool Local { get; set; } 

        [JsonPropertyName("relayed")]
        public bool Relayed { get; set; } 

        [JsonPropertyName("secure")]
        public bool Secure { get; set; } 

        [JsonPropertyName("userID")]
        public int UserID { get; set; } 
    }
}