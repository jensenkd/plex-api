namespace Plex.ServerApi.PlexModels.Media
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Extras
    {
        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("allowSync")]
        public bool AllowSync { get; set; }

        [JsonPropertyName("augmentationKey")]
        public bool AugmentationKey { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("mediaTagPrefix")]
        public string MediaTagPrefix { get; set; }

        [JsonPropertyName("mediaTagVersion")]
        public long MediaTagVersion { get; set; }

        [JsonPropertyName("librarySectionID")]
        public int LibrarySectionId { get; set; }

        [JsonPropertyName("librarySectionTitle")]
        public string LibrarySectionTitle { get; set; }

        [JsonPropertyName("librarySectionUUID")]
        public string LibrarySectionUuid { get; set; }

        [JsonPropertyName("Metadata")]
        public List<Metadata> Media { get; set; }
    }
}
