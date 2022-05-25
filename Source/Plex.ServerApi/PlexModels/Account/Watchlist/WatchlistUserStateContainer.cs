namespace Plex.ServerApi.PlexModels.Watchlist;

using System.Text.Json.Serialization;

public class WatchlistUserStateContainer
{
    public string Identitfier { get; set; }
    public int Size { get; set; }

    [JsonPropertyName("UserState")]
    public WatchlistUserState UserState { get; set; }
}
