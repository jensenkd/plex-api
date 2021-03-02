namespace Plex.Api.PlexModels.Server.History
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class HistoryMediaContainer
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("Metadata")]
        public List<HistoryMetadata> HistoryMetadata { get; set; }
    }
}
