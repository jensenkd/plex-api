namespace Plex.Api.Models.Server
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    ///
    /// </summary>
    [XmlRoot(ElementName = "MediaContainer")]
    public class ServerContainer
    {
        /// <summary>
        ///
        /// </summary>
        [XmlElement(ElementName = "Server")]
        public List<Server> Servers { get; set; }

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
        [XmlAttribute(AttributeName = "size")]
        public string Size { get; set; }
    }
}
