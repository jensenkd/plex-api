namespace Plex.Api.PlexModels.Hubs
{
    using System.Text.Json.Serialization;

    public class HubMediaContainerWrapper
    {
        [JsonPropertyName("MediaContainer")]
        public HubMediaContainer HubMediaContainer { get; set; }

    }
}
