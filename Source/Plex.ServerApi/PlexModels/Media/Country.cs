namespace Plex.ServerApi.PlexModels.Media
{
    using System.Text.Json.Serialization;

    public class Country
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("filter")]
        public string Filter { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}
