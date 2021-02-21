namespace Plex.Api.Models.Server
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    ///
    /// </summary>
    [XmlRoot(ElementName = "MediaContainer")]
    public class ResourceContainer
    {
        /// <summary>
        ///
        /// </summary>
        [XmlElement(ElementName = "Device")]
        public List<Resource> Devices { get; set; }
    }
}
