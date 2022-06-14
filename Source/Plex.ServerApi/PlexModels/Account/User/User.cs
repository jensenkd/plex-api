namespace Plex.ServerApi.PlexModels.Account.User
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// This object represents non-signed in users such as friends and linked
    /// accounts. NOTE: This should not be confused with the :class:`~plexapi.myplex.MyPlexAccount`
    /// which is your specific account. The raw xml for the data presented here
    /// can be found at: https://plex.tv/api/users/
    /// </summary>
    [XmlRoot(ElementName = "User")]
    public class User
    {
        /// <summary>
        /// User's Plex account ID.
        /// </summary>
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// User's Plex account UUID.
        /// </summary>
        [XmlAttribute(AttributeName = "uuid")]
        public string Uuid { get; set; }

        /// <summary>
        /// Is User Account Admin.
        /// </summary>
        [XmlAttribute(AttributeName = "admin")]
        public int IsAdmin { get; set; }

        /// <summary>
        /// Is User Account Guest.
        /// </summary>
        [XmlAttribute(AttributeName = "guest")]
        public int IsGuest { get; set; }

        /// <summary>
        /// Is User Account Restricted.
        /// </summary>
        [XmlAttribute(AttributeName = "restricted")]
        public int IsRestricted { get; set; }

        /// <summary>
        /// Restricted Profile if user is restricted
        /// </summary>
        [XmlAttribute(AttributeName = "restrictedProfile")]
        public string RestrictedProfile { get; set; }

        /// <summary>
        /// Does the user have a password
        /// </summary>
        [XmlAttribute(AttributeName = "hasPassword")]
        public bool HasPassword { get; set; }

        /// <summary>
        /// Seems to be an alias for username.
        /// </summary>
        [XmlAttribute(AttributeName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// User's username.
        /// </summary>
        [XmlAttribute(AttributeName = "username")]
        public string Username { get; set; }

        /// <summary>
        /// User's email address (user@gmail.com).
        /// </summary>
        [XmlAttribute(AttributeName = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Link to the users avatar.
        /// </summary>
        [XmlAttribute(AttributeName = "thumb")]
        public string Thumb { get; set; }

        /// <summary>
        /// Unknown (possibly SSL enabled?).
        /// </summary>
        [XmlAttribute(AttributeName = "protected")]
        public int Protected { get; set; }
    }
}
