namespace Plex.ServerApi.PlexModels.Server.History;

    using System.Text.Json.Serialization;

    public class HistoryMetadata
    {
        public string HistoryKey { get; set; }
        public string Key { get; set; }
        public string RatingKey { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Thumb { get; set; }
        public string OriginallyAvailableAt { get; set; }
        public int ViewedAt { get; set; }

        [JsonPropertyName("accountID")]
        public int AccountId { get; set; }

        public string ParentKey { get; set; }

        [JsonPropertyName("grandparentKey")]
        public string GrandParentKey { get; set; }
    }

