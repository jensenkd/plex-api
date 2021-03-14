namespace Plex.ServerApi.PlexModels.Server.Devices
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class DeviceContainer
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("Device")]
        public List<Device> Device { get; set; }
    }
}
