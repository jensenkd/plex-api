namespace Plex.Api.Models.Session
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Helpers;
    using PlexModels.Media;

    /// <summary>
    /// Session Object
    /// </summary>
    public class Session
    {
        /// <summary>
        /// Session Constructor
        /// </summary>
        /// <param name="lastViewedAt">Last Viewed At</param>
        public Session(string lastViewedAt) => this.LastViewedAt = lastViewedAt;

        /// <summary>
        /// Added At
        /// </summary>
        [JsonPropertyName("addedAt")]
        public string AddedAt { get; set; }

        /// <summary>
        /// Art
        /// </summary>
        [JsonPropertyName("art")]
        public string Art { get; set; }

        /// <summary>
        /// Content Rating
        /// </summary>
        [JsonPropertyName("contentRating")]
        public string ContentRating { get; set; }

        /// <summary>
        /// Duration
        /// </summary>
        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        /// <summary>
        /// Grandparent Art
        /// </summary>
        [JsonPropertyName("grandparentArt")]
        public string GrandparentArt { get; set; }

        /// <summary>
        /// Grandparent Guid
        /// </summary>
        [JsonPropertyName("grandparentGuid")]
        public string GrandparentGuid { get; set; }

        /// <summary>
        /// Grandparent Key
        /// </summary>
        [JsonPropertyName("grandparentKey")]
        public string GrandparentKey { get; set; }

        /// <summary>
        /// Grandparent Rating Key
        /// </summary>
        [JsonPropertyName("grandparentRatingKey")]
        public string GrandparentRatingKey { get; set; }

        /// <summary>
        /// Grandparent Theme
        /// </summary>
        [JsonPropertyName("grandparentTheme")]
        public string GrandparentTheme { get; set; }

        /// <summary>
        /// Grandparent Thumbnail
        /// </summary>
        [JsonPropertyName("grandparentThumb")]
        public string GrandparentThumb { get; set; }

        /// <summary>
        /// Grandparent Title
        /// </summary>
        [JsonPropertyName("grandparentTitle")]
        public string GrandparentTitle { get; set; }

        /// <summary>
        /// Guid
        /// </summary>
        [JsonPropertyName("guid")]
        public string Guid { get; set; }

        /// <summary>
        /// Index
        /// </summary>
        [JsonPropertyName("index")]
        public string Index { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        /// Last Viewed At
        /// </summary>
        [JsonPropertyName("lastViewedAt")]
        public string LastViewedAt { get; set; }

        /// <summary>
        /// Library Section Id
        /// </summary>
        [JsonPropertyName("librarySectionID")]
        public string LibrarySectionId { get; set; }

        /// <summary>
        /// Libbrary Section Key
        /// </summary>
        [JsonPropertyName("librarySectionKey")]
        public string LibrarySectionKey { get; set; }

        /// <summary>
        /// Library Section Title
        /// </summary>
        [JsonPropertyName("librarySectionTitle")]
        public string LibrarySectionTitle { get; set; }

        /// <summary>
        /// Originally Available At
        /// </summary>
        [JsonPropertyName("originallyAvailableAt")]
        public string OriginallyAvailableAt { get; set; }

        /// <summary>
        /// Parent Guid
        /// </summary>
        [JsonPropertyName("parentGuid")]
        public string ParentGuid { get; set; }

        /// <summary>
        /// Parent Index
        /// </summary>
        [JsonPropertyName("parentIndex")]
        public string ParentIndex { get; set; }

        /// <summary>
        /// Parent Key
        /// </summary>
        [JsonPropertyName("parentKey")]
        public string ParentKey { get; set; }

        /// <summary>
        /// Parent Rating Key
        /// </summary>
        [JsonPropertyName("parentRatingKey")]
        public string ParentRatingKey { get; set; }

        /// <summary>
        /// Parent Thumb
        /// </summary>
        [JsonPropertyName("parentThumb")]
        public string ParentThumb { get; set; }

        /// <summary>
        /// Parent Title
        /// </summary>
        [JsonPropertyName("parentTitle")]
        public string ParentTitle { get; set; }

        /// <summary>
        /// Rating
        /// </summary>
        [JsonPropertyName("rating")]
        public string Rating { get; set; }

        /// <summary>
        /// Rating Key
        /// </summary>
        [JsonPropertyName("ratingKey")]
        public string RatingKey { get; set; }

        /// <summary>
        /// Session Key
        /// </summary>
        [JsonPropertyName("sessionKey")]
        public string SessionKey { get; set; }

        /// <summary>
        /// Summary
        /// </summary>
        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        /// <summary>
        /// Thumb
        /// </summary>
        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Updated At
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public string UpdatedAt { get; set; }

        /// <summary>
        /// View Offset
        /// </summary>
        [JsonPropertyName("viewOffset")]
        public string ViewOffset { get; set; }

        /// <summary>
        /// Year
        /// </summary>
        [JsonPropertyName("year")]
        [JsonConverter(typeof(IntValueConverter))]
        public int Year { get; set; }

        /// <summary>
        /// Director Items
        /// </summary>
        [JsonPropertyName("Director")]
        public List<Director> Directors { get; set; }

        /// <summary>
        /// Writer Items
        /// </summary>
        [JsonPropertyName("Writer")]
        public List<Writer> Writers { get; set; }

        /// <summary>
        /// Media Items
        /// </summary>
        [JsonPropertyName("Media")]
        public List<Medium> Media { get; set; }

        /// <summary>
        /// User
        /// </summary>
        [JsonPropertyName("User")]
        public User User { get; set; }

        /// <summary>
        /// Player
        /// </summary>
        [JsonPropertyName("Player")]
        public Player Player { get; set; }

        /// <summary>
        /// Session Detail
        /// </summary>
        [JsonPropertyName("Session")]
        public SessionDetail SessionDetail { get; set; }

        /// <summary>
        /// Transcode Session
        /// </summary>
        [JsonPropertyName("TranscodeSession")]
        public TranscodeSession TranscodeSession { get; set; }
    }
}
