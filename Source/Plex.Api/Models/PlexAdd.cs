using System.Collections.Generic;
using System.Xml.Serialization;

namespace Plex.Api.Models
{
    /// <summary>
    ///
    /// </summary>
    [XmlRoot(ElementName = "Section")]
    public class Section
    {
        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "key")]
        public string Key { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "shared")]
        public string Shared { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    [XmlRoot(ElementName = "SharedServer")]
    public class SharedServer
    {
        /// <summary>
        ///
        /// </summary>
        [XmlElement(ElementName = "Section")]
        public List<Section> Section { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

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
        [XmlAttribute(AttributeName = "userID")]
        public string UserId { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "accessToken")]
        public string AccessToken { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "acceptedAt")]
        public string AcceptedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "invitedAt")]
        public string InvitedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "allowSync")]
        public string AllowSync { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "allowCameraUpload")]
        public string AllowCameraUpload { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "allowChannels")]
        public string AllowChannels { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "allowTuners")]
        public string AllowTuners { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "owned")]
        public string Owned { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    [XmlRoot(ElementName = "MediaContainer")]
    public class PlexAdd
    {
        /// <summary>
        ///
        /// </summary>
        [XmlElement(ElementName = "SharedServer")]
        public SharedServer SharedServer { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "friendlyName")]
        public string FriendlyName { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "identifier")]
        public string Identifier { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "machineIdentifier")]
        public string MachineIdentifier { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "size")]
        public string Size { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    [XmlRoot(ElementName = "Response")]
    public class AddUserError
    {
        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "code")]
        public string Code { get; set; }

        /// <summary>
        ///
        /// </summary>
        [XmlAttribute(AttributeName = "status")]
        public string Status { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class PlexAddWrapper
    {
        /// <summary>
        ///
        /// </summary>
        public PlexAdd Add { get; set; }

        /// <summary>
        ///
        /// </summary>
        public AddUserError Error { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool HasError => Error != null;
    }
}
