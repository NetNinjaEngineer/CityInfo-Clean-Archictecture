using AutoMapper;
using CityInfo.Application.Features.City.Requests;
using CityInfo.Application.Persistence.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.Application.Features.City.Handlers.Queries
{
    public class GetCityCollectionHandler : IRequestHandler<GetCityCollection, List<Domain.City>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCityCollectionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<Domain.City>> Handle(GetCityCollection request, CancellationToken cancellationToken)
        {
            var citiesToReturn = new List<Domain.City>();

            foreach (var cityId in request.Ids)
            {
                var city = _unitOfWork.CityRepository
                    .GetAll(true, c => c.PointOfInterests)
                    .FirstOrDefault(c => c.Id == cityId);

                if (city != null)
                    citiesToReturn.Add(_mapper.Map<Domain.City>(city));

            }

            return Task.FromResult(citiesToReturn);
        }
    }
}
