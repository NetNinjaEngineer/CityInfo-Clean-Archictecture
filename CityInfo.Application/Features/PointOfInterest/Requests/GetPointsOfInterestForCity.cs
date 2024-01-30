using CityInfo.Application.DTOs.PointOfInterest;
using MediatR;
using System.Collections.Generic;

namespace CityInfo.Application.Features.PointOfInterest.Requests
{
    public class GetPointsOfInterestForCity : IRequest<List<PointOfInterestDto>>
    {
        public int CityId { get; set; }

        public bool TrackChanges { get; set; }

    }
}
