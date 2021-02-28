namespace Plex.Api.Clients
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PlexModels;
    using PlexModels.Account;
    using PlexModels.Account.User;
    using PlexModels.OAuth;
    using PlexModels.Resources;
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
        Task<PlexModels.Account.PlexAccount> GetPlexAccountAsync(string username, string password);

        /// <summary>
        /// Get Plex Account.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<PlexModels.Account.PlexAccount> GetPlexAccountAsync(string authToken);

        /// <summary>
        /// Get Plex Resources.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<Resource>> GetResourcesAsync(string authToken);

        /// <summary>
        /// http://[PMS_IP_Address]:32400/library/sections?X-Plex-Token=YourTokenGoesHere
        /// Retrieves a list of servers tied to your Plex Account.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="showActiveOnly">Show only active Servers</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<List<AccountServer>> GetAccountServersAsync(string authToken, bool showActiveOnly);

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
        /// Returns a list of all User objects connected to your account.
        /// This includes both friends and pending invites. You can reference the User.Friend to
        /// distinguish between the two.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <returns>List of Users</returns>
        Task<UserContainer> GetUsers(string authToken);
    }
}
