using CityInfo.Application.DTOs.City;
using CityInfo.Application.Features.City.Responses;
using MediatR;

namespace CityInfo.Application.Features.City.Requests.Commands
{
    public class CreateCityCommand : IRequest<CreateCityCommandResponse>
    {
        public CityForCreationDto? CityForCreationDto { get; set; }
    }
}
