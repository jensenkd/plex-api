namespace Plex.ServerApi.PlexModels.Library.Search
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class FieldType
    {
        /// <summary>
        /// Type for the Field (tag, integer, string, date, resolution, etc..).
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Operators applicable to this field.
        /// </summary>
        [JsonPropertyName("Operator")]
        public List<FilterOperator> Operators { get; set; }
    }
}
