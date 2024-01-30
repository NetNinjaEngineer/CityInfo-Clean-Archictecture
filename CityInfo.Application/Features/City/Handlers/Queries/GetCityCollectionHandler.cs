using AutoMapper;
using CityInfo.Application.DTOs;
using CityInfo.Application.Features.City.Requests;
using CityInfo.Application.Persistence.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.Application.Features.City.Handlers.Queries
{
    public class GetCityCollectionHandler : IRequestHandler<GetCityCollection, List<CityDto>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public GetCityCollectionHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public Task<List<CityDto>> Handle(GetCityCollection request, CancellationToken cancellationToken)
        {
            var citiesToReturn = new List<CityDto>();

            foreach (var cityId in request.Ids)
            {
                var city = _cityRepository
                    .GetAll(true, c => c.PointOfInterests)
                    .FirstOrDefault(c => c.Id == cityId);

                if (city != null)
                    citiesToReturn.Add(_mapper.Map<CityDto>(city));

            }

            return Task.FromResult(citiesToReturn);
        }
    }
}
