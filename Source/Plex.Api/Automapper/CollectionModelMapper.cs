namespace Plex.Api.Automapper
{
    using ApiModels.Libraries;
    using AutoMapper;
    using PlexModels.Library.Collections;
    using PlexModels.Media;
    using Collection = PlexModels.Library.Collections.Collection;

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
            this.CreateMap<Collection, CollectionModel>();
        }
    }
}
