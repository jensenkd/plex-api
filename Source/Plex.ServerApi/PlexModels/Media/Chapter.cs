namespace Plex.ServerApi.PlexModels.Media
{
    using System.Text.Json.Serialization;

    public class Chapter
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("filter")]
        public string Filter { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("startTimeOffset")]
        public int StartTimeOffset { get; set; }

        [JsonPropertyName("endTimeOffset")]
        public int EndTimeOffset { get; set; }
    }
}
