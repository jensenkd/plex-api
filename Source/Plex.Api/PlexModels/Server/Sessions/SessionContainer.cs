namespace Plex.Api.PlexModels.Server.Sessions
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class SessionContainer
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("Metadata")]
        public List<SessionMetadata> Metadata { get; set; }
    }
}
