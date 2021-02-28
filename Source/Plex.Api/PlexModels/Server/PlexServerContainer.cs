namespace Plex.Api.PlexModels.Server
{
    using System.Text.Json.Serialization;

    public class PlexServerContainer
    {
        [JsonPropertyName("MediaContainer")]
        public PlexServer PlexServer { get; set; }
    }
}
