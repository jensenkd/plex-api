namespace Plex.ServerApi.PlexModels.Providers
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class ProviderContainer
    {
        /// <summary>
        /// Size
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool AllowCameraUpload { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool AllowChannelAccess { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool AllowSharing { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool AllowSync { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool AllowTuners { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool BackgroundProcessing { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool Certificate { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool CompanionProxy { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Diagnostics { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool EventStream { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int LiveTv { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MachineIdentifier { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool MyPlex { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MyPlexMappingState { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MyPlexSigninState { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool MyPlexSubscription { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MyPlexUsername { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int OfflineTranscode { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string OwnerFeatures { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool PhotoAutoTag { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string PlatformVersion { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool PluginHost { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool PushNotifications { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool ReadOnlyLibraries { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("streamingBrainABRVersion")]
        public int StreamingBrainAbrVersion { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int StreamingBrainVersion { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool Sync { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int TranscoderActiveVideoSessions { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool TranscoderAudio { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool TranscoderLyrics { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool TranscoderSubtitles { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool TranscoderVideo { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string TranscoderVideoBitrates { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string TranscoderVideoQualities { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string TranscoderVideoResolutions { get; set; }

        /// <summary>
        ///
        /// </summary>
        public long UpdatedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public bool Updater { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool VoiceSearch { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("MediaProvider")]
        public List<Provider> Providers { get; set; } = new List<Provider>();
    }
}
