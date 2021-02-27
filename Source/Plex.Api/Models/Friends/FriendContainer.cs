using System.Xml.Serialization;

namespace Plex.Api.Models.Friends
{
    /// <summary>
    /// Friend Container Object
    /// </summary>
    [XmlRoot(ElementName = "MediaContainer")]
    public class FriendContainer
    {
        /// <summary>
        /// Friend Items
        /// </summary>
        [XmlElement(ElementName = "User")]
        public Friend[] Friends { get; set; }

        /// <summary>
        /// Friendly Name
        /// </summary>
        [XmlAttribute(AttributeName = "friendlyName")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Identifier
        /// </summary>
        [XmlAttribute(AttributeName = "identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// Machine Identifier
        /// </summary>
        [XmlAttribute(AttributeName = "machineIdentifier")]
        public string MachineIdentifier { get; set; }

        /// <summary>
        /// Total Size
        /// </summary>
        [XmlAttribute(AttributeName = "totalSize")]
        public string TotalSize { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        [XmlAttribute(AttributeName = "size")]
        public string Size { get; set; }
    }
}
