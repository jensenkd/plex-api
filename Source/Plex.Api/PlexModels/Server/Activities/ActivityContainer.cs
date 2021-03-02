namespace Plex.Api.PlexModels.Server.Activities
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ActivityContainer    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("Activity")]
        public List<Activity> Activity { get; set; }
    }
}
