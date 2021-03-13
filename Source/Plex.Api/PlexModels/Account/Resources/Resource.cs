namespace Plex.Api.PlexModels.Account.Resources
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// This object represents resources connected to your Plex server that can provide
    /// content such as Plex Media Servers, iPhone or Android clients, etc. The raw xml
    /// for the data presented here can be found at:
    /// https://plex.tv/api/resources?includeHttps=1&includeRelay=1
    /// </summary>
    [XmlRoot(ElementName = "Device")]
    public class Resource
    {
        [XmlElement(ElementName = "Connection")]
        public List<ResourceConnection> Connections { get; set; }

        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "product")]
        public string Product { get; set; }

        [XmlAttribute(AttributeName = "productVersion")]
        public string ProductVersion { get; set; }

        [XmlAttribute(AttributeName = "platform")]
        public string Platform { get; set; }

        [XmlAttribute(AttributeName = "platformVersion")]
        public string PlatformVersion { get; set; }

        [XmlAttribute(AttributeName = "device")]
        public string Device { get; set; }

        [XmlAttribute(AttributeName = "clientIdentifier")]
        public string ClientIdentifier { get; set; }

        [XmlAttribute(AttributeName = "createdAt")]
        public int CreatedAt { get; set; }

        [XmlAttribute(AttributeName = "lastSeenAt")]
        public int LastSeenAt { get; set; }

        [XmlAttribute(AttributeName = "provides")]
        public string Provides { get; set; }

        [XmlAttribute(AttributeName = "owned")]
        public int Owned { get; set; }

        [XmlAttribute(AttributeName = "accessToken")]
        public string AccessToken { get; set; }

        [XmlAttribute(AttributeName = "publicAddress")]
        public string PublicAddress { get; set; }

        [XmlAttribute(AttributeName = "httpsRequired")]
        public int HttpsRequired { get; set; }

        [XmlAttribute(AttributeName = "synced")]
        public int Synced { get; set; }

        [XmlAttribute(AttributeName = "relay")]
        public int Relay { get; set; }

        [XmlAttribute(AttributeName = "dnsRebindingProtection")]
        public int DnsRebindingProtection { get; set; }

        [XmlAttribute(AttributeName = "natLoopbackSupported")]
        public int NatLoopbackSupported { get; set; }

        [XmlAttribute(AttributeName = "publicAddressMatches")]
        public int PublicAddressMatches { get; set; }

        [XmlAttribute(AttributeName = "presence")]
        public int Presence { get; set; }

        [XmlAttribute(AttributeName = "ownerId")]
        public int OwnerId { get; set; }

        [XmlAttribute(AttributeName = "home")]
        public int Home { get; set; }

        [XmlAttribute(AttributeName = "sourceTitle")]
        public string SourceTitle { get; set; }
    }
}
