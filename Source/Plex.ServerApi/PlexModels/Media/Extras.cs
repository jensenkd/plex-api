namespace Plex.ServerApi.PlexModels.Media
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Extras
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonPropertyName("size")]
        public long Size { get; set; }

        [JsonPropertyName("Metadata")]
        public List<Metadata> Metadata { get; set; }
    }
}
