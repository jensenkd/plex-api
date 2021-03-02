namespace Plex.Api.PlexModels.Server.DeviceContainer
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Account;

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
