using AutoMapper;
using CityInfo.Application.DTOs;
using CityInfo.Application.Features.PointOfInterest.Requests;
using CityInfo.Application.Persistence.Contracts;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.Application.Features.PointOfInterest.Handlers.Queries
{
    public class GetPointOfInterestHandler : IRequestHandler<GetPointOfInterest, PointOfInterestDto>
    {
        private readonly IPointOfInterestRepository _pointOfInterestRepository;
        private readonly IMapper _mapper;

        public GetPointOfInterestHandler(IPointOfInterestRepository pointOfInterestRepository, IMapper mapper)
        {
            _pointOfInterestRepository = pointOfInterestRepository;
            _mapper = mapper;
        }

        public Task<PointOfInterestDto> Handle(GetPointOfInterest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<PointOfInterestDto>((!request.TrackChanges ?
                _pointOfInterestRepository.GetAllByCondition(false, p =>
                    p.CityId == request.CityId && p.Id == request.PointOfInterestId) :
                _pointOfInterestRepository.GetAllByCondition(true, p =>
                    p.CityId == request.CityId && p.Id == request.PointOfInterestId))
                    .SingleOrDefault()!));

        }
    }
}
