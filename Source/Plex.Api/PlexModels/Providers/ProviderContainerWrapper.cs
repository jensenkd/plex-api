namespace Plex.Api.PlexModels.Providers
{
    using System.Text.Json.Serialization;

    /// <summary>
    /// Provider Wrapper
    /// </summary>
    public class ProviderContainerWrapper
    {
        /// <summary>
        /// Provider Summary
        /// </summary>
        [JsonPropertyName("MediaContainer")]
        public ProviderContainer ProviderContainer { get; set; }
    }
}
