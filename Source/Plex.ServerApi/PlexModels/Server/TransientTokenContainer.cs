namespace Plex.ServerApi.PlexModels.Server
{
    using System.Text.Json.Serialization;

    public class TransientTokenContainer
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
