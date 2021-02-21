namespace Plex.Api.Models.Server
{
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    ///
    /// </summary>
    public class Resource
    {
        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "product")]
        public string Product { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "productVersion")]
        public string ProductVersion { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "platform")]
        public string Platform { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "platformVersion")]
        public string PlatformVersion { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "device")]
        public string Device { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "clientIdentifier")]
        public string ClientIdentifier { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "lastSeenAt")]
        public string LastSeenAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "provides")]
        public string Provides { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "owned")]
        public string Owned { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "accessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "publicAddress")]
        public string PublicAddress { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "httpsRequired")]
        public string HttpsRequired { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "synced")]
        public string Synced { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "relay")]
        public string Relay { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "dnsRebindingProtection")]
        public string DnsRebindingProtection { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "natLoopbackSupported")]
        public string NatLoopbackSupported { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "publicAddressMatches")]
        public string PublicAddressMatches { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "presence")]
        public string Presence { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "createdAt")]
        public long CreatedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlElement(ElementName = "Connection")]
        public List<Connection> Connections { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class Connection
    {
        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "protocol")]
        public string Protocol { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "address")]
        public string Address { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "port")]
        public string Port { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "uri")]
        public string Uri { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "local")]
        public string Local { get; set; }
    }
}
