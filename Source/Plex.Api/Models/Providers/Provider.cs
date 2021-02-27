namespace Plex.Api.Models.Providers
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Provider
    {

        public int? Id { get; set; }

        [JsonPropertyName("parentID")]
        public int? ParentId { get; set; }
        public string Identifier { get; set; }
        public string ProviderIdentifier { get; set; }
        public string Title { get; set; }
        public string Types { get; set; }
        public string Protocols { get; set; }
        public string EpgSource { get; set; }

        [JsonPropertyName("Feature")]
        public List<Feature> Features { get; set; }
    }
}
