namespace Plex.ServerApi.PlexModels.Library.Search
{
    using System.Text.Json.Serialization;

    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Filter
    {
        /// <summary>
        /// Filter Name.
        /// </summary>
        [JsonPropertyName("filter")]
        public string FilterName { get; set; }

        /// <summary>
        /// Filter Type
        /// </summary>
        [JsonPropertyName("filterType")]
        public string FilterType { get; set; }

        /// <summary>
        /// Filter Url Key
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
