namespace Plex.Api.Factories
{
    using ApiModels;
    using Clients;
    using Clients.Interfaces;

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

        // Plex Account
        public PlexAccount GetPlexAccount(string username, string password) =>
            new(this.plexAccountClient, this.plexServerClient, this.plexLibraryClient, username, password);

        public PlexAccount GetPlexAccount(string authToken) =>
            new(this.plexAccountClient, this.plexServerClient, this.plexLibraryClient, authToken);
    }
}
