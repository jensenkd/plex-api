namespace Plex.Api.Automapper
{
    using System;
    using System.Globalization;
    using ApiModels;
    using PlexModels.Account;
    using PlexAccount = ApiModels.Accounts.PlexAccount;
    using Profile = AutoMapper.Profile;

    public class PlexAccountModelMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlexAccountModelMapper"/> class.
        /// </summary>
        public PlexAccountModelMapper()
        {
            this.CreateMap<PlexModels.Account.PlexAccount, PlexAccount>()
                .ForMember(x => x.RememberExpiresAt,
                    opt =>
                        opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.RememberExpiresAt).
                            DateTime.ToString(CultureInfo.InvariantCulture) ));
        }
    }
}
