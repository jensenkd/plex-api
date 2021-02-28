namespace Plex.Api.Automapper
{
    using AutoMapper;
    using ResourceModels;
    using PlexModels.Media;

    /// <summary>
    ///
    /// </summary>
    public class CollectionModelMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionModelMapper"/> class.
        /// </summary>
        public CollectionModelMapper()
        {
            CreateMap<MediaContainer, CollectionModel>();
        }
    }
}
