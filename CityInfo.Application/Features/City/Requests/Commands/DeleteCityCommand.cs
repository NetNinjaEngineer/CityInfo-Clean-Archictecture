using CityInfo.Application.Features.City.Responses;
using MediatR;

namespace CityInfo.Application.Features.City.Requests.Commands
{
    public class DeleteCityCommand : IRequest<DeleteCityCommandResponse>
    {
        public int CityId { get; set; }
    }
}
