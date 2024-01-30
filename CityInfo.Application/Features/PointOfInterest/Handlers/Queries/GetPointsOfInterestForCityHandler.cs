using AutoMapper;
using CityInfo.Application.DTOs;
using CityInfo.Application.Features.PointOfInterest.Requests;
using CityInfo.Application.Persistence.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.Application.Features.PointOfInterest.Handlers.Queries
{
    public class GetPointsOfInterestForCityHandler
        : IRequestHandler<GetPointsOfInterestForCity, List<PointOfInterestDto>>
    {
        private readonly IPointOfInterestRepository _pointOfInterestRepository;
        private readonly IMapper _mapper;

        public GetPointsOfInterestForCityHandler(IPointOfInterestRepository pointOfInterestRepository, IMapper mapper)
        {
            _pointOfInterestRepository = pointOfInterestRepository;
            _mapper = mapper;
        }

        public Task<List<PointOfInterestDto>> Handle(GetPointsOfInterestForCity request, CancellationToken cancellationToken)
        {
            var pointsOfInterest = (!request.TrackChanges ?
                _pointOfInterestRepository.GetAllByCondition(false,
                    p => p.CityId == request.CityId, p => p.City) :
                _pointOfInterestRepository.GetAllByCondition(true,
                    p => p.CityId == request.CityId, p => p.City)
                );

            return Task.FromResult(_mapper.Map<List<PointOfInterestDto>>(pointsOfInterest.ToList()));

        }
    }
}
