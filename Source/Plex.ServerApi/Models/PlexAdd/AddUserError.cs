namespace Plex.ServerApi.Models.PlexAdd
{
    using System.Xml.Serialization;

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
}
