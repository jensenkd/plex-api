namespace Plex.ServerApi.PlexModels.Account.Resources
{
    using System.Xml.Serialization;

    [XmlRoot(ElementName="Connection")]
    public class ResourceConnection {

        [XmlAttribute(AttributeName="protocol")]
        public string Protocol { get; set; }

        [XmlAttribute(AttributeName="address")]
        public string Address { get; set; }

        [XmlAttribute(AttributeName="port")]
        public int Port { get; set; }

        [XmlAttribute(AttributeName="uri")]
        public string Uri { get; set; }

        [XmlAttribute(AttributeName="local")]
        public int Local { get; set; }
    }
}
