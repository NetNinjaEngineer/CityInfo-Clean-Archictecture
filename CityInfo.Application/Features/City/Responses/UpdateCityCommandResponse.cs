using CityInfo.Application.Features.City.Responses.Common;
using CityInfo.Application.Responses;

namespace CityInfo.Application.Features.City.Responses
{
    public class UpdateCityCommandResponse : BaseCommandResponse, ICommonCommandResponse
    {
        public object? Entity { get; set; }
    }
}
