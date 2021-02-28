namespace Plex.Api.PlexModels.Account.User
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(ElementName="MediaContainer")]
    public class UserContainer
    {
        [XmlElement(ElementName="User")]
        public List<User> User { get; set; }

        [XmlAttribute(AttributeName="friendlyName")]
        public string FriendlyName { get; set; }

        [XmlAttribute(AttributeName="identifier")]
        public string Identifier { get; set; }

        [XmlAttribute(AttributeName="machineIdentifier")]
        public string MachineIdentifier { get; set; }

        [XmlAttribute(AttributeName="totalSize")]
        public int TotalSize { get; set; }

        [XmlAttribute(AttributeName="size")]
        public int Size { get; set; }
    }
}
