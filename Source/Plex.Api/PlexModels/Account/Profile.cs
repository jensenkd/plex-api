namespace Plex.Api.PlexModels.Account
{
    using System.Text.Json.Serialization;

    public class Profile
    {
        [JsonPropertyName("autoSelectAudio")]
        public bool AutoSelectAudio { get; set; }

        [JsonPropertyName("defaultAudioLanguage")]
        public string DefaultAudioLanguage { get; set; }

        [JsonPropertyName("defaultSubtitleLanguage")]
        public string DefaultSubtitleLanguage { get; set; }

        [JsonPropertyName("autoSelectSubtitle")]
        public int AutoSelectSubtitle { get; set; }

        [JsonPropertyName("defaultSubtitleAccessibility")]
        public int DefaultSubtitleAccessibility { get; set; }

        [JsonPropertyName("defaultSubtitleForced")]
        public int DefaultSubtitleForced { get; set; }
    }
}
