namespace Plex.ServerApi.PlexModels.Media
{
    using System.Text.Json.Serialization;

    public class MetadataField
    {
        [JsonPropertyName("locked")]
        public bool Locked { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
