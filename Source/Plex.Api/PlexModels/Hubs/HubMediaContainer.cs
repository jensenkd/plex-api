namespace Plex.Api.PlexModels.Hubs
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class HubMediaContainer
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("allowSync")]
        public bool AllowSync { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("librarySectionID")]
        public int LibrarySectionId { get; set; }

        [JsonPropertyName("librarySectionTitle")]
        public string LibrarySectionTitle { get; set; }

        [JsonPropertyName("librarySectionUUID")]
        public string LibrarySectionUuid { get; set; }

        [JsonPropertyName("Hub")]
        public List<Hub> Hub { get; set; }
    }
}
