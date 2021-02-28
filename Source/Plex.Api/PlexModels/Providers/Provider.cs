namespace Plex.Api.PlexModels.Providers
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Provider
    {

        public int? Id { get; set; }

        [JsonPropertyName("parentID")]
        public int? ParentId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ProviderIdentifier { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Types { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Protocols { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string EpgSource { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Feature")]
        public List<Feature> Features { get; set; }
    }
}
