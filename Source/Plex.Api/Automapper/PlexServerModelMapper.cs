namespace Plex.Api.Automapper
{
    using ApiModels;
    using PlexModels.Account;
    using PlexModels.Server;
    using Profile = AutoMapper.Profile;

    public class PlexServerModelMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlexServerModelMapper"/> class.
        /// </summary>
        public PlexServerModelMapper()
        {
            this.CreateMap<AccountServer, Server>();
            this.CreateMap<PlexServer, Server>();
            this.CreateMap<PlexServerDirectory, PlexServerDirectory>();
        }
    }
}
