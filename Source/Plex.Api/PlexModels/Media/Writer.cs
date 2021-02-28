namespace Plex.Api.PlexModels.Media
{
    using System.Text.Json.Serialization;

    public class Writer    {
        [JsonPropertyName("tag")]
        public string Tag { get; set; }
    }
}