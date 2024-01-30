using AutoMapper;
using CityInfo.Application.DTOs;
using CityInfo.Application.Features.City.Requests;
using CityInfo.Application.Persistence.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.Application.Features.City.Handlers.Queries
{
    public class GetCityListRequestHandler : IRequestHandler<GetCityListRequest, List<CityDto>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetCityListRequestHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public Task<List<CityDto>> Handle(GetCityListRequest request, CancellationToken cancellationToken)
        {
            var cities = (!request.TrackChanges ? _cityRepository.GetAll(false, c => c.PointOfInterests)
                : _cityRepository.GetAll(true, c => c.PointOfInterests));

            return Task.FromResult(_mapper.Map<List<CityDto>>(cities));
        }
    }
}
