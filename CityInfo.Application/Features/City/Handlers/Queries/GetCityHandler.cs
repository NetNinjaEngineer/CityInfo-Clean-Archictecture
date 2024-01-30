using AutoMapper;
using CityInfo.Application.DTOs;
using CityInfo.Application.Features.City.Requests;
using CityInfo.Application.Persistence.Contracts;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.Application.Features.City.Handlers.Queries
{
    public class GetCityHandler : IRequestHandler<GetCity, CityDto>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public Task<CityDto> Handle(GetCity request, CancellationToken cancellationToken)
        {
            var city = (!request.TrackChanges ?
                _cityRepository.GetAll(false, c => c.PointOfInterests)
                .FirstOrDefault(c => c.Id == request.CityId) :
                _cityRepository.GetAll(true, c => c.PointOfInterests)
                .FirstOrDefault(c => c.Id == request.CityId)
                );

            return Task.FromResult(_mapper.Map<CityDto>(city));

        }
    }
}
