using CityInfo.Application.DTOs;
using CityInfo.Application.RequestFeatures;
using MediatR;

namespace CityInfo.Application.Features.PointOfInterest.Requests
{
    public class GetPagedPointsOfInterest : IRequest<PagedList<PointOfInterestDto>>
    {
        public PointOfInterestRequestParameters PointOfInterestRequestParameters { get; set; }
    }
}
