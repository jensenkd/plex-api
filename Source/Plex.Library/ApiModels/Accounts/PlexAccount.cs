namespace Plex.Library.ApiModels.Accounts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Automapper;
    using ServerApi.Clients.Interfaces;
    using ServerApi.Enums;
    using ServerApi.PlexModels.Account;
    using ServerApi.PlexModels.Account.Announcements;
    using ServerApi.PlexModels.Account.Resources;
    using ServerApi.PlexModels.Account.User;
    using ServerApi.PlexModels.OAuth;
    using ServerApi.PlexModels.Watchlist;
    using Servers;
    using Subscription = ServerApi.PlexModels.Account.Subscription;

    /// <summary>
    /// Plex Account Object.  This is the entry point to Plex-Api.
    /// </summary>
    public class PlexAccount
    {
        private readonly IPlexAccountClient plexAccountClient;
        private readonly IPlexServerClient plexServerClient;
        private readonly IPlexLibraryClient plexLibraryClient;

        /// <summary>
        /// Initialize PlexAccount instance.
        /// </summary>
        /// <param name="plexAccountClient">IPlexAccountClient instance.</param>
        /// <param name="plexServerClient">IPlexServerClient instance.</param>
        /// <param name="plexLibraryClient">IPlexLibraryClient instance.</param>
        /// <param name="username">Plex account username.</param>
        /// <param name="password">Plex account password.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PlexAccount(IPlexAccountClient plexAccountClient, IPlexServerClient plexServerClient,
            IPlexLibraryClient plexLibraryClient, string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            this.plexAccountClient = plexAccountClient ?? throw new ArgumentNullException(nameof(plexAccountClient));
            this.plexServerClient = plexServerClient ?? throw new ArgumentNullException(nameof(plexServerClient));
            this.plexLibraryClient = plexLibraryClient ?? throw new ArgumentNullException(nameof(plexLibraryClient));

            var account = plexAccountClient.GetPlexAccountAsync(username, password).Result;
            ObjectMapper.Mapper.Map(account, this);
        }

        /// <summary>
        /// Initialize PlexAccount instance.
        /// </summary>
        /// <param name="plexAccountClient">IPlexAccountClient instance.</param>
        /// <param name="plexServerClient">IPlexServerClient instance.</param>
        /// <param name="plexLibraryClient">IPlexLibraryClient instance.</param>
        /// <param name="authToken">Plex Auth Token.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PlexAccount(IPlexAccountClient plexAccountClient, IPlexServerClient plexServerClient,
            IPlexLibraryClient plexLibraryClient, string authToken)
        {
            if (string.IsNullOrEmpty(authToken))
            {
                throw new ArgumentNullException(nameof(authToken));
            }

            this.plexAccountClient = plexAccountClient ?? throw new ArgumentNullException(nameof(plexAccountClient));
            this.plexServerClient = plexServerClient ?? throw new ArgumentNullException(nameof(plexServerClient));
            this.plexLibraryClient = plexLibraryClient ?? throw new ArgumentNullException(nameof(plexLibraryClient));

            var account = plexAccountClient.GetPlexAccountAsync(authToken).Result;
            ObjectMapper.Mapper.Map(account, this);
        }

        /// <summary>
        ///
        /// </summary>
        public int Id { get; }

        /// <summary>
        ///
        /// </summary>
        public string Uuid { get; }

        /// <summary>
        ///
        /// </summary>
        public string AuthToken { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Username { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Locale { get; set; }
        public bool Confirmed { get; set; }
        public bool EmailOnlyAuth { get; set; }
        public bool HasPassword { get; set; }
        public bool Protected { get; set; }
        public string Thumb { get; set; }
        public string MailingListStatus { get; set; }
        public bool MailingListActive { get; set; }
        public string ScrobbleTypes { get; set; }
        public string Country { get; set; }
        public string SubscriptionDescription { get; set; }
        public bool Restricted { get; set; }
        public object Anonymous { get; set; }
        public bool Home { get; set; }
        public bool Guest { get; set; }
        public int HomeSize { get; set; }
        public bool HomeAdmin { get; set; }
        public int MaxHomeSize { get; set; }
        public int CertificateVersion { get; set; }
        public DateTime? RememberExpiresAt { get; set; }
        public object AdsConsent { get; set; }
        public object AdsConsentSetAt { get; set; }
        public object AdsConsentReminderAt { get; set; }
        public bool ExperimentalFeatures { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool BackupCodesCreated { get; set; }
        public Subscription Subscription { get; set; }
        public Profile Profile { get; set; }
        public List<string> Entitlements { get; set; }
        public List<string> Roles { get; set; }
        public List<Service> Services { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="redirectUrl"></param>
        /// <returns></returns>
        public async Task<OAuthPin> CreatePin(string redirectUrl) =>
            await this.plexAccountClient.CreateOAuthPinAsync(redirectUrl);

        /// <summary>
        ///
        /// </summary>
        /// <param name="pinId"></param>
        /// <returns></returns>
        public async Task<OAuthPin> ClaimToken(string pinId) =>
            await this.plexAccountClient.GetAuthTokenFromOAuthPinAsync(pinId);

        /// <summary>
        /// Get Server Summaries.  This does not return a Server Instance but a summary
        /// of all servers tied to your Plex Account.  The servers may not be active/online.
        /// </summary>
        /// <param name="forceHttps">Forces URI scheme to https</param>
        /// <param name="overrideHost">Accepts dictionary that overwrites the HOST part of the servers URI.
        /// key = serverName, value = custom host string </param>
        /// <returns>AccountServerContainer</returns>
        public async Task<AccountServerContainer> ServerSummaries(bool forceHttps = false, Dictionary<string, string> overrideHost = null) =>
            await this.plexAccountClient.GetAccountServersAsync(this.AuthToken, forceHttps, overrideHost);

        /// <summary>
        /// Get Active Servers tied to this Account
        /// </summary>
        /// <param name="forceHttps">Forces URI scheme to https</param>
        /// <param name="overrideHost">Accepts dictionary that overwrites the HOST part of the servers URI.
        /// key = serverName, value = custom host string </param>
        /// <returns>List of Server objects</returns>
        public async Task<List<Server>> Servers(bool forceHttps = false, Dictionary<string, string> overrideHost = null)
        {
            var servers = new List<Server>();
            var accountServerContainer = await this.plexAccountClient.GetAccountServersAsync(this.AuthToken, forceHttps, overrideHost);
            foreach (var server in accountServerContainer.Servers)
            {
                try
                {
                    var activeServer =
                        await this.plexServerClient.GetPlexServerInfo(server.AccessToken, server.Uri.ToString());
                    if (!string.IsNullOrEmpty(activeServer.MachineIdentifier))
                    {
                        servers.Add(new Server(this.plexServerClient, this.plexLibraryClient, server));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Cannot access server: " + server.Host);
                }
            }

            return servers;
        }

        /// <summary>
        /// Return list of Resources for Plex Account
        /// </summary>
        /// <returns>List of Resource Objects</returns>
        public async Task<List<Resource>> Resources() =>
            await this.plexAccountClient.GetResourcesAsync(this.AuthToken);

        /// <summary>
        /// Return list of Friends for Plex Account
        /// </summary>
        /// <returns>List of Friend Objects</returns>
        public async Task<List<Friend>> Friends() =>
            await this.plexAccountClient.GetFriendsAsync(this.AuthToken);

        // CreateHomeUser()
        // CreateExistingUser()
        // RemoveFriend()
        // RemoveHomeUser()
        // UpdateFriend()
        // GetUser(string username)

        /// <summary>
        /// Return list of Movie and Show items in the user's Watchlist.
        /// Note: Objects returned are from Plex's online metadata service.  You will need to lookup items on the
        /// Plex Server via metadataKey in order to get the matching item on the server.
        /// </summary>
        /// <param name="filter">Comma delimited list of filters for the service</param>
        /// <param name="sort">Field to sort by along with the direction.  Ex: 'titleSort:asc'
        ///     Fields
        ///     - watchlistedAt
        ///     - titleSort
        ///     - originallyAvailableAt
        ///     - rating
        ///
        ///     Sort Direction
        ///     - asc
        ///     - desc
        /// </param>
        /// <param name="libraryType">Library Type (either 'movie' or 'show').  Empty string will return all items.</param>
        /// <returns>List of Movies or Shows</returns>
        public async Task<WatchlistMetadataContainer[]> Watchlist(string filter, string sort, SearchType? libraryType)
        {
            var watchlist = await this.plexAccountClient.GetWatchListAsync(this.AuthToken, filter, sort, libraryType);

            if (watchlist.Size > 0 && watchlist.MediaContainers.Any())
            {
                return watchlist.MediaContainers;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get Announcements for Plex Account
        /// </summary>
        /// <returns>AnnouncementContainer Object</returns>
        public async Task<AnnouncementContainer> Announcements() =>
            await this.plexAccountClient.GetPlexAnnouncementsAsync(this.AuthToken);

        /// <summary>
        /// Returns a list of Home Users for Account
        /// </summary>
        /// <returns>UserContainer Object</returns>
        public async Task<HomeUserContainer> HomeUsers() =>
            await this.plexAccountClient.GetHomeUsersAsync(this.AuthToken);

        /// <summary>
        /// Returns a list of all User objects connected to your account.
        /// This includes both friends and pending invites. You can reference the user.Friend to
        /// distinguish between the two.
        /// </summary>
        /// <returns>UserContainer Object</returns>
        public async Task<PlexAccount> GetPlexHomeAccountAsync(string userUuid)
        {
            var account = await this.plexAccountClient.GetPlexHomeAccountAsync(this.AuthToken, userUuid);
            if (account == null)
            {
                return null;
            }

            return new PlexAccount(this.plexAccountClient, this.plexServerClient, this.plexLibraryClient, account.AuthToken);
        }


        /// <summary>
        /// Opt in or out of sharing stuff with plex.
        /// See: https://www.plex.tv/about/privacy-legal/
        /// </summary>
        /// <param name="playback">Opt out of playback</param>
        /// <param name="library">Opt out of Library statistics</param>
        /// <returns></returns>
        public async Task OptOut(bool playback, bool library) =>
            await this.plexAccountClient.OptOutAsync(this.AuthToken, playback, library);

        /// <summary>
        /// Get Account Devices
        /// </summary>
        /// <returns>List of Device objects</returns>
        public async Task<List<Device>> Devices() =>
            await this.plexAccountClient.GetDevicesAsync(this.AuthToken);

        // AddWebhook(string url);
        // DeleteWebhook(string url);
        // SetWebhooks(string[] urls);
        // GetWebhooks();

        //
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


        //

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

//             FRIENDINVITE = 'https://plex.tv/api/servers/{machineId}/shared_servers'                     # post with data
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
