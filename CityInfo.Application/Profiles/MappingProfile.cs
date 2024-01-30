using AutoMapper;
using CityInfo.Application.DTOs;
using CityInfo.Domain;

namespace CityInfo.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, CityDto>().ReverseMap();

            CreateMap<PointOfInterest, PointOfInterestDto>().ReverseMap();
        }
    }
}
