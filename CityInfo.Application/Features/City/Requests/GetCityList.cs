using MediatR;
using System.Collections.Generic;

namespace CityInfo.Application.Features.City.Requests
{
    public class GetCityList : IRequest<List<Domain.City>>
    {
        public bool TrackChanges { get; set; }
    }
}
