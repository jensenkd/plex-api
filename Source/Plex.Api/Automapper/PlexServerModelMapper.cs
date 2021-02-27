namespace Plex.Api.Automapper
{
    using PlexModels.Server;
    using Profile = AutoMapper.Profile;

    public class PlexServerModelMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlexServerModelMapper"/> class.
        /// </summary>
        public PlexServerModelMapper()
        {
            this.CreateMap<PlexServer, Server>();
            this.CreateMap<PlexServerDirectory, PlexServerDirectory>();
        }
    }
}
