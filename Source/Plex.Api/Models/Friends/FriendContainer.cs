using System.Xml.Serialization;

namespace Plex.Api.Models.Friends
{
    /// <summary>
    ///
    /// </summary>
    [XmlRoot(ElementName = "MediaContainer")]
    public class FriendContainer
    {
        /// <summary>
        ///
        /// </summary>
        [XmlElement(ElementName = "User")]
        public Friend[] Friends { get; set; }
        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "friendlyName")]
        public string FriendlyName { get; set; }
        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "identifier")]
        public string Identifier { get; set; }
        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "machineIdentifier")]
        public string MachineIdentifier { get; set; }
        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "totalSize")]
        public string TotalSize { get; set; }
        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "size")]
        public string Size { get; set; }
    }
}
