namespace Plex.Api.Factories
{
    using Account;

    public interface IPlexFactory
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Account GetPlexAccount(string username, string password);

        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns></returns>
        Account GetPlexAccount(string authToken);

        /// <summary>
        ///
        /// </summary>
        /// <param name="plexHostUrl"></param>
        /// <param name="authToken"></param>
        /// <returns></returns>
        Server GetPlexServer(string plexHostUrl, string authToken);
    }
}
