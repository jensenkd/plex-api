namespace Plex.ServerApi.PlexModels.Account
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "MediaContainer")]
    public class AccountServerContainer
    {
        [XmlElement(ElementName = "Server")]
        public List<AccountServer> Servers { get; set; }

        [XmlAttribute(AttributeName = "friendlyName")]
        public string FriendlyName { get; set; }

        [XmlAttribute(AttributeName = "identifier")]
        public string Identifier { get; set; }

        [XmlAttribute(AttributeName = "machineIdentifier")]
        public string MachineIdentifier { get; set; }

        [XmlAttribute(AttributeName = "size")] public int Size { get; set; }
    }
}
