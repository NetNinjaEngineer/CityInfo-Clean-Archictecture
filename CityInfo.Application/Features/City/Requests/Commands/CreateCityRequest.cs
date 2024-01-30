using CityInfo.Application.DTOs;
using MediatR;

namespace CityInfo.Application.Features.City.Requests.Commands
{
    public class CreateCityCommand : IRequest<CityDto>
    {
        public CityDto CityDto { get; set; }
    }
}
