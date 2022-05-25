namespace Plex.ServerApi.PlexModels.Account.Discover;

using System.Text.Json.Serialization;

public class DiscoverSearchResult
{
    public decimal Score { get; set; }

    [JsonPropertyName("Metadata")]
    public DiscoverSearchResultMetadata Metadata { get; set; }
}
