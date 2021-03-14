namespace Plex.ServerApi.PlexModels.Server.Clients
{
    using System.Text.Json.Serialization;

    public class ClientServer    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("host")]
        public string Host { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("port")]
        public int Port { get; set; }

        [JsonPropertyName("machineIdentifier")]
        public string MachineIdentifier { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        [JsonPropertyName("product")]
        public string Product { get; set; }

        [JsonPropertyName("deviceClass")]
        public string DeviceClass { get; set; }

        [JsonPropertyName("protocolVersion")]
        public string ProtocolVersion { get; set; }

        [JsonPropertyName("protocolCapabilities")]
        public string ProtocolCapabilities { get; set; }
    }
}
