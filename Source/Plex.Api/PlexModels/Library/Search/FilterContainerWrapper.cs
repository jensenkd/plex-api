namespace Plex.Api.PlexModels.Library.Search
{
    using System.Text.Json.Serialization;

    public class FilterContainerWrapper
    {
        [JsonPropertyName("MediaContainer")]
        public FilterContainer FilterContainer { get; set; }
    }
}
