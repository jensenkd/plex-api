namespace Plex.Library.Automapper
{
    using ApiModels.Libraries;
    using AutoMapper;
    using ServerApi.PlexModels.Library.Collections;
    using Collection = ServerApi.PlexModels.Library.Collections.Collection;

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
