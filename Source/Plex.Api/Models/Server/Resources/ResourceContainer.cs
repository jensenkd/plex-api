namespace Plex.Api.Models.Server.Resources
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Resource Container Object
    /// </summary>
    [XmlRoot(ElementName = "MediaContainer")]
    public class ResourceContainer
    {
        /// <summary>
        /// Device Items
        /// </summary>
        [XmlElement(ElementName = "Device")]
        public List<Resource> Devices { get; set; }
    }
}
