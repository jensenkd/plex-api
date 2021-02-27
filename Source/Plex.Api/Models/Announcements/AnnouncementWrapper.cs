namespace Plex.Api.Models.Announcements
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Announcement Container
    /// </summary>
    [XmlRoot(ElementName = "MediaContainer")]
    public class AnnouncementWrapper
    {
        [XmlElement(ElementName = "freindlyName")]
        public string FriendlyName { get; set; }

        [XmlElement(ElementName = "identifier")]
        public string Identifier { get; set; }

        [XmlElement(ElementName = "machineIdentifier")]
        public string MachineIdentifier { get; set; }

        [XmlElement(ElementName = "totalSize")]
        public int TotalSize { get; set; }

        [XmlElement(ElementName = "size")]
        public int Size { get; set; }

        [XmlElement(ElementName = "title1")]
        public string Title1 { get; set; }

        [XmlElement(ElementName = "viewGroup")]
        public string ViewGroup { get; set; }

        [XmlElement(ElementName = "content")]
        public string Content { get; set; }

        [XmlElement(ElementName = "Announcement")]
        public List<Announcement> Announcements { get; set; }
    }
}
