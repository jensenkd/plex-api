namespace Plex.Api.PlexModels.Server.Activities
{
    using System.Text.Json.Serialization;

    public class Activity
    {
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("cancellable")]
        public bool Cancellable { get; set; }

        [JsonPropertyName("userID")]
        public int UserID { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("subtitle")]
        public string Subtitle { get; set; }

        [JsonPropertyName("progress")]
        public int Progress { get; set; }

        [JsonPropertyName("Context")]
        public ActivityContext ActivityContext { get; set; }
    }
}
