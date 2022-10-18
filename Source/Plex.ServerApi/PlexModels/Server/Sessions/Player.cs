namespace Plex.ServerApi.PlexModels.Server.Sessions
{
    using System.Text.Json.Serialization;

    public class Player
    {
        public string Address { get; set; }
        public string Device { get; set; }
        public string MachineIdentifier { get; set; }
        public string Model { get; set; }
        public string Platform { get; set; }
        public string PlatformVersion { get; set; }
        public string Product { get; set; }
        public string Profile { get; set; }
        public string RemotePublicAddress { get; set; }
        public string State { get; set; }
        public string Title { get; set; }
        public string Vendor { get; set; }
        public string Version { get; set; }

        public bool Local { get; set; }
        public bool Relayed { get; set; }
        public bool Secure { get; set; }

        [JsonPropertyName("userID")]
        public int UserID { get; set; }
    }
}
