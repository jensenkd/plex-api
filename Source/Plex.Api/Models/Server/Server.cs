using System;
using System.Xml.Serialization;

namespace Plex.Api.Models.Server
{
    /// <summary>
    ///
    /// </summary>
    public class Server
    {
        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "accessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

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
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "scheme")]
        public string Scheme { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "host")]
        public string Host { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "localAddresses")]
        public string LocalAddresses { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "machineIdentifier")]
        public string MachineIdentifier { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "createdAt")]
        public long CreatedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "updatedAt")]
        public long UpdatedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "owned")]
        public string Owned { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "synced")]
        public string Synced { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "sourceTitle")]
        public string SourceTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "ownerId")]
        public string OwnerId { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "home")]
        public string Home { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Uri FullUri => this.Host.ReturnUriFromServerInfo(this);
    }
}
