namespace Plex.ServerApi.PlexModels.Account.Resources;

using System.Collections.Generic;
using System.Xml.Serialization;

/// <summary>
/// This object represents resources connected to your Plex server that can provide
/// content such as Plex Media Servers, iPhone or Android clients, etc. The raw xml
/// for the data presented here can be found at:
/// https://plex.tv/api/resources?includeHttps=1&includeRelay=1
/// </summary>
public class Resource
{
    public string Name { get; set; }
    public string Product { get; set; }
    public string ProductVersion { get; set; }
    public string Platform { get; set; }
    public string PlatformVersion { get; set; }
    public string Device { get; set; }
    public string ClientIdentifier { get; set; }
    public string CreatedAt { get; set; }
    public string LastSeenAt { get; set; }
    public string Provides { get; set; }
    public int? OwnerId { get; set; }
    public string SourceTitle { get; set; }
    public string PublicAddress { get; set; }
    public string AccessToken { get; set; }
    public bool Owned { get; set; }
    public bool Home { get; set; }
    public bool Synced { get; set; }
    public bool Relay { get; set; }
    public bool Presence { get; set; }
    public bool HttpsRequired { get; set; }
    public bool PublicAddressMatches { get; set; }
    public bool DnsRebindingProtection { get; set; }
    public bool NatLoopbackSupport { get; set; }

    /// <summary>
    /// Connections
    /// </summary>
    public List<ResourceConnection> Connections { get; set; }
}
