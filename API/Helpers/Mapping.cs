using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Place, PlaceDTO>()
                        .ForMember(d => d.Coordinations, o => o.MapFrom(s => s.Coordinations))
                        .ForMember(d => d.Coordinations, o => o.MapFrom(s => s.Images));
        }
    }
}