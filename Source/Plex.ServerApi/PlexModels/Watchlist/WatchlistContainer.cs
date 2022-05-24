namespace Plex.ServerApi.PlexModels.Watchlist;

using System.Text.Json.Serialization;

public class WatchlistContainer
{
    public int Size { get; set; }
    public string Identifier { get; set; }

    [JsonPropertyName("librarySectionID")] public string librarySectionId { get; set; }

    public string librarySectionTitle { get; set; }

    [JsonPropertyName("Directory")] public WatchlistDirectory[] Directories { get; set; }

    [JsonPropertyName("Type")] public WatchlistType[] Types { get; set; }

    [JsonPropertyName("MediaContainer")]
    public WatchlistMetadataContainer[] MediaContainers { get; set; }
}
