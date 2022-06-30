namespace Plex.ServerApi.PlexModels.Server.History
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class HistoryMediaContainer
    {
        public int Size { get; set; }
        public int TotalSize { get; set; }

        [JsonPropertyName("Metadata")]
        public List<HistoryMetadata> HistoryMetadata { get; set; }
    }
}
