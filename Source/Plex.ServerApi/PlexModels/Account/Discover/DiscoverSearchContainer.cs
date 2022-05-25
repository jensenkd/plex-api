namespace Plex.ServerApi.PlexModels.Account.Discover;

using System.Text.Json.Serialization;

public class DiscoverSearchContainer
{
    public string[] SuggestedTerms { get; set; }
    public string Identifier { get; set; }
    public int Size { get; set; }

    [JsonPropertyName("SearchResult")]
    public DiscoverSearchResult[] SearchResults { get; set; }
}
