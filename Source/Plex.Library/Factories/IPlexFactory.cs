namespace Plex.Api.Factories
{
    using Library.ApiModels.Accounts;

    /// <summary>
    ///
    /// </summary>
    public interface IPlexFactory
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        PlexAccount GetPlexAccount(string username, string password);

        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns></returns>
        PlexAccount GetPlexAccount(string authToken);
    }
}
