using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Plex.Api.Models
{
    /// <summary>
    ///
    /// </summary>
    public class MediaContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MediaContainer"/> class.
        /// </summary>
        /// <param name="photoAutoTag"></param>
        public MediaContainer(bool photoAutoTag)
        {
            this.PhotoAutoTag = photoAutoTag;
        }

        /// <summary>
        ///
        /// </summary>
        public int TotalSize { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool AllowSync { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int LibrarySectionId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string LibrarySectionTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string LibrarySectionUuid { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string MediaTagPrefix { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int MediaTagVersion { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Metadata")]
        public List<Metadata> Metadata { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Art { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool Nocache { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Thumb { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title1 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Title2 { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ViewGroup { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ViewMode { get; set; }

        //TV Show Seasons
        /// <summary>
        ///
        /// </summary>
        public string Banner { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ParentIndex { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ParentTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int ParentYear { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool SortAsc { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Theme { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonPropertyName("Directory")]
        public List<Directory> Directory { get; set; }

        //TV Show Episode
        /// <summary>
        ///
        /// </summary>
        public string GrandparentContentRating { get; set; }
        /// <summary>
        ///
        /// </summary>
        public int GrandparentRatingKey { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string GrandparentStudio { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string GrandparentTheme { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string GrandparentThumb { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string GrandparentTitle { get; set; }

         //Plex Status
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
        public bool HubSearch { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool ItemClusters { get; set; }
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
        public bool MediaProviders { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool Multiuser { get; set; }
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
        public bool ReadOnlyLibraries { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool RequestParametersInCookie { get; set; }
        /// <summary>
        ///
        /// </summary>
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
        public bool TranscoderPhoto { get; set; }
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
        public long CreatedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool Updater { get; set; }
        /// <summary>
        ///
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        ///
        /// </summary>
        public bool VoiceSearch { get; set; }
    }
}
