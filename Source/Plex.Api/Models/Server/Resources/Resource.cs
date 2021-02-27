namespace Plex.Api.Models.Server.Resources
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Resource Object
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// Name
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        [XmlAttribute(AttributeName = "product")]
        public string Product { get; set; }

        /// <summary>
        /// Product Version
        /// </summary>
        [XmlAttribute(AttributeName = "productVersion")]
        public string ProductVersion { get; set; }

        /// <summary>
        /// Platform
        /// </summary>
        [XmlAttribute(AttributeName = "platform")]
        public string Platform { get; set; }

        /// <summary>
        /// Platform Version
        /// </summary>
        [XmlAttribute(AttributeName = "platformVersion")]
        public string PlatformVersion { get; set; }

        /// <summary>
        /// Device
        /// </summary>
        [XmlAttribute(AttributeName = "device")]
        public string Device { get; set; }

        /// <summary>
        /// Client Indentifier
        /// </summary>
        [XmlAttribute(AttributeName = "clientIdentifier")]
        public string ClientIdentifier { get; set; }

        /// <summary>
        /// Last Seen At
        /// </summary>
        [XmlAttribute(AttributeName = "lastSeenAt")]
        public string LastSeenAt { get; set; }

        /// <summary>
        /// Provides
        /// </summary>
        [XmlAttribute(AttributeName = "provides")]
        public string Provides { get; set; }

        /// <summary>
        /// Owned
        /// </summary>
        [XmlAttribute(AttributeName = "owned")]
        public string Owned { get; set; }

        /// <summary>
        /// Access Token
        /// </summary>
        [XmlAttribute(AttributeName = "accessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Public Address
        /// </summary>
        [XmlAttribute(AttributeName = "publicAddress")]
        public string PublicAddress { get; set; }

        /// <summary>
        /// Https Required
        /// </summary>
        [XmlAttribute(AttributeName = "httpsRequired")]
        public string HttpsRequired { get; set; }

        /// <summary>
        /// Synced
        /// </summary>
        [XmlAttribute(AttributeName = "synced")]
        public string Synced { get; set; }

        /// <summary>
        /// Relay
        /// </summary>
        [XmlAttribute(AttributeName = "relay")]
        public string Relay { get; set; }

        /// <summary>
        /// DNS Rebinding Protection
        /// </summary>
        [XmlAttribute(AttributeName = "dnsRebindingProtection")]
        public string DnsRebindingProtection { get; set; }

        /// <summary>
        /// Nat Loopback Supported
        /// </summary>
        [XmlAttribute(AttributeName = "natLoopbackSupported")]
        public string NatLoopbackSupported { get; set; }

        /// <summary>
        /// Public Address Matches
        /// </summary>
        [XmlAttribute(AttributeName = "publicAddressMatches")]
        public string PublicAddressMatches { get; set; }

        /// <summary>
        /// Presence
        /// </summary>
        [XmlAttribute(AttributeName = "presence")]
        public string Presence { get; set; }

        /// <summary>
        /// Created At
        /// </summary>
        [XmlAttribute(AttributeName = "createdAt")]
        public long CreatedAt { get; set; }

        /// <summary>
        /// Connection Items
        /// </summary>
        [XmlElement(ElementName = "Connection")]
        public List<Connection> Connections { get; set; }
    }
}
