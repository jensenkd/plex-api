namespace Plex.Api.PlexModels.Server.Releases
{
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
    }
}
