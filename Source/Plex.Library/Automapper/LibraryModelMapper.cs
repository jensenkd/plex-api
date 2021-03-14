namespace Plex.Library.Automapper
{
    using System;
    using System.Globalization;
    using ApiModels.Libraries;
    using AutoMapper;
    using ServerApi.PlexModels.Library;

    /// <summary>
    /// Library Mapping Configuration Profile
    /// </summary>
    public class LibraryModelMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryModelMapper"/> class.
        /// </summary>
        public LibraryModelMapper()
        {
            this.CreateMap<Library, MovieLibrary>()
                .ForMember(x => x.UpdatedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.UpdatedAt).DateTime
                                .ToString(CultureInfo.InvariantCulture)))
                .ForMember(x => x.ScannedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.ScannedAt).DateTime
                                .ToString(CultureInfo.InvariantCulture)))
                .ForMember(x => x.CreatedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.CreatedAt).DateTime
                                .ToString(CultureInfo.InvariantCulture)));

            this.CreateMap<Library, MusicLibrary>()
                .ForMember(x => x.UpdatedAt,
                    opt =>
                        opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.UpdatedAt).
                            DateTime.ToString(CultureInfo.InvariantCulture) ))
                .ForMember(x => x.CreatedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.CreatedAt).DateTime
                                .ToString(CultureInfo.InvariantCulture)));

            this.CreateMap<Library, ShowLibrary>()
                .ForMember(x => x.UpdatedAt,
                    opt =>
                        opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.UpdatedAt).
                            DateTime.ToString(CultureInfo.InvariantCulture) ))
                .ForMember(x => x.CreatedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.CreatedAt).DateTime
                                .ToString(CultureInfo.InvariantCulture)));

            this.CreateMap<Library, PhotoLibrary>()
                .ForMember(x => x.UpdatedAt,
                    opt =>
                        opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(src.UpdatedAt).
                            DateTime.ToString(CultureInfo.InvariantCulture) ))
                .ForMember(x => x.CreatedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.CreatedAt).DateTime
                                .ToString(CultureInfo.InvariantCulture)));
        }
    }
}
