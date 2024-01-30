using CityInfo.Application.DTOs.City;
using CityInfo.Application.Features.City.Responses;
using MediatR;

namespace CityInfo.Application.Features.City.Requests.Commands
{
    public class UpdateCityCommand : IRequest<UpdateCityCommandResponse>
    {
        public int CityId { get; set; }

        public CityForUpdateDto? CityForUpdateDto { get; set; }

    }
}
