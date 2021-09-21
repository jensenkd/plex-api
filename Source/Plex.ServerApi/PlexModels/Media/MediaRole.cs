namespace Plex.ServerApi.PlexModels.Media
{
    using System.Text.Json.Serialization;

    public class MediaRole
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("filter")]
        public string Filter { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

    }
}
