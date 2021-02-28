namespace Plex.Api.PlexModels.Account
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Announcement Container
    /// </summary>
    [XmlRoot(ElementName = "MediaContainer")]
    public class AnnouncementWrapper
    {
        [XmlAttribute(AttributeName = "freindlyName")]
        public string FriendlyName { get; set; }

        [XmlAttribute(AttributeName = "identifier")]
        public string Identifier { get; set; }

        [XmlAttribute(AttributeName = "machineIdentifier")]
        public string MachineIdentifier { get; set; }

        [XmlAttribute(AttributeName = "totalSize")]
        public int TotalSize { get; set; }

        [XmlAttribute(AttributeName = "size")]
        public int Size { get; set; }

        [XmlAttribute(AttributeName = "title1")]
        public string Title1 { get; set; }

        [XmlAttribute(AttributeName = "viewGroup")]
        public string ViewGroup { get; set; }

        [XmlAttribute(AttributeName = "content")]
        public string Content { get; set; }

        [XmlElement(ElementName = "Announcement")]
        public List<Announcement> Announcements { get; set; }
    }
}
