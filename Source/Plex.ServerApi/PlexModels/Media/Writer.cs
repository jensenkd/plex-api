namespace Plex.ServerApi.PlexModels.Media
{
    using System.Text.Json.Serialization;

    public class Writer
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("filter")]
        public string Filter { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}
