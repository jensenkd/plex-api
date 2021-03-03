namespace Plex.Api.Clients.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
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
        Task<List<Resource>> GetResourcesAsync(string authToken);

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
        /// Returns a list of all User objects connected to your account.
        /// This includes both friends and pending invites. You can reference the User.Friend to
        /// distinguish between the two.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <returns>List of Users</returns>
        Task<UserContainer> GetUsers(string authToken);

        /// <summary>
        /// Opt in or out of sharing stuff with plex.
        /// See: https://www.plex.tv/about/privacy-legal/
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <param name="playback">Opt out of playback</param>
        /// <param name="library">Opt out of Library statistics</param>
        /// <returns></returns>
        Task OptOut(string authToken, bool playback, bool library);

        /// <summary>
        /// Returns a list of all Device objects connected to the account.
        /// </summary>
        /// <param name="authToken">Authentication Token.</param>
        /// <returns></returns>
        Task<List<Device>> GetDevices(string authToken);
    }
}
