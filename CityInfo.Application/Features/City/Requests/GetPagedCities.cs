using CityInfo.Application.RequestFeatures;
using MediatR;

namespace CityInfo.Application.Features.City.Requests
{
    public class GetPagedCities : IRequest<PagedList<Domain.City>>
    {
        public CityRequestParameters CityRequestParameters { get; set; }
    }
}
