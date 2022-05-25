namespace Plex.ServerApi.PlexModels.Watchlist;

public class WatchlistUserState
{
    public int WatchlistedAt { get; set; }
    public int ViewCount { get; set; }
    public int ViewOffset { get; set; }
    public string RatingKey { get; set; }
    public string Type { get; set; }
}
