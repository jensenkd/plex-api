namespace Plex.ServerApi.PlexModels.Server.Playlists
{
    using System.Text.Json.Serialization;

    public class User
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
