using AutoMapper;
using Plex.Api.Models;
using Plex.Api.ResourceModels;

namespace Plex.Api.Automapper
{
    public class CollectionModelMapper : Profile
    {
            public CollectionModelMapper()
            {
                CreateMap<Metadata, CollectionModel>();
            }
    }
}