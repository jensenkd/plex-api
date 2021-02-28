namespace Plex.Api.PlexModels.Media
{
    using System.Text.Json.Serialization;

    public class MediaOperator    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}