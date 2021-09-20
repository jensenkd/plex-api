namespace Plex.Library.ApiModels.Servers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Automapper;
    using Libraries;
    using ServerApi.Clients.Interfaces;
    using ServerApi.PlexModels.Account;
    using ServerApi.PlexModels.Hubs;
    using ServerApi.PlexModels.Media;
    using ServerApi.PlexModels.Providers;
    using ServerApi.PlexModels.Server;
    using ServerApi.PlexModels.Server.Activities;
    using ServerApi.PlexModels.Server.Devices;
    using ServerApi.PlexModels.Server.History;
    using ServerApi.PlexModels.Server.Playlists;
    using ServerApi.PlexModels.Server.Sessions;
    using ServerApi.PlexModels.Server.Statistics;
    using ServerApi.PlexModels.Server.Transcoders;
    using ServerApi.PlexModels.Server.Updates;
    using LibraryFilter = ServerApi.PlexModels.Library.LibraryFilter;

    /// <summary>
    /// Plex Server Object
    /// </summary>
    public class Server
    {
        private readonly IPlexServerClient plexServerClient;
        private readonly IPlexLibraryClient plexLibraryClient;

        /// <summary>
        ///
        /// </summary>
        /// <param name="plexServerClient">Plex Server Client</param>
        /// <param name="plexLibraryClient">Plex Library Client</param>
        /// <param name="accountServer">Account Server Object</param>
        /// <exception cref="ArgumentNullException">Invalid Account Server</exception>
        public Server(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, AccountServer accountServer)
        {
            this.plexServerClient = plexServerClient ?? throw new ArgumentNullException(nameof(plexServerClient));
            this.plexLibraryClient = plexLibraryClient ?? throw new ArgumentNullException(nameof(plexLibraryClient));

            if (accountServer == null)
            {
                throw new ArgumentNullException(nameof(accountServer));
            }

            // Map AccountServer to this Server Object (Mainly to get Access Token and Host)
            ObjectMapper.Mapper.Map(accountServer, this);

            var serverModel = plexServerClient.GetPlexServerInfo(this.AccessToken, this.Uri.ToString()).Result;

            ObjectMapper.Mapper.Map(serverModel, this);
        }

        /// <summary>
        /// Server Access Token
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Server Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Server Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Server Port
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Server Scheme
        /// </summary>
        public string Scheme { get; set; }

        /// <summary>
        /// Server Host
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Server Local IP Address
        /// </summary>
        public string LocalAddresses { get; set; }

        /// <summary>
        /// Created At DateTime
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Owned { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Synced { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string SourceTitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int OwnerId { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Home { get; set; }

        /// <summary>
        /// Server Uri
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// True if Server allows camera upload.
        /// </summary>
        public bool AllowCameraUpload { get; set; }

        /// <summary>
        /// True if Server allows channel access (iTunes?).
        /// </summary>
        public bool AllowChannelAccess { get; set; }

        /// <summary>
        /// True is Server allows sharing.
        /// </summary>
        public bool AllowSharing { get; set; }

        /// <summary>
        /// True is Server allows sync.
        /// </summary>
        public bool AllowSync { get; set; }

        /// <summary>
        /// True if Server allows TV Tuners
        /// </summary>
        public bool AllowTuners { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool BackgroundProcessing { get; set; }

        /// <summary>
        /// True if Server has an HTTPS certificate.
        /// </summary>
        public bool Certificate { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool CompanionProxy { get; set; }

        /// <summary>
        /// Country Code of Server
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public string Diagnostics { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool EventStream { get; set; }

        /// <summary>
        /// Human friendly name for this server.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// True if Hub Search https://www.plex.tv/blog/seek-plex-shall-find-leveling-web-app is enabled.
        /// I believe this is enabled for everyone
        /// </summary>
        public bool HubSearch { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool ItemClusters { get; set; }

        /// <summary>
        /// True if Server supports Live Tv
        /// </summary>
        public int Livetv { get; set; }

        /// <summary>
        /// Unique ID for this server (looks like an md5).
        /// </summary>
        public string MachineIdentifier { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool MediaProviders { get; set; }

        /// <summary>
        /// True if multiusers https://support.plex.tv/hc/en-us/articles/200250367-Multi-User-Support are enabled.
        /// </summary>
        public bool Multiuser { get; set; }

        /// <summary>
        /// Unknown (True if logged into myPlex?).
        /// </summary>
        public bool MyPlex { get; set; }

        /// <summary>
        /// Unknown (ex: mapped).
        /// </summary>
        public string MyPlexMappingState { get; set; }

        /// <summary>
        /// Unknown (ex: ok).
        /// </summary>
        public string MyPlexSigninState { get; set; }

        /// <summary>
        /// True if you have a myPlex subscription.
        /// </summary>
        public bool MyPlexSubscription { get; set; }

        /// <summary>
        /// Email address if signed into myPlex (user@example.com)
        /// </summary>
        public string MyPlexUsername { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public int OfflineTranscode { get; set; }

        /// <summary>
        /// List of features allowed by the server owner. This may be based
        /// on your PlexPass subscription. Features include: camera_upload, cloudsync,
        /// content_filter, dvr, hardware_transcoding, home, lyrics, music_videos, pass,
        /// photo_autotags, premium_music_metadata, session_bandwidth_restrictions, sync,
        /// trailers, webhooks (and maybe more).
        /// </summary>
        public string OwnerFeatures { get; set; }

        /// <summary>
        /// True if photo auto-tagging https://support.plex.tv/hc/en-us/articles/234976627-Auto-Tagging-of-Photos is enabled.
        /// </summary>
        public bool PhotoAutoTag { get; set; }

        /// <summary>
        /// Platform the server is hosted on (ex: Linux)
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// Platform version (ex: '6.1 (Build 7601)', '4.4.0-59-generic').
        /// </summary>
        public string PlatformVersion { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool PluginHost { get; set; }

        /// <summary>
        /// True if Server Push Notifications are enabled
        /// </summary>
        public bool PushNotifications { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool ReadOnlyLibraries { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool RequestParametersInCookie { get; set; }

        /// <summary>
        /// Current Streaming Brain Abr https://www.plex.tv/blog/mcstreamy-brain-take-world-two-easy-steps version.
        /// </summary>
        public int StreamingBrainAbrVersion { get; set; }

        /// <summary>
        /// Current Streaming Brain https://www.plex.tv/blog/mcstreamy-brain-take-world-two-easy-steps version.
        /// </summary>
        public int StreamingBrainVersion { get; set; }

        /// <summary>
        /// True if syncing to a device https://support.plex.tv/hc/en-us/articles/201053678-Sync-Media-to-a-Device is enabled.
        /// </summary>
        public bool Sync { get; set; }

        /// <summary>
        /// Number of active video transcoding sessions.
        /// </summary>
        public int TranscoderActiveVideoSessions { get; set; }

        /// <summary>
        /// True if audio transcoding audio is available.
        /// </summary>
        public bool TranscoderAudio { get; set; }

        /// <summary>
        /// True if audio transcoding lyrics is available.
        /// </summary>
        public bool TranscoderLyrics { get; set; }

        /// <summary>
        /// True if audio transcoding photos is available.
        /// </summary>
        public bool TranscoderPhoto { get; set; }

        /// <summary>
        /// True if audio transcoding subtitles is available.
        /// </summary>
        public bool TranscoderSubtitles { get; set; }

        /// <summary>
        /// True if audio transcoding video is available.
        /// </summary>
        public bool TranscoderVideo { get; set; }

        /// <summary>
        /// List of video bitrates.
        /// </summary>
        public string TranscoderVideoBitrates { get; set; }

        /// <summary>
        /// List of video qualities.
        /// </summary>
        public string TranscoderVideoQualities { get; set; }

        /// <summary>
        /// List of video resolutions.
        /// </summary>
        public string TranscoderVideoResolutions { get; set; }

        /// <summary>
        /// Datetime the server was updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Unknown
        /// </summary>
        public bool Updater { get; set; }

        /// <summary>
        /// Current Plex version (ex: 1.3.2.3112-1751929)
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// True if voice search is enabled. (is this Google Voice search?)
        /// </summary>
        public bool VoiceSearch { get; set; }

        /// <summary>
        /// File Directories on Server
        /// </summary>
        public List<PlexServerDirectory> Directories { get; set; }

        /// <summary>
        /// Get Libraries
        /// </summary>
        /// <param name="filter">Library Filter (Optional)</param>
        /// <exception cref="ApplicationException">Invalid Library Exception</exception>
        /// <returns>List of Library Objects</returns>
        public async Task<List<LibraryBase>> Libraries(LibraryFilter filter = null)
        {
            var libraries = new List<LibraryBase>();
            var summary = await this.plexServerClient.GetLibrariesAsync(this.AccessToken, this.Uri.ToString());
            foreach (var library in summary.Libraries)
            {
                switch (library.Type.ToUpper(CultureInfo.InvariantCulture))
                {
                    case "MOVIE":
                        var movieLibrary = new MovieLibrary(this.plexServerClient, this.plexLibraryClient, this);
                        ObjectMapper.Mapper.Map(library, movieLibrary);
                        var movieFilterContainer = await this.plexLibraryClient.GetLibraryFilters(this.AccessToken, this.Uri.ToString(),
                            library.Key);
                        libraries.Add(movieLibrary);
                        break;
                    case "SHOW":
                        var showLibrary = new ShowLibrary(this.plexServerClient, this.plexLibraryClient, this);
                        ObjectMapper.Mapper.Map(library, showLibrary);
                        var showFilterContainer = await this.plexLibraryClient.GetLibraryFilters(this.AccessToken, this.Uri.ToString(),
                            showLibrary.Key);
                        libraries.Add(showLibrary);
                        break;
                    case "ARTIST":
                        var musicLibrary = new MusicLibrary(this.plexServerClient, this.plexLibraryClient, this);
                        ObjectMapper.Mapper.Map(library, musicLibrary);
                        var musicFilterContainer = await this.plexLibraryClient.GetLibraryFilters(this.AccessToken, this.Uri.ToString(),
                            musicLibrary.Key);
                        libraries.Add(musicLibrary);
                        break;
                    case "PHOTO":
                        var photoLibrary = new PhotoLibrary(this.plexServerClient, this.plexLibraryClient, this);
                        ObjectMapper.Mapper.Map(library, photoLibrary);
                        var photoFilterContainer = await this.plexLibraryClient.GetLibraryFilters(this.AccessToken, this.Uri.ToString(),
                            photoLibrary.Key);
                        libraries.Add(photoLibrary);
                        break;
                    default:
                        throw new ApplicationException("Invalid Library Type");
                }
            }

            if (filter != null)
            {
                if (filter.Keys.Count > 0)
                {
                    libraries = libraries
                        .Where(c => filter.Keys.Contains(c.Key, StringComparer.OrdinalIgnoreCase))
                        .ToList();
                }

                if (filter.Titles.Count > 0)
                {
                    libraries = libraries
                        .Where(c => filter.Titles.Contains(c.Title, StringComparer.OrdinalIgnoreCase))
                        .ToList();
                }

                if (filter.Types.Count > 0)
                {
                    libraries = libraries
                        .Where(c => filter.Types.Contains(c.Type, StringComparer.OrdinalIgnoreCase))
                        .ToList();
                }
            }

            return libraries;
        }

        // Hubs
        /// <summary>
        /// Get Home OnDeck items
        /// </summary>
        /// <param name="start">Start record</param>
        /// <param name="count">Max Number of items to retrieve</param>
        /// <returns></returns>
        public async Task<MediaContainer> HomeOnDeck(int start = 0, int count = 10) =>
            await this.plexServerClient.GetHomeOnDeckAsync(this.AccessToken, this.Uri.ToString(), start, count);

        /// <summary>
        /// Get Recently Added items for the Home Hub
        /// </summary>
        /// <param name="start">Start record</param>
        /// <param name="count">Max Number of items to retrieve</param>
        /// <returns></returns>
        public async Task<MediaContainer> HomeHubRecentlyAdded(int start = 0, int count = 10) =>
            await this.plexServerClient.GetHomeRecentlyAddedAsync(this.AccessToken, this.Uri.ToString(), start, count);

        /// <summary>
        /// Get Continue Watching items for the Home Hub
        /// </summary>
        /// <param name="start">Start record</param>
        /// <param name="count">Max Number of items to retrieve</param>
        /// <returns></returns>
        public async Task<MediaContainer> HomeHubContinueWatching(int start = 0, int count = 10) =>
            await this.plexServerClient.GetHomeContinueWatchingAsync(this.AccessToken, this.Uri.ToString(), start, count);

        /// <summary>
        /// Share library content with the specified user.
        /// </summary>
        /// <param name="user">username, email of the user to be added.</param>
        /// <param name="sections">Library sections, names or ids to be shared (default None). [Section] must be defined in order to update shared sections.</param>
        /// <param name="allowSync">Set True to allow user to sync content.</param>
        /// <param name="allowCameraUpload">Set True to allow user to upload photos.</param>
        /// <param name="allowChannels">Set True to allow user to utilize installed channels.</param>
        /// <param name="filterMovies">Dict containing key 'contentRating' and/or 'label' each set to a list of values to be filtered. ex: {'contentRating':['G'], 'label':['foo']}</param>
        /// <param name="filterTelevision">Dict containing key 'contentRating' and/or 'label' each set to a list of values to be filtered. ex: {'contentRating':['G'], 'label':['foo']}</param>
        /// <param name="filterMusic">Dict containing key 'label' set to a list of values to be filtered. ex: {'label':['foo']}</param>
        /// <returns></returns>
        public async void InviteFriend(string user, string sections = "None", bool allowSync = false,
            bool allowCameraUpload = false, bool allowChannels = false, string filterMovies = "None", string filterTelevision = "None",
            string filterMusic = "None") =>
            await this.plexServerClient.InviteFriend(this.AccessToken, this.Uri.ToString(), sections, allowSync, allowCameraUpload,
                allowChannels, filterMovies, filterTelevision, filterMusic);

        /// <summary>
        /// Get Providers for this Server
        /// </summary>
        /// <returns>ProviderContainer</returns>
        public async Task<ProviderContainer> Providers() =>
            await this.plexServerClient.GetServerProvidersAsync(this.AccessToken, this.Uri.ToString());

        /// <summary>
        /// Search Across All Hubs on this Server
        /// </summary>
        /// <param name="title">Title</param>
        /// <returns></returns>
        public async Task<HubMediaContainer> HubLibrarySearch(string title) =>
            await this.plexLibraryClient.HubLibrarySearch(this.AccessToken, this.Uri.ToString(), title);

        /// <summary>
        /// Get Play History for all library sections on this Server.
        /// </summary>
        /// <param name="start">Starting record</param>
        /// <param name="count">Only return the specified number of results (optional)</param>
        /// <param name="minDate">Min datetime to return results from.</param>
        /// <returns></returns>
        public async Task<HistoryMediaContainer> PlayHistory(int start = 0, int count = 100, DateTime? minDate = null) =>
            await this.plexServerClient.GetPlayHistory(this.AccessToken, this.Uri.ToString(), start, count, minDate);

        /// <summary>
        /// Get Devices connected to this Server
        /// </summary>
        /// <returns>DeviceContainer</returns>
        public async Task<DeviceContainer> Devices() =>
            await this.plexServerClient.GetDevices(this.AccessToken, this.Uri.ToString());

        /// <summary>
        /// Get list of all Client objects connected to server.
        /// </summary>
        /// <returns></returns>
        public async Task<object> Clients() =>
            await this.plexServerClient.GetClients(this.AccessToken, this.Uri.ToString());

        /// <summary>
        /// Scrobble Item on Server
        /// </summary>
        /// <param name="ratingKey">Rating Key</param>
        public async Task ScrobbleItem(string ratingKey) =>
            await this.plexServerClient.ScrobbleItemAsync(this.AccessToken, this.Uri.ToString(), ratingKey);

        /// <summary>
        /// Unscrobble Item on Server
        /// </summary>
        /// <param name="ratingKey">Rating Key</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task UnScrobbleItem(string ratingKey) =>
            await this.plexServerClient.UnScrobbleItemAsync(this.AccessToken, this.Uri.ToString(), ratingKey);

        /// <summary>
        /// Downloads Server Logs
        /// </summary>
        /// <returns></returns>
        public async Task<object> DownloadLogs() =>
            await this.plexServerClient.GetLogs(this.AccessToken, this.Uri.ToString());

        /// <summary>
        /// Get list of all release updates available for this Server
        /// </summary>
        /// <returns>ReleaseContainer.</returns>
        public async Task<UpdateContainer> CheckForUpdate() =>
            await this.plexServerClient.CheckForUpdate(this.AccessToken, this.Uri.ToString());

        /// <summary>
        /// Get Server Activities.
        /// </summary>
        /// <returns>ActivityContainer</returns>
        public async Task<ActivityContainer> Activities() =>
            await this.plexServerClient.GetActivities(this.AccessToken, this.Uri.ToString());

        /// <summary>
        /// Get Server Statistics
        /// </summary>
        /// <returns>StatisticContainer</returns>
        public async Task<StatisticContainer> Statistics() =>
            await this.plexServerClient.GetStatistics(this.AccessToken, this.Uri.ToString());

        /// <summary>
        /// Force Plex Server to download new SyncList from Plex.tv.
        /// </summary>
        /// <returns></returns>
        public async Task RefreshSyncList() =>
            await this.plexServerClient.RefreshSyncList(this.AccessToken, this.Uri.ToString());

        /// <summary>
        /// Force Plex Server to refresh content for known SyncLists.
        /// </summary>
        /// <returns></returns>
        public async Task RefreshContent() =>
            await this.plexServerClient.RefreshSyncList(this.AccessToken, this.Uri.ToString());

        /// <summary>
        /// Force Plex Server to download new SyncList and refresh content.
        /// </summary>
        /// <returns></returns>
        public async Task RefreshSync()
        {
            await this.RefreshSyncList();
            await this.RefreshContent();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<TranscodeContainer> TranscodeSessions() =>
            await this.plexServerClient.GetTranscodeSessions(this.AccessToken, this.Uri.ToString());

        /// <summary>
        /// Get Server active Sessions
        /// </summary>
        /// <returns></returns>
        public async Task<SessionContainer> Sessions() =>
            await this.plexServerClient.GetSessionsAsync(this.AccessToken, this.Uri.ToString());

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<PlaylistContainer> Playlists() =>
            await this.plexServerClient.GetPlaylists(this.AccessToken, this.Uri.ToString());
    }
}
