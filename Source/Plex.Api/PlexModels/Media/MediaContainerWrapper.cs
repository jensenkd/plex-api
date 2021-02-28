namespace Plex.Api.PlexModels.Media
{
    using System.Text.Json.Serialization;

    public class MediaContainerWrapper
    {
        [JsonPropertyName("MediaContainer")]
        public MediaContainer MediaContainer { get; set; }
    }
}
