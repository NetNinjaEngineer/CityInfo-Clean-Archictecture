using CityInfo.Application.DTOs.PointOfInterest;
using MediatR;

namespace CityInfo.Application.Features.PointOfInterest.Requests
{
    public class GetPointOfInterest : IRequest<PointOfInterestDto>
    {
        public int CityId { get; set; }

        public int PointOfInterestId { get; set; }

        public bool TrackChanges { get; set; }

    }
}
