using AutoMapper;
using CityInfo.Application.Contracts.Persistence;
using CityInfo.Application.DTOs.City.Validators;
using CityInfo.Application.Features.City.Requests.Commands;
using CityInfo.Application.Features.City.Responses;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.Application.Features.City.Handlers.Commands
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CreateCityCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateCityCommandResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var response = new CreateCityCommandResponse();

            var validator = new CityForManipulationDtoValidator();

            var validationResult = await validator.ValidateAsync(request.CityForCreationDto!);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            var cityForCreation = _mapper.Map<Domain.City>(request.CityForCreationDto);

            var createdCity = _unitOfWork.CityRepository.Create(cityForCreation);

            await _unitOfWork.SaveChangesAsync();

            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = createdCity.Id;
            response.Entity = createdCity;

            return response;

        }
    }
}
