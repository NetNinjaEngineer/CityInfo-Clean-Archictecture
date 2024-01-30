using MediatR;
using System.Collections.Generic;

namespace CityInfo.Application.Features.City.Requests
{
    public class GetCityListRequest : IRequest<List<Domain.City>>
    {
        public bool TrackChanges { get; set; }
    }
}
