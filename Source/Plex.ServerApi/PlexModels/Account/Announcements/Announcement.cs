namespace Plex.ServerApi.PlexModels.Account.Announcements
{
    using System.Xml.Serialization;

    public class Announcement
    {
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        [XmlAttribute(AttributeName = "content")]
        public string Content { get; set; }

        [XmlAttribute(AttributeName = "plainContent")]
        public string PlainContent { get; set; }

        [XmlAttribute(AttributeName = "imageUrl")]
        public string ImageUrl { get; set; }

        [XmlAttribute(AttributeName = "style")]
        public string Style { get; set; }

        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }

        [XmlAttribute(AttributeName = "expiresAt")]
        public string ExpiresAt { get; set; }

        [XmlAttribute(AttributeName = "notifyAt")]
        public string NotifyAt { get; set; }

        [XmlAttribute(AttributeName = "read")]
        public string Read { get; set; }
    }
}
