namespace Plex.ServerApi.PlexModels.Media
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Preference
    {
        [JsonPropertyName("Setting")]
        public List<Setting> Setting { get; set; }
    }
}
