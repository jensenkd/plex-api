namespace Plex.Api.PlexModels.Server.Activities
{
    using System.Text.Json.Serialization;

    public class ActivityContext
    {
        [JsonPropertyName("librarySectionID")]
        public string LibrarySectionID { get; set; }
    }
}
