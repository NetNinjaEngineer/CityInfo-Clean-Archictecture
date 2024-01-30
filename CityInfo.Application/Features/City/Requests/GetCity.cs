using CityInfo.Application.DTOs;
using MediatR;

namespace CityInfo.Application.Features.City.Requests
{
    public class GetCity : IRequest<CityDto>
    {
        public int CityId { get; set; }

        public bool TrackChanges { get; set; }

    }
}
