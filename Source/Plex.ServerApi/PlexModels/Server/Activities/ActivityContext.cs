namespace Plex.ServerApi.PlexModels.Server.Activities
{
    using System.Text.Json.Serialization;

    public class ActivityContext
    {
        [JsonPropertyName("librarySectionID")]
        public string LibrarySectionId { get; set; }
    }
}
