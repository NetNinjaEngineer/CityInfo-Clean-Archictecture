using AutoMapper;
using CityInfo.Application.Contracts.Persistence;
using CityInfo.Application.DTOs.City.Validators;
using CityInfo.Application.Exceptions;
using CityInfo.Application.Features.City.Requests.Commands;
using CityInfo.Application.Features.City.Responses;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.Application.Features.City.Handlers.Commands
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommand, UpdateCityCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateCityCommandResponse> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateCityCommandResponse();

            var validator = new CityForManipulationDtoValidator();

            var validationResult = await validator.ValidateAsync(request.CityForUpdateDto!);

            if (!validationResult.IsValid)
            {
                response.Id = request.CityId;
                response.Success = false;
                response.Message = "Update Failed.";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var city = _unitOfWork.CityRepository.GetAll(true,
                c => c.PointOfInterests)
               .FirstOrDefault(c => c.Id == request.CityId)
               ?? throw new NotFoundException(nameof(Domain.City), request.CityId);

            var updatedCity = _unitOfWork.CityRepository.Update(
                _mapper.Map(request.CityForUpdateDto, city));

            await _unitOfWork.SaveChangesAsync();

            response.Success = true;
            response.Message = "Update successfull.";
            response.Entity = updatedCity;

            return response;
        }
    }
}
