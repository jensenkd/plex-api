namespace Plex.Api.Automapper
{
    using System;
    using System.Globalization;
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
            this.CreateMap<AccountServer, Server>()
                .ForMember(x => x.UpdatedAt,
                    opt =>
                        opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.UpdatedAt).
                            DateTime.ToString(CultureInfo.InvariantCulture) ))
                .ForMember(x => x.CreatedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.CreatedAt).DateTime
                                .ToString(CultureInfo.InvariantCulture)));

            this.CreateMap<PlexServer, Server>().ForMember(x => x.UpdatedAt,
                opt =>
                    opt.MapFrom(src =>
                        DateTimeOffset.FromUnixTimeSeconds(src.UpdatedAt).DateTime
                            .ToString(CultureInfo.InvariantCulture)));

            this.CreateMap<PlexServerDirectory, PlexServerDirectory>();
        }
    }
}
