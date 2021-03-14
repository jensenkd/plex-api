namespace Plex.ServerApi.Models.PlexAdd
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// Shared Server Object
    /// </summary>
    [XmlRoot(ElementName = "SharedServer")]
    public class SharedServer
    {
        /// <summary>
        /// Sections
        /// </summary>
        [XmlElement(ElementName = "Section")]
        public List<Section> Section { get; set; }

        /// <summary>
        /// Id
        /// </summary>
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

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
        /// User Id
        /// </summary>
        [XmlAttribute(AttributeName = "userID")]
        public string UserId { get; set; }

        /// <summary>
        /// Access Token
        /// </summary>
        [XmlAttribute(AttributeName = "accessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Accepted Date
        /// </summary>
        [XmlAttribute(AttributeName = "acceptedAt")]
        public string AcceptedAt { get; set; }

        /// <summary>
        /// Invited Date
        /// </summary>
        [XmlAttribute(AttributeName = "invitedAt")]
        public string InvitedAt { get; set; }

        /// <summary>
        /// Allow Sync
        /// </summary>
        [XmlAttribute(AttributeName = "allowSync")]
        public string AllowSync { get; set; }

        /// <summary>
        /// Allow Camera Upload
        /// </summary>
        [XmlAttribute(AttributeName = "allowCameraUpload")]
        public string AllowCameraUpload { get; set; }

        /// <summary>
        /// Allow Channels
        /// </summary>
        [XmlAttribute(AttributeName = "allowChannels")]
        public string AllowChannels { get; set; }

        /// <summary>
        /// Allow Tuners
        /// </summary>
        [XmlAttribute(AttributeName = "allowTuners")]
        public string AllowTuners { get; set; }

        /// <summary>
        /// Owned
        /// </summary>
        [XmlAttribute(AttributeName = "owned")]
        public string Owned { get; set; }
    }
}
