namespace Plex.ServerApi.PlexModels.Providers
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Feature Object
    /// </summary>
    public class Feature
    {
        public string Key { get; set; }
        public string Type { get; set; }
        public string ScrobbleKey { get; set; }
        public string UnscrobbleKey { get; set; }

        [JsonPropertyName("Directory")]
        public List<FeatureDirectory> Directories { get; set; }
    }
}
