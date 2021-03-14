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
        /// Unknown.
        /// </summary>
        [XmlAttribute(AttributeName = "recommendationsPlaylistId")]
        public string RecommendationsPlaylistId { get; set; }

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

        /// <summary>
        /// Unknown.
        /// </summary>
        [XmlAttribute(AttributeName = "home")]
        public int Home { get; set; }

        /// <summary>
        /// True if this user can use Tuners.
        /// </summary>
        [XmlAttribute(AttributeName = "allowTuners")]
        public int AllowTuners { get; set; }

        /// <summary>
        /// True if this user can sync.
        /// </summary>
        [XmlAttribute(AttributeName = "allowSync")]
        public int AllowSync { get; set; }

        /// <summary>
        /// True if this user can upload images.
        /// </summary>
        [XmlAttribute(AttributeName = "allowCameraUpload")]
        public int AllowCameraUpload { get; set; }

        /// <summary>
        /// True if this user has access to channels.
        /// </summary>
        [XmlAttribute(AttributeName = "allowChannels")]
        public int AllowChannels { get; set; }

        /// <summary>
        /// True if this user has admin to Subtitles
        /// </summary>
        [XmlAttribute(AttributeName = "allowSubtitleAdmin")]
        public int AllowSubtitleAdmin { get; set; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [XmlAttribute(AttributeName = "filterAll")]
        public string FilterAll { get; set; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [XmlAttribute(AttributeName = "filterMovies")]
        public string FilterMovies { get; set; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [XmlAttribute(AttributeName = "filterMusic")]
        public string FilterMusic { get; set; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [XmlAttribute(AttributeName = "filterPhotos")]
        public string FilterPhotos { get; set; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [XmlAttribute(AttributeName = "filterTelevision")]
        public string FilterTelevision { get; set; }

        /// <summary>
        /// Unknown.
        /// </summary>
        [XmlAttribute(AttributeName = "restricted")]
        public int Restricted { get; set; }

        /// <summary>
        /// Servers shared between user and friend
        /// </summary>
        [XmlElement(ElementName = "Server")]
        public List<UserSharedServer> SharedServers { get; set; }
    }
}
