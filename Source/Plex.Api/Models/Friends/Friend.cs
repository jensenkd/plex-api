using System.Xml.Serialization;

namespace Plex.Api.Models.Friends
{
    /// <summary>
    ///
    /// </summary>
    [XmlRoot(ElementName = "User")]
    public class Friend
    {
        /// <summary>
        ///
        /// </summary>
        [XmlElement(ElementName = "Server")]
        public FriendServer Server { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "email")]
        public string Email { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "recommendationsPlaylistId")]
        public string RecommendationsPlaylistId { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "thumb")]
        public string Thumb { get; set; }
    }
}
