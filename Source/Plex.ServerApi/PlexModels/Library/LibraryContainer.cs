namespace Plex.ServerApi.PlexModels.Library
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class LibraryContainer
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("allowSync")]
        public bool AllowSync { get; set; }

        [JsonPropertyName("identifier")]
        public string Identifier { get; set; }

        [JsonPropertyName("mediaTagPrefix")]
        public string MediaTagPrefix { get; set; }

        [JsonPropertyName("mediaTagVersion")]
        public int MediaTagVersion { get; set; }

        [JsonPropertyName("title1")]
        public string Title1 { get; set; }

        [JsonPropertyName("Directory")]
        public List<Library> Libraries { get; set; }
    }
}
