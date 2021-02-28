namespace Plex.Api.Factories
{
    using System;
    using Account;
    using Api;

    public class PlexFactory : IPlexFactory
    {
        private readonly IApiService apiService;
        private readonly IPlexClient plexClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlexClient"/> class.
        /// </summary>
        /// <param name="apiService">Api Service.</param>
        /// <param name="plexClient"></param>
        public PlexFactory(IApiService apiService, IPlexClient plexClient)
        {
            this.apiService = apiService;
            this.plexClient = plexClient;
        }

        // Plex Account
        public Account GetPlexAccount(string username, string password) =>
            new Account(this.plexClient, username, password);

        public Account GetPlexAccount(string authToken) =>
            new Account(this.plexClient, authToken);

        // Plex Server
        public Server GetPlexServer(string plexHostUrl, string authToken) =>
            new Server(this.plexClient, authToken, plexHostUrl);
    }
}
