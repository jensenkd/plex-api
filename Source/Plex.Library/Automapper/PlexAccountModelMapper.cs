namespace Plex.Library.Automapper
{
    using System;
    using System.Globalization;
    using ApiModels.Accounts;
    using Profile = AutoMapper.Profile;

    public class PlexAccountModelMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlexAccountModelMapper"/> class.
        /// </summary>
        public PlexAccountModelMapper()
        {
            this.CreateMap<ServerApi.PlexModels.Account.PlexAccount, PlexAccount>()
                .ForMember(x => x.RememberExpiresAt,
                    opt =>
                        opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.RememberExpiresAt).
                            DateTime.ToString(CultureInfo.InvariantCulture) ));
        }
    }
}
