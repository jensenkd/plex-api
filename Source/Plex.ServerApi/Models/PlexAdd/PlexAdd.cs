namespace Plex.ServerApi.Models.PlexAdd
{
    using System.Xml.Serialization;

    /// <summary>
    /// Plex Add Object
    /// </summary>
    [XmlRoot(ElementName = "MediaContainer")]
    public class PlexAdd
    {
        /// <summary>
        /// Shared Server
        /// </summary>
        [XmlElement(ElementName = "SharedServer")]
        public SharedServer SharedServer { get; set; }

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
        /// Size
        /// </summary>
        [XmlAttribute(AttributeName = "size")]
        public string Size { get; set; }
    }
}
