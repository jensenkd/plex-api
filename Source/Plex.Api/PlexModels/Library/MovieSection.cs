namespace Plex.Api.PlexModels.Library
{
    using System.Text.Json.Serialization;
    using ApiModels;

    public class MovieSection : SectionBase
    {
        [JsonPropertyName("scannedAt")]
        public long ScannedAt { get; set; }

        [JsonPropertyName("content")]
        public bool Content { get; set; }

        [JsonPropertyName("directory")]
        public bool Directory { get; set; }

        [JsonPropertyName("contentChangedAt")]
        public long ContentChangedAt { get; set; }

        [JsonPropertyName("hidden")]
        public int Hidden { get; set; }

        [JsonPropertyName("enableAutoPhotoTags")]
        public bool? EnableAutoPhotoTags { get; set; }
    }
}
