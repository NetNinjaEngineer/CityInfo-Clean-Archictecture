using CityInfo.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace CityInfo.Application.Features.City.Requests
{
    public class GetCityListRequest : IRequest<List<CityDto>>
    {
        public bool TrackChanges { get; set; }
    }
}
