namespace Plex.Api.PlexModels.Library.Search
{
    using System.Text.Json.Serialization;

    public class FilterValue
    {
        [JsonPropertyName("fastKey")]
        public string FastKey { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
