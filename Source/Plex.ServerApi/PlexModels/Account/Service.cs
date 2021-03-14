namespace Plex.ServerApi.PlexModels.Account
{
    using System.Text.Json.Serialization;

    public class Service    {
        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("endpoint")]
        public string Endpoint { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("secret")]
        public string Secret { get; set; }
    }
}
