namespace Plex.Api.Account
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using Api;
    using Automapper;
    using PlexModels;
    using PlexModels.Account;
    using PlexModels.Resources;
    using PlexModels.Server;
    using PlexAccount = Models.PlexAccount;
    using Subscription = PlexModels.Account.Subscription;

    public class Account
    {
        private readonly IApiService apiService;
        private readonly IPlexClient plexClient;

        private readonly string plexHost;

        public Account(IApiService apiService, IPlexClient plexClient, string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            this.apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            this.plexClient = plexClient ?? throw new ArgumentNullException(nameof(plexClient));

            var account = plexClient.GetPlexAccountAsync(username, password).Result;
            ObjectMapper.Mapper.Map(account, this);
        }

        public Account(IApiService apiService, IPlexClient plexClient, string authToken)
        {
            if (string.IsNullOrEmpty(authToken))
            {
                throw new ArgumentNullException(nameof(authToken));
            }

            this.apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            this.plexClient = plexClient ?? throw new ArgumentNullException(nameof(plexClient));

            var account = plexClient.GetPlexAccountAsync(authToken).Result;
            ObjectMapper.Mapper.Map(account, this);
        }

        [JsonPropertyName("id")]
        public int Id { get; }

        [JsonPropertyName("uuid")]
        public string Uuid { get; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("confirmed")]
        public bool Confirmed { get; set; }

        [JsonPropertyName("emailOnlyAuth")]
        public bool EmailOnlyAuth { get; set; }

        [JsonPropertyName("hasPassword")]
        public bool HasPassword { get; set; }

        [JsonPropertyName("protected")]
        public bool Protected { get; set; }

        [JsonPropertyName("thumb")]
        public string Thumb { get; set; }

        [JsonPropertyName("authToken")]
        public string AuthToken { get; set; }

        [JsonPropertyName("mailingListStatus")]
        public string MailingListStatus { get; set; }

        [JsonPropertyName("mailingListActive")]
        public bool MailingListActive { get; set; }

        [JsonPropertyName("scrobbleTypes")]
        public string ScrobbleTypes { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("subscription")]
        public Subscription Subscription { get; set; }

        [JsonPropertyName("subscriptionDescription")]
        public string SubscriptionDescription { get; set; }

        [JsonPropertyName("restricted")]
        public bool Restricted { get; set; }

        [JsonPropertyName("anonymous")]
        public object Anonymous { get; set; }

        [JsonPropertyName("home")]
        public bool Home { get; set; }

        [JsonPropertyName("guest")]
        public bool Guest { get; set; }

        [JsonPropertyName("homeSize")]
        public int HomeSize { get; set; }

        [JsonPropertyName("homeAdmin")]
        public bool HomeAdmin { get; set; }

        [JsonPropertyName("maxHomeSize")]
        public int MaxHomeSize { get; set; }

        [JsonPropertyName("certificateVersion")]
        public int CertificateVersion { get; set; }

        [JsonPropertyName("rememberExpiresAt")]
        public int RememberExpiresAt { get; set; }

        [JsonPropertyName("adsConsent")]
        public object AdsConsent { get; set; }

        [JsonPropertyName("adsConsentSetAt")]
        public object AdsConsentSetAt { get; set; }

        [JsonPropertyName("adsConsentReminderAt")]
        public object AdsConsentReminderAt { get; set; }

        [JsonPropertyName("experimentalFeatures")]
        public bool ExperimentalFeatures { get; set; }

        [JsonPropertyName("twoFactorEnabled")]
        public bool TwoFactorEnabled { get; set; }

        [JsonPropertyName("backupCodesCreated")]
        public bool BackupCodesCreated { get; set; }

        [JsonPropertyName("profile")]
        public Profile Profile { get; set; }

        [JsonPropertyName("entitlements")]
        public List<string> Entitlements { get; set; }

        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; }

        [JsonPropertyName("services")]
        public List<Service> Services { get; set; }

        public async Task<List<AccountServer>> GetAccountServersAsync() =>
            await this.plexClient.GetAccountServersAsync(this.AuthToken, false);

        public async Task<List<Resource>> GetResourcesAsync() =>
            await this.plexClient.GetResourcesAsync(this.AuthToken);

        public async Task<List<Friend>> GetFriendsAsync() =>
            await this.plexClient.GetFriendsAsync(this.AuthToken);

        // public async Task<List<Device>> GetDevices() =>
        //     await this.plexClient.GetDevicesAsync(this.plexUserAuthToken);

        // See https://github.com/pkkid/python-plexapi/blob/2cde3a11b4c5476c709b2029ef39627c45be73ee/plexapi/myplex.py#L182

        // GetDevices()
        // GetDevice(string name, string clientId
        // GetResources()
        // GetResource(string name)

        // GetSonosSpeakers();
        // GetSonosSpeaker(string name);
        // GetSonosSpeakerById(string id);

        // CreateHomeUser()
        // CreateExistingUser()
        // RemoveFriend()
        // RemoveHomeUser()
        // UpdateFriend()
        // GetUser(string username)

        /// <summary>
        /// Returns a list of all :class:`~plexapi.myplex.MyPlexUser` objects connected to your account.
        /// This includes both friends and pending invites. You can reference the user.friend to
        /// distinguish between the two.
        /// </summary>
        /// <returns></returns>
        public List<object> GetUsers()
        {
            throw new NotImplementedException();
        }

        // AddWebhook(string url);
        // DeleteWebhook(string url);
        // SetWebhooks(string[] urls);
        // GetWebhooks();

        // GetVideoOnDemand();
        // GetWebShows();
        // GetNews();
        // GetPodcasts();
        // GetTidal();

        /// <summary>
        /// Link a device to the account using a pin code.
        /// </summary>
        /// <param name="pin">The 4 digit link pin code.</param>
        public void LinkDevice(string pin)
        {
            // headers = {
            // 'Content-Type': 'application/x-www-form-urlencoded',
            // 'X-Plex-Product': 'Plex SSO'
            // }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Opt in or out of sharing stuff with plex.
        /// See: https://www.plex.tv/about/privacy-legal/
        /// </summary>
        /// <param name="playback"></param>
        /// <param name="library"></param>
        /// <returns></returns>
        public object OptOut(int? playback, int? library)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an instance of :class:`~plexapi.sync.SyncList` for specified client.
        ///   If both `client` and `clientId` provided the client would be preferred.
        ///   If neither `client` nor `clientId` provided the clientId would be set to current clients`s identifier.
        /// /// </summary>
        /// <param name="client">(:class:`~plexapi.myplex.MyPlexDevice`): a client to query SyncItems for.</param>
        /// <param name="clientId">an identifier of a client to query SyncItems for.</param>
        /// <returns></returns>
        public object GetSyncItems(string client, string clientId)
        {
            throw new NotImplementedException();
        }

        /// Adds specified sync item for the client. It's always easier to use methods defined directly in the media
        /// objects, e.g. :func:`~plexapi.video.Video.sync`, :func:`~plexapi.audio.Audio.sync`.
        ///
        ///  If both `client` and `clientId` provided the client would be preferred.
        ///  If neither `client` nor `clientId` provided the clientId would be set to current clients`s identifier.
        /// Returns:
        ///   :class:`~plexapi.sync.SyncItem`: an instance of created syncItem.
        ///
        ///  Raises:
        /// :exc:`~plexapi.exceptions.BadRequest`: When client with provided clientId wasn`t found.
        /// :exc:`~plexapi.exceptions.BadRequest`: Provided client doesn`t provides `sync-target`.
        public void Sync(object syncItem, object client, string clientId)
        {
            throw new NotImplementedException();

            //     params = {
            //     'SyncItem[title]': sync_item.title,
            //     'SyncItem[rootTitle]': sync_item.rootTitle,
            //     'SyncItem[metadataType]': sync_item.metadataType,
            //     'SyncItem[machineIdentifier]': sync_item.machineIdentifier,
            //     'SyncItem[contentType]': sync_item.contentType,
            //     'SyncItem[Policy][scope]': sync_item.policy.scope,
            //     'SyncItem[Policy][unwatched]': str(int(sync_item.policy.unwatched)),
            //     'SyncItem[Policy][value]': str(sync_item.policy.value if hasattr(sync_item.policy, 'value') else 0),
            //     'SyncItem[Location][uri]': sync_item.location,
            //     'SyncItem[MediaSettings][audioBoost]': str(sync_item.mediaSettings.audioBoost),
            //     'SyncItem[MediaSettings][maxVideoBitrate]': str(sync_item.mediaSettings.maxVideoBitrate),
            //     'SyncItem[MediaSettings][musicBitrate]': str(sync_item.mediaSettings.musicBitrate),
            //     'SyncItem[MediaSettings][photoQuality]': str(sync_item.mediaSettings.photoQuality),
            //     'SyncItem[MediaSettings][photoResolution]': sync_item.mediaSettings.photoResolution,
            //     'SyncItem[MediaSettings][subtitleSize]': str(sync_item.mediaSettings.subtitleSize),
            //     'SyncItem[MediaSettings][videoQuality]': str(sync_item.mediaSettings.videoQuality),
            //     'SyncItem[MediaSettings][videoResolution]': sync_item.mediaSettings.videoResolution,
            // }
            //
            // url = SyncList.key.format(clientId=client.clientIdentifier)
            // data = self.query(url, method=self._session.post, headers={
            //     'Content-type': 'x-www-form-urlencoded',
            // }, params=params)

        }

        /// <summary>
        /// Returns a str, a new "claim-token", which you can use to register your new Plex Server instance to your
        /// account.
        ///  See: https://hub.docker.com/r/plexinc/pms-docker/, https://www.plex.tv/claim/
        /// </summary>
        /// <returns></returns>
        public string GetClaimToken()
        {
            //https://plex.tv/api/claim/token.json
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get Play History for all library sections on all servers for the owner.
        /// </summary>
        /// <param name="maxResults">Only return the specified number of results (optional)</param>
        /// <param name="minDate">Min datetime to return results from.</param>
        /// <returns></returns>
        public object GetHistory(int maxResults = 9999999, DateTime? minDate = null)
        {
            throw new NotImplementedException();
        }
        //

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
        public object InviteFriend(string user, string server, string sections = "None", bool allowSync = false,
            bool allowCameraUpload = false,
            bool allowChannels = false, string filterMovies = "None", string filterTelevision = "None",
            string filterMusic = "None")
        {
            throw new NotImplementedException();
        }

        // Parameters:
        // user (str): MyPlexUser, username, email of the user to be added.
        //     server (PlexServer): PlexServer object or machineIdentifier containing the library sections to share.
        //     sections ([Section]): Library sections, names or ids to be shared (default None).
        // [Section] must be defined in order to update shared sections.
        //     allowSync (Bool): Set True to allow user to sync content.
        //     allowCameraUpload (Bool): Set True to allow user to upload photos.
        //     allowChannels (Bool): Set True to allow user to utilize installed channels.
        //     filterMovies (Dict): Dict containing key 'contentRating' and/or 'label' each set to a list of
        // values to be filtered. ex: {'contentRating':['G'], 'label':['foo']}
        // filterTelevision (Dict): Dict containing key 'contentRating' and/or 'label' each set to a list of
        // values to be filtered. ex: {'contentRating':['G'], 'label':['foo']}
        // filterMusic (Dict): Dict containing key 'label' set to a list of values to be filtered.
        //     ex: {'label':['foo']}


//              FRIENDINVITE = 'https://plex.tv/api/servers/{machineId}/shared_servers'                     # post with data
//             HOMEUSERCREATE = 'https://plex.tv/api/home/users?title={title}'                             # post with data
//             EXISTINGUSER = 'https://plex.tv/api/home/users?invitedEmail={username}'                     # post with data
//             FRIENDSERVERS = 'https://plex.tv/api/servers/{machineId}/shared_servers/{serverId}'         # put with data
//             PLEXSERVERS = 'https://plex.tv/api/servers/{machineId}'                                     # get
//             FRIENDUPDATE = 'https://plex.tv/api/friends/{userId}'                                       # put with args, delete
//             REMOVEHOMEUSER = 'https://plex.tv/api/home/users/{userId}'                                  # delete
//             REMOVEINVITE = 'https://plex.tv/api/invites/requested/{userId}?friend=1&server=1&home=1'    # delete
//             REQUESTED = 'https://plex.tv/api/invites/requested'                                         # get
//             REQUESTS = 'https://plex.tv/api/invites/requests'                                           # get
//             SIGNIN = 'https://plex.tv/users/sign_in.xml'                                                # get with auth
//             WEBHOOKS = 'https://plex.tv/api/v2/user/webhooks'                                           # get, post with data
//             LINK = 'https://plex.tv/api/v2/pins/link'                                                   # put
//          # Hub sections
//             VOD = 'https://vod.provider.plex.tv/'                                                       # get
//             WEBSHOWS = 'https://webshows.provider.plex.tv/'                                             # get
//             NEWS = 'https://news.provider.plex.tv/'                                                     # get
//             PODCASTS = 'https://podcasts.provider.plex.tv/'                                             # get
//             MUSIC = 'https://music.provider.plex.tv/'                                                   # get
    }
}
