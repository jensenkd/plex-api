namespace Plex.Api.Automapper
{
    using AutoMapper;

    public class LibraryModelMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryModelMapper"/> class.
        /// </summary>
        public LibraryModelMapper()
        {
            CreateMap<PlexModels.Library.Library, ApiModels.Library>();
        }
    }
}
