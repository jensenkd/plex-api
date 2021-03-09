namespace Plex.Api.PlexModels.Server.Releases
{
    using System.Text.Json.Serialization;

    /// <summary>
    ///
    /// </summary>
    public class Release
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("added")]
        public string Added { get; set; }

        [JsonPropertyName("fixed")]
        public string Fixed { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("downloadURL")]
        public string DownloadUrl { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }
    }
}
