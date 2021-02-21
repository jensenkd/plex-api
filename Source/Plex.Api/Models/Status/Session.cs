namespace Plex.Api.Models.Status
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using Plex.Api.Helpers;

    /// <summary>
    ///
    /// </summary>
    public class SessionWrapper
    {
        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("MediaContainer")]
        public SessionContainer SessionContainer { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class SessionContainer
    {
        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("size")]
        public long Size { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Metadata")]
        public List<Session> Sessions { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class Session
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="lastViewedAt"></param>
        public Session(string lastViewedAt)
        {
            this.LastViewedAt = lastViewedAt;
        }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("addedAt")]
        public string AddedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("art")]
        public string Art { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("contentRating")]
        public string ContentRating { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("grandparentArt")]
        public string GrandparentArt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("grandparentGuid")]
        public string GrandparentGuid { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("grandparentKey")]
        public string GrandparentKey { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("grandparentRatingKey")]
        public string GrandparentRatingKey { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("grandparentTheme")]
        public string GrandparentTheme { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("grandparentThumb")]
        public string GrandparentThumb { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("grandparentTitle")]
        public string GrandparentTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("guid")]
        public string Guid { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("index")]
        public string Index { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("lastViewedAt")]
        public string LastViewedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("librarySectionID")]
        public string LibrarySectionId { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("librarySectionKey")]
        public string LibrarySectionKey { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("librarySectionTitle")]
        public string LibrarySectionTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("originallyAvailableAt")]
        public string OriginallyAvailableAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("parentGuid")]
        public string ParentGuid { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("parentIndex")]
        public string ParentIndex { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("parentKey")]
        public string ParentKey { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("parentRatingKey")]
        public string ParentRatingKey { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("parentThumb")]
        public string ParentThumb { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("parentTitle")]
        public string ParentTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("rating")]
        public string Rating { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("ratingKey")]
        public string RatingKey { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("sessionKey")]
        public string SessionKey { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("updatedAt")]
        public string UpdatedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("viewOffset")]
        public string ViewOffset { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("year")]
        [JsonConverter(typeof(IntValueConverter))]
        public int Year { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Director")]
        public List<Director> Directors { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Writer")]
        public List<Writer> Writers { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Media")]
        public List<Medium> Media { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("User")]
        public User User { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Player")]
        public Player Player { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Session")]
        public SessionDetail SessionDetail { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("TranscodeSession")]
        public TranscodeSession TranscodeSession { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class Player
    {
        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("device")]
        public string Device { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("machineIdentifier")]
        public string MachineIdentifier { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("model")]
        public string Model { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("platformVersion")]
        public string PlatformVersion { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("product")]
        public string Product { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("profile")]
        public string Profile { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("remotePublicAddress")]
        public string RemotePublicAddress { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("vendor")]
        public string Vendor { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("local")]
        public bool Local { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("relayed")]
        public bool Relayed { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("secure")]
        public bool Secure { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("userID")]
        public long UserId { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class SessionDetail
    {
        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("bandwidth")]
        public long Bandwidth { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("location")]
        public string Location { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class TranscodeSession
    {
        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("throttled")]
        public bool Throttled { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("complete")]
        public bool Complete { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(DoubleValueConverter))]
        [JsonPropertyName("progress")]
        public double Progress { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(DoubleValueConverter))]
        [JsonPropertyName("speed")]
        public double Speed { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonConverter(typeof(LongValueConverter))]
        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("context")]
        public string Context { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("sourceVideoCodec")]
        public string SourceVideoCodec { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("sourceAudioCodec")]
        public string SourceAudioCodec { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("videoDecision")]
        public string VideoDecision { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("audioDecision")]
        public string AudioDecision { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("container")]
        public string Container { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("videoCodec")]
        public string VideoCodec { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("audioCodec")]
        public string AudioCodec { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("audioChannels")]
        public long AudioChannels { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("transcodeHwRequested")]
        public bool TranscodeHwRequested { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("transcodeHwFullPipeline")]
        public bool TranscodeHwFullPipeline { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("timeStamp")]
        public string TimeStamp { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("maxOffsetAvailable")]
        public string MaxOffsetAvailable { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("minOffsetAvailable")]
        public string MinOffsetAvailable { get; set; }
    }
}
