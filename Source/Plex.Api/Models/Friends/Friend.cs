using System.Xml.Serialization;

namespace Plex.Api.Models.Friends
{
    /// <summary>
    /// Friend Object
    /// </summary>
    [XmlRoot(ElementName = "User")]
    public class Friend
    {
        /// <summary>
        /// Server
        /// </summary>
        [XmlElement(ElementName = "Server")]
        public FriendServer Server { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [XmlAttribute(AttributeName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Recommended Playlist Id
        /// </summary>
        [XmlAttribute(AttributeName = "recommendationsPlaylistId")]
        public string RecommendationsPlaylistId { get; set; }

        /// <summary>
        /// Thumbnail
        /// </summary>
        [XmlAttribute(AttributeName = "thumb")]
        public string Thumb { get; set; }
    }
}
