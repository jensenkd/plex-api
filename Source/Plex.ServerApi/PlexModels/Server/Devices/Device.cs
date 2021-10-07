namespace Plex.ServerApi.PlexModels.Server.Devices
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

        [JsonPropertyName("clientIdentifier")]
        public string ClientIdentifier { get; set; }

        [JsonPropertyName("createdAt")]
        public long CreatedAt { get; set; }
    }
}
