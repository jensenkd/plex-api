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
                            DateTimeOffset.FromUnixTimeSeconds(src.UpdatedAt).UtcDateTime))
                .ForMember(x => x.ScannedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.ScannedAt).UtcDateTime))
                .ForMember(x => x.CreatedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.CreatedAt).UtcDateTime));

            this.CreateMap<Library, MusicLibrary>()
                .ForMember(x => x.UpdatedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.UpdatedAt).UtcDateTime))
                .ForMember(x => x.CreatedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.CreatedAt).UtcDateTime));

            this.CreateMap<Library, ShowLibrary>()
                .ForMember(x => x.UpdatedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.UpdatedAt).UtcDateTime))
                .ForMember(x => x.CreatedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.CreatedAt).UtcDateTime));

            this.CreateMap<Library, PhotoLibrary>()
                .ForMember(x => x.UpdatedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.UpdatedAt).UtcDateTime))
                .ForMember(x => x.CreatedAt,
                    opt =>
                        opt.MapFrom(src =>
                            DateTimeOffset.FromUnixTimeSeconds(src.CreatedAt).UtcDateTime));
        }
    }
}
