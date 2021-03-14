namespace Plex.ServerApi.PlexModels.Server.Clients
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ClientMediaContainer    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("Server")]
        public List<ClientServer> Server { get; set; }
    }
}
