namespace Plex.Api.PlexModels.Library.Search
{
    using System.Text.Json.Serialization;

    public class FilterField
    {
        /// <summary>
        /// Url key for the filter.
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Title of filter.
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Subtype of filter (decade, rating, etc).
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("subType")]
        public string SubType { get; set; }
    }
}
