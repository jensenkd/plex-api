namespace Plex.ServerApi.PlexModels.Server
{
    using System.Text.Json.Serialization;

    public class PlexServerContainer
    {
        [JsonPropertyName("MediaContainer")]
        public PlexServer PlexServer { get; set; }
    }
}
