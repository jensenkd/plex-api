namespace Plex.ServerApi.PlexModels.Server.Playlists
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class PlaylistMetadata
    {
        [JsonPropertyName("addedAt")]
        public long AddedAt { get; set; }

        [JsonPropertyName("art")]
        public string Art { get; set; }

        [JsonPropertyName("composite")]
        public string Composite { get; set; }

        [JsonPropertyName("contentRating")]
        public string ContentRating { get; set; }

        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        [JsonPropertyName("grandparentArt")]
        public string GrandparentArt { get; set; }

        [JsonPropertyName("grandparentGuid")]
        public string GrandparentGuid { get; set; }

        [JsonPropertyName("grandparentKey")]
        public string GrandparentKey { get; set; }

        [JsonPropertyName("grandparentRatingKey")]
        public string GrandparentRatingKey { get; set; }

        [JsonPropertyName("grandparentTheme")]
        public string GrandparentTheme { get; set; }

        [JsonPropertyName("grandparentThumb")]
        public string GrandparentThumb { get; set; }

        [JsonPropertyName("grandparentTitle")]
        public string GrandparentTitle { get; set; }

        [JsonPropertyName("guid")]
        public string Guid { get; set; }

        [JsonPropertyName("index")]
        public string Index { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("leafCount")]
        public int LeafCount { get; set; }

        [JsonPropertyName("librarySectionID")]
        public string LibrarySectionId { get; set; }

        [JsonPropertyName("librarySectionKey")]
        public string LibrarySectionKey { get; set; }

        [JsonPropertyName("librarySectionTitle")]
        public string LibrarySectionTitle { get; set; }

        [JsonPropertyName("originallyAvailableAt")]
        public long OriginallyAvailableAt { get; set; }

        [JsonPropertyName("parentGuid")]
        public string ParentGuid { get; set; }

        [JsonPropertyName("parentIndex")]
        public string ParentIndex { get; set; }

        [JsonPropertyName("parentKey")]
        public string ParentKey { get; set; }

        [JsonPropertyName("parentRatingKey")]
        public string ParentRatingKey { get; set; }

        [JsonPropertyName("parentThumb")]
        public string ParentThumb { get; set; }

        [JsonPropertyName("parentTitle")]
        public string ParentTitle { get; set; }

        [JsonPropertyName("playlistType")]
        public string PlaylistType { get; set; }

        [JsonPropertyName("rating")]
        public string Rating { get; set; }

        [JsonPropertyName("ratingKey")]
        public string RatingKey { get; set; }

        [JsonPropertyName("sessionKey")]
        public string SessionKey { get; set; }

        [JsonPropertyName("smart")]
        public bool Smart { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("updatedAt")]
        public long UpdatedAt { get; set; }

        [JsonPropertyName("viewOffset")]
        public string ViewOffset { get; set; }

        [JsonPropertyName("year")]
        public string Year { get; set; }

        [JsonPropertyName("Media")]
        public List<Medium> Media { get; set; }

        [JsonPropertyName("User")]
        public User User { get; set; }

        [JsonPropertyName("Player")]
        public Player Player { get; set; }

        [JsonPropertyName("Session")]
        public Session Session { get; set; }

        [JsonPropertyName("chapterSource")]
        public string ChapterSource { get; set; }

        [JsonPropertyName("lastViewedAt")]
        public long LastViewedAt { get; set; }

        [JsonPropertyName("viewCount")]
        public int ViewCount { get; set; }

        [JsonPropertyName("Writer")]
        public List<Writer> Writer { get; set; }

        [JsonPropertyName("TranscodeSession")]
        public TranscodeSession TranscodeSession { get; set; }
    }
}
