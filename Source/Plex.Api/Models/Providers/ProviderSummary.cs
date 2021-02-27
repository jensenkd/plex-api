namespace Plex.Api.Models.Providers
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ProviderSummary
    {
        public int Size { get; set; }
        public bool AllowCameraUpload { get; set; }
        public bool AllowChannelAccess { get; set; }
        public bool AllowSharing { get; set; }
        public bool AllowSync { get; set; }
        public bool AllowTuners { get; set; }
        public bool BackgroundProcessing { get; set; }
        public bool Certificate { get; set; }
        public bool CompanionProxy { get; set; }
        public string CountryCode { get; set; }
        public string Diagnostics { get; set; }
        public bool EventStream { get; set; }
        public string FriendlyName { get; set; }
        public int LiveTv { get; set; }
        public string MachineIdentifier { get; set; }
        public bool MyPlex { get; set; }
        public string MyPlexMappingState { get; set; }
        public string MyPlexSigninState { get; set; }
        public bool MyPlexSubscription { get; set; }
        public string MyPlexUsername { get; set; }
        public int OfflineTranscode { get; set; }
        public string OwnerFeatures { get; set; }
        public bool PhotoAutoTag { get; set; }
        public string Platform { get; set; }
        public string PlatformVersion { get; set; }
        public bool PluginHost { get; set; }
        public bool PushNotifications { get; set; }
        public bool ReadOnlyLibraries { get; set; }

        [JsonPropertyName("streamingBrainABRVersion")]
        public int StreamingBrainAbrVersion { get; set; }

        public int StreamingBrainVersion { get; set; }
        public bool Sync { get; set; }
        public int TranscoderActiveVideoSessions { get; set; }
        public bool TranscoderAudio { get; set; }
        public bool TranscoderLyrics { get; set; }
        public bool TranscoderSubtitles { get; set; }
        public bool TranscoderVideo { get; set; }
        public string TranscoderVideoBitrates { get; set; }
        public string TranscoderVideoQualities { get; set; }
        public string TranscoderVideoResolutions { get; set; }
        public int UpdatedAt { get; set; }
        public bool Updater { get; set; }
        public string Version { get; set; }
        public bool VoiceSearch { get; set; }

        [JsonPropertyName("MediaProvider")]
        public List<Provider> Providers { get; set; } = new List<Provider>();
    }
}
