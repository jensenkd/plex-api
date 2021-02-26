using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    /// <summary>
    /// Media Container Object
    /// </summary>
    public class MediaContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaContainer"/> class.
        /// </summary>
        /// <param name="photoAutoTag">Photo Auto Tag?</param>
        public MediaContainer(bool photoAutoTag) => this.PhotoAutoTag = photoAutoTag;

        /// <summary>
        /// Total Size
        /// </summary>
        public int TotalSize { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Allow Sync?
        /// </summary>
        public bool AllowSync { get; set; }

        /// <summary>
        /// Identifier
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Library Section Id
        /// </summary>
        public int LibrarySectionId { get; set; }

        /// <summary>
        /// Library Section Title
        /// </summary>
        public string LibrarySectionTitle { get; set; }

        /// <summary>
        /// Library Section Uuid
        /// </summary>
        public string LibrarySectionUuid { get; set; }

        /// <summary>
        /// Media Tag Prefix
        /// </summary>
        public string MediaTagPrefix { get; set; }

        /// <summary>
        /// Media Tag Version
        /// </summary>
        public int MediaTagVersion { get; set; }

        /// <summary>
        /// Metadata Items
        /// </summary>
        [JsonPropertyName("Metadata")]
        public List<Metadata> Metadata { get; set; }

        /// <summary>
        /// Art
        /// </summary>
        public string Art { get; set; }

        /// <summary>
        /// Nocache?
        /// </summary>
        public bool Nocache { get; set; }

        /// <summary>
        /// Thumbnail
        /// </summary>
        public string Thumb { get; set; }

        /// <summary>
        /// Title 1
        /// </summary>
        public string Title1 { get; set; }

        /// <summary>
        /// Title 2
        /// </summary>
        public string Title2 { get; set; }

        /// <summary>
        /// View Group
        /// </summary>
        public string ViewGroup { get; set; }

        /// <summary>
        /// View Mode
        /// </summary>
        public int ViewMode { get; set; }

        //TV Show Seasons
        /// <summary>
        /// Banner
        /// </summary>
        public string Banner { get; set; }

        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Parent Index
        /// </summary>
        public int ParentIndex { get; set; }

        /// <summary>
        /// Parent Title
        /// </summary>
        public string ParentTitle { get; set; }

        /// <summary>
        /// Parent Year
        /// </summary>
        public int ParentYear { get; set; }

        /// <summary>
        /// Sort Asc?
        /// </summary>
        public bool SortAsc { get; set; }

        /// <summary>
        /// Summary
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Theme
        /// </summary>
        public string Theme { get; set; }

        /// <summary>
        /// Directory Items
        /// </summary>
        [JsonPropertyName("Directory")]
        public List<Directory> Directory { get; set; }

        //TV Show Episode
        /// <summary>
        /// Grandparent Content Rating
        /// </summary>
        public string GrandparentContentRating { get; set; }

        /// <summary>
        /// Grandparent Rating Key
        /// </summary>
        public int GrandparentRatingKey { get; set; }

        /// <summary>
        /// Grandparent Studio
        /// </summary>
        public string GrandparentStudio { get; set; }

        /// <summary>
        /// Grandparent Theme
        /// </summary>
        public string GrandparentTheme { get; set; }

        /// <summary>
        /// Grandparent Thumbnail
        /// </summary>
        public string GrandparentThumb { get; set; }

        /// <summary>
        /// Grandparent Title
        /// </summary>
        public string GrandparentTitle { get; set; }

         //Plex Status
        /// <summary>
        /// Allow Camera Upload?
        /// </summary>
        public bool AllowCameraUpload { get; set; }

        /// <summary>
        /// Allow Channel Access?
        /// </summary>
        public bool AllowChannelAccess { get; set; }

        /// <summary>
        /// Allow Sharing?
        /// </summary>
        public bool AllowSharing { get; set; }

        /// <summary>
        /// Allow Tuners?
        /// </summary>
        public bool AllowTuners { get; set; }

        /// <summary>
        /// Background Processing?
        /// </summary>
        public bool BackgroundProcessing { get; set; }

        /// <summary>
        /// Certificate?
        /// </summary>
        public bool Certificate { get; set; }

        /// <summary>
        /// Companion Proxy?
        /// </summary>
        public bool CompanionProxy { get; set; }

        /// <summary>
        /// Country Code
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Diagnostics
        /// </summary>
        public string Diagnostics { get; set; }

        /// <summary>
        /// Event Stream?
        /// </summary>
        public bool EventStream { get; set; }

        /// <summary>
        /// Friendly Name
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Hub Search
        /// </summary>
        public bool HubSearch { get; set; }

        /// <summary>
        /// Item Clusters?
        /// </summary>
        public bool ItemClusters { get; set; }

        /// <summary>
        /// Live TV
        /// </summary>
        public int LiveTv { get; set; }

        /// <summary>
        /// Machine Identifier
        /// </summary>
        public string MachineIdentifier { get; set; }

        /// <summary>
        /// Media Providers?
        /// </summary>
        public bool MediaProviders { get; set; }

        /// <summary>
        /// Multi-user?
        /// </summary>
        public bool Multiuser { get; set; }

        /// <summary>
        /// My Plex?
        /// </summary>
        public bool MyPlex { get; set; }

        /// <summary>
        /// My Plex Mapping State
        /// </summary>
        public string MyPlexMappingState { get; set; }

        /// <summary>
        /// My Plex Signin State
        /// </summary>
        public string MyPlexSigninState { get; set; }

        /// <summary>
        /// My Plex Subscription
        /// </summary>
        public bool MyPlexSubscription { get; set; }

        /// <summary>
        /// My Plex Username
        /// </summary>
        public string MyPlexUsername { get; set; }

        /// <summary>
        /// Owner Feature
        /// </summary>
        public string OwnerFeatures { get; set; }

        /// <summary>
        /// Photo Auto Tag?
        /// </summary>
        public bool PhotoAutoTag { get; set; }

        /// <summary>
        /// Platform
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Platform Version
        /// </summary>
        public string PlatformVersion { get; set; }

        /// <summary>
        /// Plugin Host?
        /// </summary>
        public bool PluginHost { get; set; }

        /// <summary>
        /// Readonly Libraries?
        /// </summary>
        public bool ReadOnlyLibraries { get; set; }

        /// <summary>
        /// Request Parameters in Cookie?
        /// </summary>
        public bool RequestParametersInCookie { get; set; }

        /// <summary>
        /// Streaming Brain ABR Version
        /// </summary>
        public int StreamingBrainAbrVersion { get; set; }

        /// <summary>
        /// Streaming Brain Version
        /// </summary>
        public int StreamingBrainVersion { get; set; }

        /// <summary>
        /// Sync?
        /// </summary>
        public bool Sync { get; set; }

        /// <summary>
        /// Transcoder Active Video Sessions
        /// </summary>
        public int TranscoderActiveVideoSessions { get; set; }

        /// <summary>
        /// Transcoder Audio?
        /// </summary>
        public bool TranscoderAudio { get; set; }

        /// <summary>
        /// Transcoder Lyrics?
        /// </summary>
        public bool TranscoderLyrics { get; set; }

        /// <summary>
        /// Transcoder Photo?
        /// </summary>
        public bool TranscoderPhoto { get; set; }

        /// <summary>
        /// Transcoder Subtitles?
        /// </summary>
        public bool TranscoderSubtitles { get; set; }

        /// <summary>
        /// Transcoder Video?
        /// </summary>
        public bool TranscoderVideo { get; set; }

        /// <summary>
        /// Transcoder Video Bitrates
        /// </summary>
        public string TranscoderVideoBitrates { get; set; }

        /// <summary>
        /// Transcoder Video Qualities
        /// </summary>
        public string TranscoderVideoQualities { get; set; }

        /// <summary>
        /// Transcoder Video Resolutions
        /// </summary>
        public string TranscoderVideoResolutions { get; set; }

        /// <summary>
        /// Updated At
        /// </summary>
        public long UpdatedAt { get; set; }

        /// <summary>
        /// Created At
        /// </summary>
        public long CreatedAt { get; set; }


        /// <summary>
        /// Updater?
        /// </summary>
        public bool Updater { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Voice Search?
        /// </summary>
        public bool VoiceSearch { get; set; }
    }
}
