using System.Xml.Serialization;

namespace Plex.Api.Models.Friends
{
    /// <summary>
    /// Friend Server Object
    /// </summary>
    [XmlRoot(ElementName = "Server")]
    public class FriendServer
    {
        /// <summary>
        /// Id
        /// </summary>
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Server Id
        /// </summary>
        [XmlAttribute(AttributeName = "serverId")]
        public string ServerId { get; set; }

        /// <summary>
        /// Machine Identifier
        /// </summary>
        [XmlAttribute(AttributeName = "machineIdentifier")]
        public string MachineIdentifier { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Last Seen At
        /// </summary>
        [XmlAttribute(AttributeName = "lastSeenAt")]
        public string LastSeenAt { get; set; }

        /// <summary>
        /// Number of Libraries
        /// </summary>
        [XmlAttribute(AttributeName = "numLibraries")]
        public string NumLibraries { get; set; }

        /// <summary>
        /// Owned
        /// </summary>
        [XmlAttribute(AttributeName = "owned")]
        public string Owned { get; set; }
    }
}
