namespace Plex.ServerApi.PlexModels.Server.Playlists
{
    using System.Text.Json.Serialization;

    public class Session
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("bandwidth")]
        public int Bandwidth { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }
    }
}
