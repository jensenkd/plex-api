namespace Plex.Api.Automapper
{
    using AutoMapper;
    using Models.Metadata;
    using Plex.Api.Models;
    using Plex.Api.ResourceModels;

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
            CreateMap<Metadata, CollectionModel>();
        }
    }
}
