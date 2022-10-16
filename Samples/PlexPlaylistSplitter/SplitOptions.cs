namespace PlexPlaylistSplitter;

public class SplitOptions
{
    public string? PlexToken { get; set; }

    public string? PlexUsername { get; set; }

    public string? PlexPassword { get; set; }

    public string? PlexServerName { get; set; }

    public string? PlaylistName { get; set; }

    public bool SortPlaylist { get; set; } = true;

    public int SplitCount { get; set; } = 250;

    public int ChunkSize { get; set; } = 25;

    public string PlaylistType { get; set; } = "audio";

    public string? ServerHostOverride { get; set; }

    public int? ServerPortOverride { get; set; }
}
