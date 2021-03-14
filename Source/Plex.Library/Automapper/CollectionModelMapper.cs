namespace Plex.Library.Automapper
{
    using Api.PlexModels.Library.Collections;
    using ApiModels.Libraries;
    using AutoMapper;
    using Collection = Api.PlexModels.Library.Collections.Collection;

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
