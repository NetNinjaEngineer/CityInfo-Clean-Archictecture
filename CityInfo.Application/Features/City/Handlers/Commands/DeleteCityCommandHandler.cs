using CityInfo.Application.Exceptions;
using CityInfo.Application.Features.City.Requests.Commands;
using CityInfo.Application.Features.City.Responses;
using CityInfo.Application.Persistence.Contracts;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.Application.Features.City.Handlers.Commands
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, DeleteCityCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCityCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteCityCommandResponse> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteCityCommandResponse();

            var city = _unitOfWork.CityRepository.GetAll(true, c => c.PointOfInterests)
                .FirstOrDefault(c => c.Id == request.CityId)
                ?? throw new NotFoundException(nameof(Domain.City), request.CityId);

            var deletedCity = _unitOfWork.CityRepository.Delete(city);

            await _unitOfWork.SaveChangesAsync();

            response.Success = true;
            response.Message = "Deleted Successfully .";
            response.Entity = deletedCity;

            return response;

        }
    }
}
