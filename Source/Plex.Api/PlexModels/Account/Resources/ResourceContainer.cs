namespace Plex.Api.PlexModels.Account.Resources
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "MediaContainer")]
    public class ResourceContainer
    {
        [XmlElement(ElementName = "Device")]
        public List<Resource> Resources { get; set; }

        [XmlAttribute(AttributeName = "size")]
        public int Size { get; set; }
    }
}
