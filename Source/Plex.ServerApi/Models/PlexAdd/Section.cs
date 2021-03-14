namespace Plex.ServerApi.Models.PlexAdd
{
    using System.Xml.Serialization;

    /// <summary>
    /// Section Object
    /// </summary>
    [XmlRoot(ElementName = "Section")]
    public class Section
    {
        /// <summary>
        /// Id
        /// </summary>
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        [XmlAttribute(AttributeName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Shared
        /// </summary>
        [XmlAttribute(AttributeName = "shared")]
        public string Shared { get; set; }
    }

}
