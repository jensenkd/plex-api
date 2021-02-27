namespace Plex.Api.Models.Server.Resources
{
    using System.Xml.Serialization;

    /// <summary>
    /// Connection Object
    /// </summary>
    public class Connection
    {
        /// <summary>
        /// Protocol
        /// </summary>
        [XmlAttribute(AttributeName = "protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        [XmlAttribute(AttributeName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Port
        /// </summary>
        [XmlAttribute(AttributeName = "port")]
        public string Port { get; set; }

        /// <summary>
        /// Uri
        /// </summary>
        [XmlAttribute(AttributeName = "uri")]
        public string Uri { get; set; }

        /// <summary>
        /// Local
        /// </summary>
        [XmlAttribute(AttributeName = "local")]
        public string Local { get; set; }
    }
}
