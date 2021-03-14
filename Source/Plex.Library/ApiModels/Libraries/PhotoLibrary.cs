namespace Plex.Library.ApiModels.Libraries
{
    using ServerApi.Clients.Interfaces;
    using Servers;

    public class PhotoLibrary : LibraryBase
    {
        public PhotoLibrary(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, Server server)
            : base(plexServerClient, plexLibraryClient, server)
        {
        }
    }
}
