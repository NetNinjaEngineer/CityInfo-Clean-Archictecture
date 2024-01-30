using AutoMapper;
using CityInfo.Application.Features.City.Requests;
using CityInfo.Application.Persistence.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.Application.Features.City.Handlers.Queries
{
    public class GetCityListHandler : IRequestHandler<GetCityListRequest, List<Domain.City>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCityListHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<Domain.City>> Handle(GetCityListRequest request, CancellationToken cancellationToken)
        {
            var cities = (!request.TrackChanges ?
                _unitOfWork.CityRepository.GetAll(false, c => c.PointOfInterests) :
                _unitOfWork.CityRepository.GetAll(true, c => c.PointOfInterests));

            return Task.FromResult(_mapper.Map<List<Domain.City>>(cities));
        }
    }
}
