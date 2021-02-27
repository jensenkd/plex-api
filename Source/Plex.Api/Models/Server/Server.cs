using System;
using System.Xml.Serialization;

namespace Plex.Api.Models.Server
{
    using Helpers;

    /// <summary>
    /// Server Object
    /// </summary>
    public class Server
    {
        /// <summary>
        /// Access Token
        /// </summary>
        [XmlAttribute(AttributeName = "accessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

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
        /// Current Plex Version
        /// </summary>
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        /// <summary>
        /// Scheme
        /// </summary>
        [XmlAttribute(AttributeName = "scheme")]
        public string Scheme { get; set; }

        /// <summary>
        /// Host
        /// </summary>
        [XmlAttribute(AttributeName = "host")]
        public string Host { get; set; }

        /// <summary>
        /// Local Address
        /// </summary>
        [XmlAttribute(AttributeName = "localAddresses")]
        public string LocalAddresses { get; set; }

        /// <summary>
        /// Machine Identifier
        /// </summary>
        [XmlAttribute(AttributeName = "machineIdentifier")]
        public string MachineIdentifier { get; set; }

        /// <summary>
        /// Created At
        /// </summary>
        [XmlAttribute(AttributeName = "createdAt")]
        public long CreatedAt { get; set; }

        /// <summary>
        /// Updated At
        /// </summary>
        [XmlAttribute(AttributeName = "updatedAt")]
        public long UpdatedAt { get; set; }

        /// <summary>
        /// Owned
        /// </summary>
        [XmlAttribute(AttributeName = "owned")]
        public string Owned { get; set; }

        /// <summary>
        /// Synced
        /// </summary>
        [XmlAttribute(AttributeName = "synced")]
        public string Synced { get; set; }

        /// <summary>
        /// Source Title
        /// </summary>
        [XmlAttribute(AttributeName = "sourceTitle")]
        public string SourceTitle { get; set; }

        /// <summary>
        /// Owner Id
        /// </summary>
        [XmlAttribute(AttributeName = "ownerId")]
        public string OwnerId { get; set; }

        /// <summary>
        /// Home
        /// </summary>
        [XmlAttribute(AttributeName = "home")]
        public string Home { get; set; }

        /// <summary>
        /// Full Uri
        /// </summary>
        public Uri FullUri => this.Host.ReturnUriFromServerInfo(this);
    }
}
