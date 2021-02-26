using System.Collections.Generic;
using System.Xml.Serialization;

namespace Plex.Api.Models
{
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

    /// <summary>
    /// Plex Add Object
    /// </summary>
    [XmlRoot(ElementName = "MediaContainer")]
    public class PlexAdd
    {
        /// <summary>
        /// Shared Server
        /// </summary>
        [XmlElement(ElementName = "SharedServer")]
        public SharedServer SharedServer { get; set; }

        /// <summary>
        /// Friendly Name
        /// </summary>
        [XmlAttribute(AttributeName = "friendlyName")]
        public string FriendlyName { get; set; }

        /// <summary>
        /// Identifier
        /// </summary>
        [XmlAttribute(AttributeName = "identifier")]
        public string Identifier { get; set; }

        /// <summary>
        /// Machine Identifier
        /// </summary>
        [XmlAttribute(AttributeName = "machineIdentifier")]
        public string MachineIdentifier { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        [XmlAttribute(AttributeName = "size")]
        public string Size { get; set; }
    }

    /// <summary>
    /// Add User Error Object
    /// </summary>
    [XmlRoot(ElementName = "Response")]
    public class AddUserError
    {
        /// <summary>
        /// Code
        /// </summary>
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        [XmlAttribute(AttributeName = "status")]
        public string Status { get; set; }
    }

    /// <summary>
    /// Plex Add Wrapper
    /// </summary>
    public class PlexAddWrapper
    {
        /// <summary>
        /// Add
        /// </summary>
        public PlexAdd Add { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public AddUserError Error { get; set; }

        /// <summary>
        /// Has Error?
        /// </summary>
        public bool HasError => Error != null;
    }
}
