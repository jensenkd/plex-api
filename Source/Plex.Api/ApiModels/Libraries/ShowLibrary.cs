namespace Plex.Api.ApiModels
{
    using Clients.Interfaces;
    using Libraries;

    public class ShowLibrary : LibraryBase
    {
        public ShowLibrary(IPlexServerClient plexServerClient, IPlexLibraryClient plexLibraryClient, Server server)
            : base(plexServerClient, plexLibraryClient, server)
        {
        }
    }
}
