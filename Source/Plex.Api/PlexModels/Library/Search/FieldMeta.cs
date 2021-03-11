namespace Plex.Api.PlexModels.Library.Search
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class FieldMeta
    {
        /// <summary>
        /// Filter Type (album, artist, track, movie, show, episode, etc).
        /// </summary>
        [JsonPropertyName("Type")]
        public List<FieldMetaType> Types { get; set; }

        /// <summary>
        /// Type of Field (tag, integer, etc..) along with operators.
        /// </summary>
        [JsonPropertyName("FieldType")]
        public List<FieldType> FieldTypes { get; set; }
    }
}
