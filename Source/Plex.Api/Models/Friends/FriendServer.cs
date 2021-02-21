using System.Xml.Serialization;

namespace Plex.Api.Models.Friends
{
    /// <summary>
    ///
    /// </summary>
    [XmlRoot(ElementName = "Server")]
    public class FriendServer
    {
        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "serverId")]
        public string ServerId { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "machineIdentifier")]
        public string MachineIdentifier { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "lastSeenAt")]
        public string LastSeenAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "numLibraries")]
        public string NumLibraries { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "owned")]
        public string Owned { get; set; }
    }
}
