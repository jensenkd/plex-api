namespace Plex.ServerApi.Clients.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Enums;
    using PlexModels.Account;
    using PlexModels.Account.Announcements;
    using PlexModels.Account.Discover;
    using PlexModels.Account.Resources;
    using PlexModels.Account.SharedItems;
    using PlexModels.Account.User;
    using PlexModels.OAuth;
    using PlexModels.Watchlist;
    using User = Models.User;

    /// <summary>
    /// Inteface for Plex Library Client
    /// </summary>
    public interface IPlexAccountClient
    {
        /// <summary>
        /// Create Pin.
        /// </summary>
        /// <param name="redirectUrl">Redirect Url.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<OAuthPin> CreateOAuthPinAsync(string redirectUrl);

        /// <summary>
        /// Get Pin.
        /// </summary>
        /// <param name="pinId">Pin Id.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<OAuthPin> GetAuthTokenFromOAuthPinAsync(string pinId);

        /// <summary>
        /// Sign into the Plex API
        /// This is for authenticating users credentials with Plex.
        /// <para>NOTE: Plex "Managed" users do not work.</para>
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<User> SignInAsync(string username, string password);

        /// <summary>
        /// Get Plex Account.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PlexAccount> GetPlexAccountAsync(string username, string password);

        /// <summary>
        /// Get Plex Account.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PlexAccount> GetPlexAccountAsync(string authToken);

        /// <summary>
        /// Get Plex Resources.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<ResourceContainer> GetResourcesAsync(string authToken);

        /// <summary>
        /// http://[PMS_IP_Address]:32400/library/sections?X-Plex-Token=YourTokenGoesHere
        /// Retrieves a list of servers tied to your Plex Account.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <returns>AccountServerContainer.</returns>
        Task<AccountServerContainer> GetAccountServersAsync(string authToken);

        /// <summary>
        /// Get Plex Announcements
        /// </summary>
        /// <param name="authToken">Authentication Token</param>
        /// <returns>Announcement Wrapper</returns>
        Task<AnnouncementContainer> GetPlexAnnouncementsAsync(string authToken);

        /// <summary>
        /// Retuns all the Plex friends for this account.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<Friend>> GetFriendsAsync(string authToken);

        /// <summary>
        /// Returns a list of User objects connected to your account.
        /// This includes both friends and pending invites. You can reference the User.Friend to
        /// distinguish between the two.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <returns>List of Users</returns>
        Task<HomeUserContainer> GetHomeUsersAsync(string authToken);

        /// <summary>
        /// Opt in or out of sharing stuff with plex.
        /// See: https://www.plex.tv/about/privacy-legal/
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="playback">Opt out of playback</param>
        /// <param name="library">Opt out of Library statistics</param>
        /// <returns></returns>
        Task OptOutAsync(string authToken, bool playback, bool library);

        /// <summary>
        /// Returns a list of all Device objects connected to the account.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <returns></returns>
        Task<List<Device>> GetDevicesAsync(string authToken);

        /// <summary>
        /// Link a device to Plex Account using Pin Auth
        /// </summary>
        /// <param name="pinCode"></param>
        /// <returns></returns>
        Task<object> LinkDeviceToAccountByPinAsync(string pinCode);

        /// <summary>
        /// Switch to the account of another Home User
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="userUuid">UUID of the home user to switch to.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PlexModels.Account.PlexAccount> GetPlexHomeAccountAsync(string authToken, string userUuid);

        /// <summary>
        /// Return list of Movie and Show items in the user's Watchlist.
        /// Note: Objects returned are from Plex's online metadata service.  You will need to lookup items on the
        /// Plex Server via metadataKey in order to get the matching item on the server.
        /// </summary>
        /// <param name="authToken">Plex Auth Token</param>
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
        /// <param name="searchType">Library Type (either 'movie' or 'show').  Empty string will return all items.</param>
        /// <returns>List of Movies or Shows</returns>
        Task<WatchlistContainer> GetWatchListAsync(string authToken, string filter, string sort, SearchType? searchType);

        /// <summary>
        /// Search for Movies and TV shows in Discover
        /// </summary>
        /// <param name="authToken">Plex Auth Token</param>
        /// <param name="query">Search Query</param>
        /// <param name="limit">Limit number of items to return. Default is 30</param>
        /// <returns>List of Discover objects</returns>
        Task<DiscoverSearchContainer> SearchDiscoverAsync(string authToken, string query, int limit = 30);

        /// <summary>
        /// Returns True or False depending on if Item is on Watchlist
        /// </summary>
        /// <param name="authToken">Plex Auth Token</param>
        /// <param name="ratingKey">Item Rating Key</param>
        /// <returns></returns>
        Task<bool> OnWatchlistAsync(string authToken,string ratingKey);

        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken">Plex Auth Token</param>
        /// <param name="ratingKey">Item Rating Key</param>
        /// <returns></returns>
        Task AddToWatchlistAsync(string authToken, string ratingKey);

        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken">Plex Auth Token</param>
        /// <param name="ratingKey">Item Rating Key</param>
        /// <returns></returns>
        Task RemoveFromWatchlistAsync(string authToken, string ratingKey);

        /// <summary>
        /// Get Shared Items for Admin Account
        /// </summary>
        /// <param name="authToken">Plex Auth Token</param>
        /// <returns>List of Shared Items and the Users associated</returns>
        Task<List<SharedItemContainer>> GetSharedItemsAsync(string authToken);

        /// <summary>
        /// Remove Shared Item for Admin Account
        /// </summary>
        /// <param name="authToken">Plex Auth Token</param>
        /// <param name="sharedItemId">Shared Item Identifier</param>
        /// <returns></returns>
        Task RemoveSharedItemAsync(string authToken, int sharedItemId);

        /// <summary>
        /// Add Shared items from Admin Account to another user
        /// </summary>
        /// <param name="authToken">Plex Auth Token</param>
        /// <param name="sharedUserId">User Id to share with</param>
        /// <param name="sharedItems">Items to share</param>
        /// <returns></returns>
        Task AddSharedItemsAsync(string authToken, int sharedUserId,  List<SharedItemModelRequest> sharedItems);
    }
}
