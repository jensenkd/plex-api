namespace Plex.ServerApi.PlexModels.Account.Resources;

using System.Text.Json.Serialization;

public class ResourceConnection {

    public string Protocol { get; set; }
    public string Address { get; set; }
    public int Port { get; set; }
    public string Uri { get; set; }
    public bool Local { get; set; }
    public bool Relay { get; set; }
    [JsonPropertyName("IPv6")]
    public bool IpV6 { get; set; }
}
