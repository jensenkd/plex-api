namespace Plex.Api.PlexModels.Media
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class MediaFieldType
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("Operator")]
        public List<MediaOperator> Operator { get; set; }
    }
}
