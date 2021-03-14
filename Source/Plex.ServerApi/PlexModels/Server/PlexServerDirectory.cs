namespace Plex.ServerApi.PlexModels.Server
{
    using System.Text.Json.Serialization;

    public class PlexServerDirectory    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
