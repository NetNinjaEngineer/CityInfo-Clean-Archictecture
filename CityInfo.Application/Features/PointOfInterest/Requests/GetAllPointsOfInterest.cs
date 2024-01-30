using CityInfo.Application.DTOs.PointOfInterest;
using MediatR;
using System.Collections.Generic;

namespace CityInfo.Application.Features.PointOfInterest.Requests
{
    public class GetAllPointsOfInterest : IRequest<List<PointOfInterestDto>>
    {
        public bool TrackChanges { get; set; }
    }
}
