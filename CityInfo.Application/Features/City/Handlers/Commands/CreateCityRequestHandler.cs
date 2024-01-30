using AutoMapper;
using CityInfo.Application.DTOs;
using CityInfo.Application.Features.City.Requests.Commands;
using CityInfo.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CityInfo.Application.Features.City.Handlers.Commands
{
    public class CreateCityRequestHandler : IRequestHandler<CreateCityCommand, CityDto>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;


        public CreateCityRequestHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public Task<CityDto> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var cityForCreation = _mapper.Map<Domain.City>(request.CityDto);
            var createdCity = _cityRepository.Create(cityForCreation);
            var cityToReturn = _mapper.Map<CityDto>(createdCity);
            return Task.FromResult(cityToReturn);

        }
    }
}
