namespace Plex.Api.Factories
{
    using Account;
    using Api;
    using Clients;
    using IPlexServerClient = Clients.IPlexServerClient;

    public class PlexFactory : IPlexFactory
    {
        private readonly IApiService apiService;
        private readonly IPlexServerClient plexServerClient;
        private readonly IPlexAccountClient plexAccountClient;
        private readonly IPlexLibraryClient plexLibraryClient;

        /// <summary>
        /// Initializes a new instance of our Client classes.
        /// </summary>
        /// <param name="apiService">Api Service.</param>
        /// <param name="plexServerClient"></param>
        /// <param name="plexAccountClient"></param>
        /// <param name="plexLibraryClient"></param>
        public PlexFactory(IApiService apiService, IPlexServerClient plexServerClient, IPlexAccountClient plexAccountClient,
            IPlexLibraryClient plexLibraryClient)
        {
            this.apiService = apiService;
            this.plexServerClient = plexServerClient;
            this.plexAccountClient = plexAccountClient;
            this.plexLibraryClient = plexLibraryClient;
        }

        // Plex Account
        public Account GetPlexAccount(string username, string password)
        {
            return new Account(this.plexAccountClient, username, password);
        }

        public Account GetPlexAccount(string authToken)
        {
            return new Account(this.plexAccountClient, authToken);
        }

        // Plex Server
        public Server GetPlexServer(string plexHostUrl, string authToken) =>
            new Server(this.plexServerClient, this.plexLibraryClient, authToken, plexHostUrl);
    }
}
