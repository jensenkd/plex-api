namespace Plex.ServerApi.PlexModels.Media
{
    using System.Text.Json.Serialization;

    public class Review
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("filter")]
        public string Filter { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }
    }
}
