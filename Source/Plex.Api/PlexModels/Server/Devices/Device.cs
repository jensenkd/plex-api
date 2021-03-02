namespace Plex.Api.PlexModels.Server.DeviceContainer
{
    using System.Text.Json.Serialization;

    public class Device
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        [JsonPropertyName("createdAt")]
        public int CreatedAt { get; set; }
    }
}
