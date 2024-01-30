using AutoMapper;
using CityInfo.Application.DTOs.City;
using CityInfo.Application.DTOs.PointOfInterest;

namespace CityInfo.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.City, CityForCreationDto>().ReverseMap();

            CreateMap<Domain.City, CityForUpdateDto>().ReverseMap();

            CreateMap<Domain.PointOfInterest, PointOfInterestDto>().ReverseMap();

            CreateMap<Domain.PointOfInterest, PointOfInterestForCreationDto>().ReverseMap();

            CreateMap<Domain.PointOfInterest, PointOfInterestForUpdateDto>().ReverseMap();

        }
    }
}
