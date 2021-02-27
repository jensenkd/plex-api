namespace Plex.Api.PlexModels.Server
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class PlexServer
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("allowCameraUpload")]
        public bool AllowCameraUpload { get; set; }

        [JsonPropertyName("allowChannelAccess")]
        public bool AllowChannelAccess { get; set; }

        [JsonPropertyName("allowSharing")]
        public bool AllowSharing { get; set; }

        [JsonPropertyName("allowSync")]
        public bool AllowSync { get; set; }

        [JsonPropertyName("allowTuners")]
        public bool AllowTuners { get; set; }

        [JsonPropertyName("backgroundProcessing")]
        public bool BackgroundProcessing { get; set; }

        [JsonPropertyName("certificate")]
        public bool Certificate { get; set; }

        [JsonPropertyName("companionProxy")]
        public bool CompanionProxy { get; set; }

        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }

        [JsonPropertyName("diagnostics")]
        public string Diagnostics { get; set; }

        [JsonPropertyName("eventStream")]
        public bool EventStream { get; set; }

        [JsonPropertyName("friendlyName")]
        public string FriendlyName { get; set; }

        [JsonPropertyName("hubSearch")]
        public bool HubSearch { get; set; }

        [JsonPropertyName("itemClusters")]
        public bool ItemClusters { get; set; }

        [JsonPropertyName("livetv")]
        public int Livetv { get; set; }

        [JsonPropertyName("machineIdentifier")]
        public string MachineIdentifier { get; set; }

        [JsonPropertyName("mediaProviders")]
        public bool MediaProviders { get; set; }

        [JsonPropertyName("multiuser")]
        public bool Multiuser { get; set; }

        [JsonPropertyName("myPlex")]
        public bool MyPlex { get; set; }

        [JsonPropertyName("myPlexMappingState")]
        public string MyPlexMappingState { get; set; }

        [JsonPropertyName("myPlexSigninState")]
        public string MyPlexSigninState { get; set; }

        [JsonPropertyName("myPlexSubscription")]
        public bool MyPlexSubscription { get; set; }

        [JsonPropertyName("myPlexUsername")]
        public string MyPlexUsername { get; set; }

        [JsonPropertyName("offlineTranscode")]
        public int OfflineTranscode { get; set; }

        [JsonPropertyName("ownerFeatures")]
        public string OwnerFeatures { get; set; }

        [JsonPropertyName("photoAutoTag")]
        public bool PhotoAutoTag { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        [JsonPropertyName("platformVersion")]
        public string PlatformVersion { get; set; }

        [JsonPropertyName("pluginHost")]
        public bool PluginHost { get; set; }

        [JsonPropertyName("pushNotifications")]
        public bool PushNotifications { get; set; }

        [JsonPropertyName("readOnlyLibraries")]
        public bool ReadOnlyLibraries { get; set; }

        [JsonPropertyName("requestParametersInCookie")]
        public bool RequestParametersInCookie { get; set; }

        [JsonPropertyName("streamingBrainABRVersion")]
        public int StreamingBrainAbrVersion { get; set; }

        [JsonPropertyName("streamingBrainVersion")]
        public int StreamingBrainVersion { get; set; }

        [JsonPropertyName("sync")]
        public bool Sync { get; set; }

        [JsonPropertyName("transcoderActiveVideoSessions")]
        public int TranscoderActiveVideoSessions { get; set; }

        [JsonPropertyName("transcoderAudio")]
        public bool TranscoderAudio { get; set; }

        [JsonPropertyName("transcoderLyrics")]
        public bool TranscoderLyrics { get; set; }

        [JsonPropertyName("transcoderPhoto")]
        public bool TranscoderPhoto { get; set; }

        [JsonPropertyName("transcoderSubtitles")]
        public bool TranscoderSubtitles { get; set; }

        [JsonPropertyName("transcoderVideo")]
        public bool TranscoderVideo { get; set; }

        [JsonPropertyName("transcoderVideoBitrates")]
        public string TranscoderVideoBitrates { get; set; }

        [JsonPropertyName("transcoderVideoQualities")]
        public string TranscoderVideoQualities { get; set; }

        [JsonPropertyName("transcoderVideoResolutions")]
        public string TranscoderVideoResolutions { get; set; }

        [JsonPropertyName("updatedAt")]
        public int UpdatedAt { get; set; }

        [JsonPropertyName("updater")]
        public bool Updater { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("voiceSearch")]
        public bool VoiceSearch { get; set; }

        [JsonPropertyName("Directory")]
        public List<PlexServerDirectory> Directories { get; set; }
    }
}
