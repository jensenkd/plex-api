namespace Plex.ServerApi.PlexModels.Media;

using System.Collections.Generic;
using System.Text.Json.Serialization;

public class MediaContainer
{
    public int Size { get; set; }
    public int TotalSize { get; set; }
    public bool AllowSync { get; set; }
    public string Art { get; set; }
    public string Identifier { get; set; }

    [JsonPropertyName("librarySectionID")] public int LibrarySectionId { get; set; }
    public string LibrarySectionTitle { get; set; }

    [JsonPropertyName("librarySectionUUID")]
    public string LibrarySectionUuid { get; set; }

    public string MediaTagPrefix { get; set; }
    public int MediaTagVersion { get; set; }
    public int Offset { get; set; }
    public string Thumb { get; set; }
    public string Title1 { get; set; }
    public string Title2 { get; set; }
    public string ViewGroup { get; set; }
    public int ViewMode { get; set; }

    [JsonPropertyName("Meta")] public MediaMeta Meta { get; set; }
    [JsonPropertyName("Metadata")] public List<Metadata> Media { get; set; }
}
