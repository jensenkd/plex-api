namespace Plex.ServerApi.PlexModels.Server.History
{
    using System.Text.Json.Serialization;

    public class HistoryMetadata
    {
        [JsonPropertyName("historyKey")]
        public string HistoryKey { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("ratingKey")]
        public string RatingKey { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

        [JsonPropertyName("originallyAvailableAt")]
        public string OriginallyAvailableAt { get; set; }

        [JsonPropertyName("viewedAt")]
        public int ViewedAt { get; set; }

        [JsonPropertyName("accountID")]
        public int AccountId { get; set; }
    }
}
