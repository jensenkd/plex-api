namespace Plex.ServerApi.PlexModels.PlayQueues
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Media;

    public class PlayQueueContainer
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("mediaTagPrefix")]
        public string MediaTagPrefix { get; set; }

        [JsonPropertyName("mediaTagVersion")]
        public long MediaTagVersion { get; set; }

        [JsonPropertyName("playQueueID")]
        public long PlayQueueId { get; set; }

        [JsonPropertyName("playQueueSelectedItemID")]
        public long PlayQueueSelectedItemId { get; set; }

        [JsonPropertyName("playQueueSelectedItemOffset")]
        public long PlayQueueSelectedItemOffset { get; set; }

        [JsonPropertyName("playQueueSelectedMetadataItemID")]
        public string PlayQueueSelectedMetadataItemId { get; set; }

        [JsonPropertyName("playQueueShuffled")]
        public bool PlayQueueShuffled { get; set; }

        [JsonPropertyName("playQueueSourceURI")]
        public string PlayQueueSourceUri { get; set; }

        [JsonPropertyName("playQueueTotalCount")]
        public int PlayQueueTotalCount { get; set; }

        [JsonPropertyName("playQueueVersion")]
        public  int PlayQueueVersion { get; set; }

        [JsonPropertyName("Metadata")]
        public List<Metadata> Media { get; set; }
    }
}
