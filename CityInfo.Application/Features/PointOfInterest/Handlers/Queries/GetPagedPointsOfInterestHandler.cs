using AutoMapper;
using CityInfo.Application.DTOs;
using CityInfo.Application.Features.PointOfInterest.Requests;
using CityInfo.Application.Persistence.Contracts;
using CityInfo.Application.RequestFeatures;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.Application.Features.PointOfInterest.Handlers.Queries
{
    public class GetPagedPointsOfInterestHandler
        : IRequestHandler<GetPagedPointsOfInterest, PagedList<PointOfInterestDto>>
    {
        private readonly IPointOfInterestRepository _pointOfInterestRepository;
        private readonly IMapper _mapper;

        public GetPagedPointsOfInterestHandler(IPointOfInterestRepository pointOfInterestRepository, IMapper mapper)
        {
            _pointOfInterestRepository = pointOfInterestRepository;
            _mapper = mapper;
        }

        public Task<PagedList<PointOfInterestDto>> Handle(GetPagedPointsOfInterest request, CancellationToken cancellationToken)
        {
            if (request.PointOfInterestRequestParameters is null)
                throw new ArgumentNullException(nameof(request.PointOfInterestRequestParameters));

            var pointsOfInterest = _pointOfInterestRepository.GetAll(true, c => c.City).ToList();

            var mappedPointOfInterest = _mapper.Map<PagedList<PointOfInterestDto>>(pointsOfInterest);

            if (string.IsNullOrEmpty(request.PointOfInterestRequestParameters.SearchTerm)
                && string.IsNullOrEmpty(request.PointOfInterestRequestParameters.FilterTerm))
                return Task.FromResult(PagedList<PointOfInterestDto>.ToPagedList(mappedPointOfInterest,
                    request.PointOfInterestRequestParameters.PageNumber, request.PointOfInterestRequestParameters.PageSize));

            if (!string.IsNullOrWhiteSpace(request.PointOfInterestRequestParameters.FilterTerm) ||
              !string.IsNullOrWhiteSpace(request.PointOfInterestRequestParameters.SearchTerm))
            {
                var filterTerm = request.PointOfInterestRequestParameters.FilterTerm?.Trim();
                var searchTerm = request.PointOfInterestRequestParameters.SearchTerm?.Trim();

                pointsOfInterest = pointsOfInterest
                    .Where(point => point.Name!.Equals(filterTerm, StringComparison.CurrentCultureIgnoreCase) ||
                    (
                        point.Name!.Contains(searchTerm!, StringComparison.CurrentCultureIgnoreCase) ||
                        point.Category!.Contains(searchTerm!, StringComparison.CurrentCultureIgnoreCase) ||
                        point.Description!.Contains(searchTerm!, StringComparison.CurrentCultureIgnoreCase)
                     )).ToList();
            }

            return Task.FromResult(PagedList<PointOfInterestDto>.ToPagedList(mappedPointOfInterest,
                request.PointOfInterestRequestParameters.PageNumber,
                request.PointOfInterestRequestParameters.PageSize));
        }
    }
}