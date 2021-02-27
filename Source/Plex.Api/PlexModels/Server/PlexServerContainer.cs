namespace Plex.Api.PlexModels.Server
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using System.Xml.Serialization;


    public class PlexServerContainer    {
        [JsonPropertyName("MediaContainer")]
        public PlexServer PlexServer { get; set; }
    }
}
