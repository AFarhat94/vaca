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
                        .ForMember(d => d.Location, o => o.MapFrom(s => s.Location))
                        .ForMember(d => d.Location, o => o.MapFrom(s => s.Images));
        }
    }
}