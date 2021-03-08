namespace Plex.Api.ApiModels
{
    using Clients.Interfaces;
    using Libraries;

    public class PhotoLibrary : LibraryBase
    {
        public PhotoLibrary(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, Server server)
            : base(plexServerClient, plexLibraryClient, server)
        {
        }
    }
}
