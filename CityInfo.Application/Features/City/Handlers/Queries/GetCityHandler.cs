using AutoMapper;
using CityInfo.Application.Contracts.Persistence;
using CityInfo.Application.Exceptions;
using CityInfo.Application.Features.City.Requests;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.Application.Features.City.Handlers.Queries
{
    public class GetCityHandler : IRequestHandler<GetCity, Domain.City>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCityHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<Domain.City> Handle(GetCity request, CancellationToken cancellationToken)
        {
            var city = (!request.TrackChanges ?
                _unitOfWork.CityRepository.GetAll(false, c => c.PointOfInterests)
                .FirstOrDefault(c => c.Id == request.CityId) :
                _unitOfWork.CityRepository.GetAll(true, c => c.PointOfInterests)
                .FirstOrDefault(c => c.Id == request.CityId)
                ) ?? throw new NotFoundException(nameof(Domain.City), request.CityId);

            return Task.FromResult(_mapper.Map<Domain.City>(city));

        }
    }
}
