namespace Plex.Library.Automapper
{
    using System;
    using System.Globalization;
    using ApiModels.Accounts;
    using Profile = AutoMapper.Profile;

    /// <summary>
    ///
    /// </summary>
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
                        opt.MapFrom(src => src.RememberExpiresAt.HasValue?DateTimeOffset.FromUnixTimeSeconds(src.RememberExpiresAt.Value).UtcDateTime:(DateTime?)null));
        }
    }
}
