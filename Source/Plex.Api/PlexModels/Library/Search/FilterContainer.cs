namespace Plex.Api.PlexModels.Library.Search
{
    namespace Plex.Api.PlexModels.Library.Search
    {
        using System.Collections.Generic;
        using System.Text.Json.Serialization;

        public class FilterContainer
        {
            [JsonPropertyName("size")]
            public int Size { get; set; }

            [JsonPropertyName("allowSync")]
            public bool AllowSync { get; set; }

            [JsonPropertyName("art")]
            public string Art { get; set; }

            [JsonPropertyName("content")]
            public string Content { get; set; }

            [JsonPropertyName("identifier")]
            public string Identifier { get; set; }

            [JsonPropertyName("librarySectionID")]
            public int LibrarySectionId { get; set; }

            [JsonPropertyName("librarySectionTitle")]
            public string LibrarySectionTitle { get; set; }

            [JsonPropertyName("librarySectionUUID")]
            public string LibrarySectionUuid { get; set; }

            [JsonPropertyName("mediaTagPrefix")]
            public string MediaTagPrefix { get; set; }

            [JsonPropertyName("mediaTagVersion")]
            public int MediaTagVersion { get; set; }

            [JsonPropertyName("thumb")]
            public string Thumb { get; set; }

            [JsonPropertyName("title1")]
            public string Title1 { get; set; }

            [JsonPropertyName("viewGroup")]
            public string ViewGroup { get; set; }

            [JsonPropertyName("viewMode")]
            public int ViewMode { get; set; }

            [JsonPropertyName("Directory")]
            public List<Filter> Filters { get; set; }
        }
    }

}
