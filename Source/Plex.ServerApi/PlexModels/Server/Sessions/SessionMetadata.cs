namespace Plex.ServerApi.PlexModels.Server.Sessions;

using System.Collections.Generic;
using System.Text.Json.Serialization;
using Media;

public class SessionMetadata
{
    public long AddedAt { get; set; }
    public string Art { get; set; }
    public double AudienceRating { get; set; }
    public string AudienceRatingImage { get; set; }
    public string ChapterSource { get; set; }
    public string ContentRating { get; set; }
    public long Duration { get; set; }
    public string GrandparentArt { get; set; }
    public string GrandparentGuid { get; set; }
    public string GrandparentKey { get; set; }
    public string GrandparentRatingKey { get; set; }
    public string GrandparentTheme { get; set; }
    public string GrandparentThumb { get; set; }
    public string GrandparentTitle { get; set; }
    public string Guid { get; set; }
    public int Index { get; set; }
    public string Key { get; set; }

    [JsonPropertyName("librarySectionID")]
    public string LibrarySectionId { get; set; }

    public string LibrarySectionKey { get; set; }
    public string LibrarySectionTitle { get; set; }
    public string MusicAnalysisVersion { get; set; }
    public string OriginallyAvailableAt { get; set; }
    public long LastViewedAt { get; set; }

    public string ParentGuid { get; set; }
    public int ParentIndex { get; set; }
    public string ParentKey { get; set; }
    public string ParentRatingKey { get; set; }
    public int ParentYear { get; set; }
    public string ParentThumb { get; set; }
    public string ParentTitle { get; set; }
    public double Rating { get; set; }
    public int RatingCount { get; set; }
    public string Studio { get; set; }
    public string RatingKey { get; set; }
    public string SessionKey { get; set; }
    public string Summary { get; set; }
    public string Tagline { get; set; }
    public string Thumb { get; set; }
    public string Title { get; set; }
    public string TitleSort { get; set; }
    public string Type { get; set; }
    public long UpdatedAt { get; set; }
    public long ViewOffset { get; set; }
    public int Year { get; set; }

    [JsonPropertyName("Media")]
    public List<Medium> Media { get; set; }

    [JsonPropertyName("User")]
    public User User { get; set; }

    [JsonPropertyName("Player")]
    public Player Player { get; set; }

    [JsonPropertyName("Session")]
    public Session Session { get; set; }

    [JsonPropertyName("Writer")]
    public List<Writer> Writers { get; set; }

    [JsonPropertyName("Director")]
    public List<Director> Directors { get; set; }

    [JsonPropertyName("Genre")]
    public List<Genre> Genres { get; set; }

    [JsonPropertyName("Role")]
    public List<MediaRole> Roles { get; set; }

    [JsonPropertyName("Producer")]
    public List<Producer> Producers { get; set; }

    [JsonPropertyName("TranscodeSession")]
    public TranscodeSession TranscodeSessions { get; set; }

    [JsonPropertyName("Collection")]
    public List<Collection> Collections { get; set; }

    [JsonPropertyName("Similar")]
    public List<Similar> Similar { get; set; }

    [JsonPropertyName("Chapter")]
    public List<Chapter> Chapters { get; set; }
}
