namespace Plex.Library.Automapper
{
    using System;
    using System.Globalization;
    using ApiModels.Servers;
    using ServerApi.PlexModels.Account;
    using ServerApi.PlexModels.Server;
    using Profile = AutoMapper.Profile;

    public class PlexServerModelMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlexServerModelMapper"/> class.
        /// </summary>
        public PlexServerModelMapper()
        {
            this.CreateMap<AccountServer, Server>()
                .ForMember(x => x.UpdatedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.UpdatedAt).UtcDateTime))

                .ForMember(x => x.CreatedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.CreatedAt).UtcDateTime));

            this.CreateMap<PlexServer, Server>().ForMember(x => x.UpdatedAt,
                opt =>
                    opt.MapFrom(src =>
                        DateTimeOffset.FromUnixTimeSeconds(src.UpdatedAt).UtcDateTime));

            this.CreateMap<PlexServerDirectory, PlexServerDirectory>();
        }
    }
}
