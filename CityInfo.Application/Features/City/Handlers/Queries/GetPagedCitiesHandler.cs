using AutoMapper;
using CityInfo.Application.Features.City.Requests;
using CityInfo.Application.Persistence.Contracts;
using CityInfo.Application.RequestFeatures;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.Application.Features.City.Handlers.Queries
{
    public class GetPagedCitiesHandler : IRequestHandler<GetPagedCities, PagedList<Domain.City>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPagedCitiesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<PagedList<Domain.City>> Handle(GetPagedCities request, CancellationToken cancellationToken)
        {
            if (request.CityRequestParameters is null)
                throw new ArgumentNullException(nameof(request.CityRequestParameters));

            var cities = _unitOfWork.CityRepository.GetAll(true,
                c => c.PointOfInterests);

            var mappedCities = _mapper.Map<PagedList<Domain.City>>(cities);

            if (string.IsNullOrEmpty(request.CityRequestParameters.SearchTerm) &&
                string.IsNullOrEmpty(request.CityRequestParameters.FilterTerm))
                return Task.FromResult(PagedList<Domain.City>.ToPagedList(mappedCities, request.CityRequestParameters.PageNumber,
                    request.CityRequestParameters.PageSize));

            if (!string.IsNullOrWhiteSpace(request.CityRequestParameters.FilterTerm) ||
                !string.IsNullOrWhiteSpace(request.CityRequestParameters.SearchTerm))
            {
                var filterTerm = request.CityRequestParameters?.FilterTerm?.Trim();
                var searchTerm = request.CityRequestParameters?.SearchTerm?.Trim();

                cities = cities
                .Where(c => c.Name!.Equals(filterTerm, StringComparison.CurrentCultureIgnoreCase) ||
                (
                    c.Name!.Contains(searchTerm!, StringComparison.CurrentCultureIgnoreCase) ||
                    c.Country!.Contains(searchTerm!, StringComparison.CurrentCultureIgnoreCase)
                 )).ToList();

            }


            return Task.FromResult(PagedList<Domain.City>.ToPagedList(mappedCities, request.CityRequestParameters!.PageSize,
                request.CityRequestParameters.PageSize));
        }
    }
}