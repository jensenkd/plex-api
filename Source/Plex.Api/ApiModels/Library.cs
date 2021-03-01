namespace Plex.Api.ApiModels
{
    using System;
    using Clients;

    public class Library : BaseApi
    {
        private readonly IPlexServerClient plexServerClient;
        private readonly IPlexLibraryClient plexLibraryClient;

        public Library(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, Server server)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            this.plexServerClient = plexServerClient ?? throw new ArgumentNullException(nameof(plexServerClient));
            this.plexLibraryClient = plexLibraryClient ?? throw new ArgumentNullException(nameof(plexLibraryClient));
        }

    }
}
