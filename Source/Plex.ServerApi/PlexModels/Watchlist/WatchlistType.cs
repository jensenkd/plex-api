namespace Plex.ServerApi.PlexModels.Watchlist;

using System.Text.Json.Serialization;

public class WatchlistType
{
    public bool Active { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }
    public string Key { get; set; }

    [JsonPropertyName("Filter")]
    public WatchlistFilter[] Filters { get; set; }
}
