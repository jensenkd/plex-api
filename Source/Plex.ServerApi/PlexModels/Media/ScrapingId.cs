namespace Plex.ServerApi.PlexModels.Media
{
    using System.Text.Json.Serialization;

    public class ScrapingId
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
