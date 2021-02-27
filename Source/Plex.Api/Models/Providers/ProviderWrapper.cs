namespace Plex.Api.Models.Providers
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Provider Wrapper
    /// </summary>
    public class ProviderWrapper
    {
        /// <summary>
        /// Provider Summary
        /// </summary>
        [JsonPropertyName("MediaContainer")]
        public ProviderSummary ProviderSummary { get; set; }
    }
}
