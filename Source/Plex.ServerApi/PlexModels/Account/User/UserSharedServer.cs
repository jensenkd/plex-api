namespace Plex.ServerApi.PlexModels.Account.User
{
    using System.Xml.Serialization;

    [XmlRoot(ElementName="Server")]
    public class UserSharedServer
    {
        /// <summary>
        /// id for this share
        /// </summary>
        [XmlAttribute(AttributeName="id")]
        public int Id { get; set; }

        /// <summary>
        /// what id plex uses for this.
        /// </summary>
        [XmlAttribute(AttributeName="serverId")]
        public int ServerId { get; set; }

        /// <summary>
        ///  The servers machineIdentifier
        /// </summary>
        [XmlAttribute(AttributeName="machineIdentifier")]
        public string MachineIdentifier { get; set; }

        /// <summary>
        /// The servers name
        /// </summary>
        [XmlAttribute(AttributeName="name")]
        public string Name { get; set; }

        /// <summary>
        /// Last connected to the server?
        /// </summary>
        [XmlAttribute(AttributeName="lastSeenAt")]
        public long LastSeenAt { get; set; }

        /// <summary>
        /// Total number of libraries
        /// </summary>
        [XmlAttribute(AttributeName="numLibraries")]
        public int NumLibraries { get; set; }

        /// <summary>
        /// 1 if all libraries is shared with this user.
        /// </summary>
        [XmlAttribute(AttributeName="allLibraries")]
        public int AllLibraries { get; set; }

        /// <summary>
        /// 1 if the server is owned by the user.
        /// </summary>
        [XmlAttribute(AttributeName="owned")]
        public int Owned { get; set; }

        /// <summary>
        /// 1 if user's invite is pending.
        /// </summary>
        [XmlAttribute(AttributeName="pending")]
        public int Pending { get; set; }
    }
}
