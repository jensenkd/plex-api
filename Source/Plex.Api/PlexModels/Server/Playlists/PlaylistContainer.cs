namespace Plex.Api.PlexModels.Server.Playlists
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class PlaylistContainer
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("Metadata")]
        public List<PlaylistMetadata> Metadata { get; set; }
    }
}
