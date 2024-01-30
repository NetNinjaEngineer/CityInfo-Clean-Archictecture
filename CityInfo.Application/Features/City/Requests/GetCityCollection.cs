using MediatR;
using System.Collections.Generic;

namespace CityInfo.Application.Features.City.Requests
{
    public class GetCityCollection : IRequest<List<Domain.City>>
    {
        public IEnumerable<int> Ids { get; set; }
    }
}
