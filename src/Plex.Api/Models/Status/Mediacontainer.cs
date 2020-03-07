namespace Plex.Api.Models.Status
{
    public class Mediacontainer
    {
        public int Size { get; set; }
        public bool AllowCameraUpload { get; set; }
        public bool AllowChannelAccess { get; set; }
        public bool AllowMediaDeletion { get; set; }
        public bool AllowSharing { get; set; }
        public bool AllowSync { get; set; }
        public bool BackgroundProcessing { get; set; }
        public bool Certificate { get; set; }
        public bool CompanionProxy { get; set; }
        public string CountryCode { get; set; }
        public string Diagnostics { get; set; }
        public bool EventStream { get; set; }
        public string FriendlyName { get; set; }
        public bool HubSearch { get; set; }
        public bool ItemClusters { get; set; }
        public string MachineIdentifier { get; set; }
        public bool MediaProviders { get; set; }
        public bool Multiuser { get; set; }
        public bool MyPlex { get; set; }
        public string MyPlexMappingState { get; set; }
        public string MyPlexSigninState { get; set; }
        public bool MyPlexSubscription { get; set; }
        public string MyPlexUsername { get; set; }
        public bool PhotoAutoTag { get; set; }
        public string Platform { get; set; }
        public string PlatformVersion { get; set; }
        public bool PluginHost { get; set; }
        public bool ReadOnlyLibraries { get; set; }
        public bool RequestParametersInCookie { get; set; }
        public int StreamingBrainVersion { get; set; }
        public bool Sync { get; set; }
        public int TranscoderActiveVideoSessions { get; set; }
        public bool TranscoderAudio { get; set; }
        public bool TranscoderLyrics { get; set; }
        public bool TranscoderPhoto { get; set; }
        public bool TranscoderSubtitles { get; set; }
        public bool TranscoderVideo { get; set; }
        public string TranscoderVideoBitrates { get; set; }
        public string TranscoderVideoQualities { get; set; }
        public string TranscoderVideoResolutions { get; set; }
        public int UpdatedAt { get; set; }
        public bool Updater { get; set; }
        public string Version { get; set; }
        public bool VoiceSearch { get; set; }
        public Directory[] Directory { get; set; }
    }
}