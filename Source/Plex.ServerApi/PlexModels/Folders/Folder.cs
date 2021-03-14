namespace Plex.ServerApi.PlexModels.Folders
{
    using System.Text.Json.Serialization;

    public class Folder
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
