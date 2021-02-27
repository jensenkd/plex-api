namespace Plex.Api.PlexModels.Library
{
    using System.Text.Json.Serialization;
    using Models;

    public class LibraryContainer
    {
        /// <summary>
        /// Media Container
        /// </summary>
        [JsonPropertyName("MediaContainer")]
        public MediaContainer LibraryContainer { get; set; }
    }
}
