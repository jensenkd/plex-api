namespace Plex.ServerApi.PlexModels.Library.Search
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class FieldMetaType
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("type")]
        public string FieldType { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("Filter")]
        public List<Filter> Filters { get; set; }

        [JsonPropertyName("Sort")]
        public List<FilterSort> Sorts { get; set; }

        [JsonPropertyName("Field")]
        public List<FilterField> Fields { get; set; }
    }
}
