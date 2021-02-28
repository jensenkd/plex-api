namespace Plex.Api.PlexModels.Providers
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class FeatureDirectory
    {
        public string Id { get; set; }
        public string HubKey { get; set; }
        public string Title { get; set; }

        [JsonPropertyName("Pivot")]
        public List<FeatureDirectoryPivot> Pivots { get; set; }
    }
}
