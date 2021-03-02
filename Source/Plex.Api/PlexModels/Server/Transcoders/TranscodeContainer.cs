namespace Plex.Api.PlexModels.Server.Transcoders
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class TranscodeContainer    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("TranscodeSession")]
        public List<TranscodeSession> TranscodeSession { get; set; }
    }
}
