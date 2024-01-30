using AutoMapper;
using CityInfo.Application.DTOs;
using CityInfo.Application.Features.PointOfInterest.Requests;
using CityInfo.Application.Persistence.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.Application.Features.PointOfInterest.Handlers.Queries
{
    public class GetAllPointsOfInterestHandler : IRequestHandler<GetAllPointsOfInterest, List<PointOfInterestDto>>
    {
        private readonly IPointOfInterestRepository _pointOfInterestRepository;
        private readonly IMapper _mapper;

        public GetAllPointsOfInterestHandler(IPointOfInterestRepository pointOfInterestRepository, IMapper mapper)
        {
            _pointOfInterestRepository = pointOfInterestRepository;
            _mapper = mapper;
        }

        public Task<List<PointOfInterestDto>> Handle(GetAllPointsOfInterest request, CancellationToken cancellationToken)
        {
            var pointsOfInterest = (!request.TrackChanges ?
                _pointOfInterestRepository.GetAll(false, c => c.City) :
                _pointOfInterestRepository.GetAll(true, c => c.City));

            var mappedList = _mapper.Map<List<PointOfInterestDto>>(pointsOfInterest);

            return Task.FromResult(mappedList);

        }
    }
}
