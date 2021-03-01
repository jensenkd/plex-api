namespace Plex.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Automapper;
    using Clients;
    using PlexModels.Hubs;
    using PlexModels.Library;
    using PlexModels.Library.Search;
    using PlexModels.Media;
    using PlexModels.Providers;
    using PlexModels.Server;
    using ResourceModels;
    using LibraryFilter = PlexModels.Library.LibraryFilter;

    public class Server
    {
        private readonly IPlexServerClient plexServerClient;
        private readonly IPlexLibraryClient plexLibraryClient;
        private readonly string hostUrl;
        private readonly string accessToken;

        public Server(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, string authToken, string serverUrl)
        {
            if (string.IsNullOrEmpty(authToken))
            {
                throw new ArgumentNullException(nameof(authToken));
            }

            if (string.IsNullOrEmpty(serverUrl))
            {
                throw new ArgumentNullException(nameof(serverUrl));
            }

            this.plexServerClient = plexServerClient ?? throw new ArgumentNullException(nameof(plexServerClient));
            this.plexLibraryClient = plexLibraryClient ?? throw new ArgumentNullException(nameof(plexLibraryClient));

            //Connect to server and populate
            var server = plexServerClient.GetPlexServerInfo(authToken, serverUrl).Result;
            this.hostUrl = serverUrl;
            this.accessToken = authToken;
            ObjectMapper.Mapper.Map(server, this);
        }



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
        public int UpdatedAt { get; set; }

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

        // Methods

        /// <summary>
        /// Get Server Library Summary (Including Libraries)
        /// </summary>
        /// <returns>Library Summary Object</returns>
        public async Task<LibrarySummary> GetLibrarySummary()
        {
            var summary = await this.plexServerClient.GetLibrarySummaryAsync( this.accessToken, this.hostUrl);
            return summary;
        }

        /// <summary>
        /// Get Libraries Filtered by optional Library Filter (Key, Type, Title)
        /// </summary>
        /// <param name="filter">Library Filter</param>
        /// <returns>List of Library Objects</returns>
        public async Task<List<Library>> GetLibraries(LibraryFilter filter = null)
        {
            var summary = await this.plexServerClient.GetLibrarySummaryAsync( this.accessToken, this.hostUrl);

            var libraries = summary.Libraries;

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

        /// <summary>
        /// Get Media Items for Given Library
        /// </summary>
        /// <param name="key">Library Key</param>
        /// <returns>List of Media Objects</returns>
        public async Task<List<Metadata>> GetLibraryMetadata(string key)
        {
            var mediaContainer = await this.plexServerClient.GetMetadataForLibraryAsync(this.accessToken, this.hostUrl, key);
            return mediaContainer.Media;
        }

        public async Task<Metadata> GetMediaMetadata(string ratingKey) =>
            await this.plexServerClient.GetMediaMetadataAsync(this.accessToken, this.hostUrl, ratingKey);

        public async Task EmptyTrashForLibrary(string key) =>
            await this.plexLibraryClient.EmptyTrash(this.accessToken, this.hostUrl, key);

        public async Task ScanLibraryForNewItems(string key) =>
            await this.plexLibraryClient.ScanForNewItems(this.accessToken, this.hostUrl, key);

        public async Task CancelLibraryScan(string key) =>
            await this.plexLibraryClient.CancelScanForNewItems(this.accessToken, this.hostUrl, key);

        // GetAllMedia() //Get All Media From All Sections
        // GetRecentlyAdded()

        // SearchLibrary(string title, string libraryType)


        /// <summary>
        /// Tag a library item with a Collection Name
        /// </summary>
        /// <param name="libraryKey">Library Key.</param>
        /// <param name="ratingKey">Item Rating Key.</param>
        /// <param name="collectionName">Collection name to add to item.</param>
        public async void AddCollectionToLibraryItemAsync(string libraryKey, string ratingKey, string collectionName) =>
            await this.plexServerClient.AddCollectionToLibraryItemAsync(this.accessToken, this.hostUrl, libraryKey, ratingKey,
                collectionName);

        /// <summary>
        /// Untag a library item with a Collection Name
        /// </summary>
        /// <param name="libraryKey">Library Key.</param>
        /// <param name="ratingKey">Item Rating Key.</param>
        /// <param name="collectionName">Collection name to remove from item.</param>
        public async void RemoveCollectionFromLibraryItemAsync(string libraryKey, string ratingKey, string collectionName) =>
            await this.plexServerClient.DeleteCollectionFromLibraryItemAsync(this.accessToken, this.hostUrl, libraryKey, ratingKey,
                collectionName);

        /// <summary>
        /// Update Collection in a library
        /// </summary>
        /// <param name="libraryKey">Library Key</param>
        /// <param name="collectionModel">Collection Model</param>
        public async void UpdateCollection(string libraryKey, CollectionModel collectionModel) =>
            await this.plexServerClient.UpdateCollectionAsync(this.accessToken, this.hostUrl, libraryKey, collectionModel);

        // Hubs

        /// <summary>
        ///
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<MediaContainer> GetHomeOnDeck(int start = 0, int count = 10) =>
            await this.plexServerClient.GetHomeOnDeckAsync(this.accessToken, this.hostUrl, start, count);

        /// <summary>
        ///
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<MediaContainer> GetHubRecentlyAdded(int start = 0, int count = 10) =>
            await this.plexServerClient.GetHomeRecentlyAddedAsync(this.accessToken, this.hostUrl, start, count);

        /// <summary>
        ///
        /// </summary>
        /// <param name="start"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<MediaContainer> GetHubContinueWatching(int start = 0, int count = 10) =>
            await this.plexServerClient.GetHomeContinueWatchingAsync(this.accessToken, this.hostUrl, start, count);

        /// <summary>
        /// Return list of Hubs on a given library along with their Metadata items
        /// </summary>
        /// <param name="libraryKey">Library Key</param>
        /// <param name="count">Max count of items on each hub</param>
        /// <returns></returns>
        public async Task<HubMediaContainer> GetLibraryHub(string libraryKey, int count = 10) =>
            await this.plexServerClient.GetLibraryHubAsync(this.accessToken, this.hostUrl, libraryKey, count);

        /// <summary>
        /// Returns recently added items to given Library
        /// </summary>
        /// <param name="libraryKey">Key of Library</param>
        /// <param name="start">Offset number to start with (0 is first record)</param>
        /// <param name="count">Max number of items to return</param>
        /// <returns></returns>
        public async Task<MediaContainer> GetLibraryRecentlyAdded(string libraryKey, int start, int count) =>
            await this.plexServerClient.GetLibraryRecentlyAddedAsync(this.accessToken,  this.hostUrl, libraryKey, start, count);

        /// <summary>
        /// Share library content with the specified user.
        /// </summary>
        /// <param name="user">username, email of the user to be added.</param>
        /// <param name="server">PlexServer object or machineIdentifier containing the library sections to share.</param>
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
            await this.plexServerClient.InviteFriend(this.accessToken, this.hostUrl, sections, allowSync, allowCameraUpload,
                allowChannels, filterMovies, filterTelevision, filterMusic);

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task<ProviderContainer> GetProviders() =>
            await this.plexServerClient.GetServerProvidersAsync(this.accessToken, this.hostUrl);

        /// <summary>
        ///
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public async Task<HubMediaContainer> HubLibrarySearch(string title) =>
            await this.plexLibraryClient.HubLibrarySearch(this.accessToken, this.hostUrl, title);

        /// <summary>
        /// Get Filters available for Searching given Library
        /// </summary>
        /// <param name="key">Library Key</param>
        /// <returns>FilterContainer</returns>
        public async Task<FilterContainer> GetSearchFiltersForLibrary(string key) =>
            await this.plexLibraryClient.GetSearchFilters(this.accessToken, this.hostUrl, key);

        /// <summary>
        /// Matching Library Items with Metadata
        /// </summary>
        /// <param name="title">General string query to search for (optional).</param>
        /// <param name="libraryKey">Library Key</param>
        /// <param name="sort">column:dir; column can be any of {addedAt, originallyAvailableAt, lastViewedAt,
        /// titleSort, rating, mediaHeight, duration}. dir can be asc or desc (optional).</param>
        /// <param name="libraryType">Filter results to a spcifiec libtype (movie, show, episode, artist,
        /// album, track; optional).</param>
        /// <param name="filters">
        /// Any of the available filters for the current library section. Partial string matches allowed. Multiple matches OR together.
        /// Negative filtering also possible, just add an exclamation mark to the end of filter name, e.g. resolution!=1x1.
        ///        unwatched: Display or hide unwatched content (True, False). [all]
        ///        duplicate: Display or hide duplicate items (True, False). [movie]
        ///        actor: List of actors to search ([actor_or_id, …]). [movie]
        ///        collection: List of collections to search within ([collection_or_id, …]). [all]
        ///        contentRating: List of content ratings to search within ([rating_or_key, …]). [movie,tv]
        ///        country: List of countries to search within ([country_or_key, …]). [movie,music]
        ///        decade: List of decades to search within ([yyy0, …]). [movie]
        ///        director: List of directors to search ([director_or_id, …]). [movie]
        ///        genre: List Genres to search within ([genere_or_id, …]). [all]
        ///        network: List of TV networks to search within ([resolution_or_key, …]). [tv]
        ///        resolution: List of video resolutions to search within ([resolution_or_key, …]). [movie]
        ///        studio: List of studios to search within ([studio_or_key, …]). [music]
        ///        year: List of years to search within ([yyyy, …]). [all]
        /// </param>
        /// <param name="start">Starting record (default 0)</param>
        /// <param name="count">Only return the specified number of results (default 100).</param>
        /// <returns>MediaContainer</returns>
        public async Task<MediaContainer> LibrarySearch(string title, string libraryKey, string sort, string libraryType, Dictionary<string, string> filters, int start = 0, int count = 100) =>
            await this.plexLibraryClient.LibrarySearch(this.accessToken, this.hostUrl, title, libraryKey, sort, libraryType, filters, start, count);

        /// <summary>
        /// Get Play History for all library sections on all servers for the owner.
        /// </summary>
        /// <param name="maxResults">Only return the specified number of results (optional)</param>
        /// <param name="minDate">Min datetime to return results from.</param>
        /// <returns></returns>
        public async Task<object> PlayHistory(int maxResults = 100, DateTime? minDate = null) =>
            await this.plexServerClient.GetPlayHistory(this.accessToken, this.hostUrl);
    }
}
