using System;
using AutoMapper;

namespace Plex.Api.Automapper
{
    /// <summary>
    ///
    /// </summary>
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<CollectionModelMapper>();
                cfg.AddProfile<PlexAccountModelMapper>();
                cfg.AddProfile<PlexServerModelMapper>();
                cfg.AddProfile<LibraryModelMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        /// <summary>
        ///
        /// </summary>
        public static IMapper Mapper => Lazy.Value;
    }
}
