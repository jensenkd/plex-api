namespace Plex.ServerApi.PlexModels.Watchlist;

using System.Text.Json.Serialization;

public class WatchlistMetadataContainer
{
    public int Size { get; set; }
    [JsonPropertyName("Metadata")]
    public WatchlistMetadata[] Metadata { get; set; }
}
