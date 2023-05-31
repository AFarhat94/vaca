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
                        .ReverseMap();
                        
            CreateMap<Coordinations, CoordinationsDTO>()
                        .ForMember(d => d.Lat, o => o.MapFrom(s => s.Latitude))
                        .ForMember(d => d.Lng, o => o.MapFrom(s => s.Longitude))
                        .ReverseMap();
        }
    }
}