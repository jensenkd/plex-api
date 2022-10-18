namespace Plex.ServerApi.PlexModels.Server.Sessions
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Media;

    public class SessionMetadata
    {
        [JsonPropertyName("addedAt")]
        public long AddedAt { get; set; }

        [JsonPropertyName("art")]
        public string Art { get; set; }

        [JsonPropertyName("audienceRating")]
        public double AudienceRating { get; set; }

        [JsonPropertyName("audienceRatingImage")]
        public string AudienceRatingImage { get; set; }

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
        public int Index { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("librarySectionID")]
        public string LibrarySectionId { get; set; }

        [JsonPropertyName("librarySectionKey")]
        public string LibrarySectionKey { get; set; }

        [JsonPropertyName("librarySectionTitle")]
        public string LibrarySectionTitle { get; set; }

        [JsonPropertyName("originallyAvailableAt")]
        public string OriginallyAvailableAt { get; set; }

        [JsonPropertyName("parentGuid")]
        public string ParentGuid { get; set; }

        [JsonPropertyName("parentIndex")]
        public int ParentIndex { get; set; }

        [JsonPropertyName("parentKey")]
        public string ParentKey { get; set; }

        [JsonPropertyName("parentRatingKey")]
        public string ParentRatingKey { get; set; }

        [JsonPropertyName("parentThumb")]
        public string ParentThumb { get; set; }

        [JsonPropertyName("parentTitle")]
        public string ParentTitle { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("studio")]
        public string Studio { get; set; }

        [JsonPropertyName("ratingKey")]
        public string RatingKey { get; set; }

        [JsonPropertyName("sessionKey")]
        public string SessionKey { get; set; }

        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonPropertyName("tagline")]
        public string Tagline { get; set; }

        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("updatedAt")]
        public long UpdatedAt { get; set; }

        [JsonPropertyName("viewOffset")]
        public long ViewOffset { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

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

        [JsonPropertyName("titleSort")]
        public string TitleSort { get; set; }

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
}
