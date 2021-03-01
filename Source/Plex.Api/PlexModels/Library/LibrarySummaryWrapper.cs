namespace Plex.Api.PlexModels.Library
{
    using System.Text.Json.Serialization;

    public class LibrarySummaryWrapper
    {
        /// <summary>
        /// Media Container
        /// </summary>
        [JsonPropertyName("MediaContainer")]
        public LibrarySummary LibrarySummary { get; set; }
    }
}
