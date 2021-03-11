namespace Plex.Api.PlexModels.Library.Search
{
    using System.Text.Json.Serialization;

    public class FilterOperator
    {
        /// <summary>
        /// Key for the Operator (ex: =, !=, >).
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Title for the Operator (ex: is, is not)
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
