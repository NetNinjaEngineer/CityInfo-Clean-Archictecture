using CityInfo.Application.DTOs;
using CityInfo.Application.RequestFeatures;
using MediatR;

namespace CityInfo.Application.Features.City.Requests
{
    public class GetPagedCities : IRequest<PagedList<CityDto>>
    {
        public CityRequestParameters CityRequestParameters { get; set; }
    }
}
