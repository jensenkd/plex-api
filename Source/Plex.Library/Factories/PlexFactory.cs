namespace Plex.Library.Factories
{
    using Api.Clients.Interfaces;
    using Api.Factories;
    using ApiModels.Accounts;

    public class PlexFactory : IPlexFactory
    {
        private readonly IPlexServerClient plexServerClient;
        private readonly IPlexAccountClient plexAccountClient;
        private readonly IPlexLibraryClient plexLibraryClient;

        /// <summary>
        /// This is the entry point to the Api.  This will initialize an Account object from
        /// your plex login information.
        /// </summary>
        /// <param name="plexServerClient"></param>
        /// <param name="plexAccountClient"></param>
        /// <param name="plexLibraryClient"></param>
        public PlexFactory(IPlexServerClient plexServerClient, IPlexAccountClient plexAccountClient,
            IPlexLibraryClient plexLibraryClient)
        {
            this.plexServerClient = plexServerClient;
            this.plexAccountClient = plexAccountClient;
            this.plexLibraryClient = plexLibraryClient;
        }

        /// <summary>
        /// Plex Account
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public PlexAccount GetPlexAccount(string username, string password) =>
            new(this.plexAccountClient, this.plexServerClient, this.plexLibraryClient, username, password);

        /// <summary>
        ///
        /// </summary>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public PlexAccount GetPlexAccount(string authToken) =>
            new(this.plexAccountClient, this.plexServerClient, this.plexLibraryClient, authToken);
    }
}
