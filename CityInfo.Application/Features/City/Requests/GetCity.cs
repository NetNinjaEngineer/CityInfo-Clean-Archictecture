using MediatR;

namespace CityInfo.Application.Features.City.Requests
{
    public class GetCity : IRequest<Domain.City>
    {
        public int CityId { get; set; }

        public bool TrackChanges { get; set; }

    }
}
