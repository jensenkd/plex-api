namespace Plex.Api.PlexModels.Server.Releases
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class UpdateContainer
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("canInstall")]
        public bool CanInstall { get; set; }

        [JsonPropertyName("checkedAt")]
        public int CheckedAt { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("Release")]
        public List<Release> Releases { get; set; }
    }
}
