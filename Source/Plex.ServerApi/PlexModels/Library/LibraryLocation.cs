namespace Plex.ServerApi.PlexModels.Library
{
    using System.Text.Json.Serialization;

    public class LibraryLocation    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }
    }
}
