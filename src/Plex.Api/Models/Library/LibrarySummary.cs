using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    public class LibrariesWrapper
    {
        [JsonPropertyName("MediaContainer")] public LibrarySummary Libraries { get; set; }
    }

    public class LibrarySummary
    {
        [JsonPropertyName("size")] public int Size { get; set; }

        [JsonPropertyName("allowSync")] public bool AllowSync { get; set; }

        [JsonPropertyName("identifier")] public string Identifier { get; set; }

        [JsonPropertyName("mediaTagPrefix")] public string MediaTagPrefix { get; set; }

        [JsonPropertyName("mediaTagVersion")] public int MediaTagVersion { get; set; }

        [JsonPropertyName("title1")] public string Title1 { get; set; }

        [JsonPropertyName("Directory")] public List<Directory> Libraries { get; set; } = new List<Directory>();
    }
}