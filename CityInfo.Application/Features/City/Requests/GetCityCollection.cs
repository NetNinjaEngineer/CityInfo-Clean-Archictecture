using CityInfo.Application.DTOs;
using MediatR;
using System.Collections.Generic;

namespace CityInfo.Application.Features.City.Requests
{
    public class GetCityCollection : IRequest<List<CityDto>>
    {
        public IEnumerable<int> Ids { get; set; }
    }
}
