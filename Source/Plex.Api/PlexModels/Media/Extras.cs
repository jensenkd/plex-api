namespace Plex.Api.PlexModels.Media
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Extras
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("Metadata")]
        public List<Metadata> Metadata { get; set; }
    }
}
