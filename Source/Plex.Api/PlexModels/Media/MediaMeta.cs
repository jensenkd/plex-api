namespace Plex.Api.PlexModels.Media
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class MediaMeta    {
        [JsonPropertyName("Type")]
        public List<MediaType> Type { get; set; }

        [JsonPropertyName("FieldType")]
        public List<MediaFieldType> FieldType { get; set; }
    }
}