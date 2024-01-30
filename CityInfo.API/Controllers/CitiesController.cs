using CityInfo.Application.DTOs.City;
using CityInfo.Application.Features.City.Requests;
using CityInfo.Application.Features.City.Requests.Commands;
using CityInfo.Application.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CitiesController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> CreateCityAsync([FromBody] CityForCreationDto requestModel)
        {
            var response = await _mediator.Send(new CreateCityCommand { CityForCreationDto = requestModel });

            return !response.Success ? BadRequest(response) : Ok(response);

        }

        [Route("CityListRequest")]
        [HttpGet]
        public async Task<IActionResult> GetCityListRequestAsync()
        {
            var citiesList = await _mediator.Send(new GetCityList { TrackChanges = true });
            return Ok(citiesList);
        }

        [Route("PagedCities")]
        [HttpGet]
        public async Task<IActionResult> GetCitiesByRequestParametersAsync([FromQuery] CityRequestParameters cityRequestParameters)
        {
            var pagedResult = await _mediator.Send(new GetPagedCities
            {
                CityRequestParameters = cityRequestParameters
            });

            return Ok(pagedResult);
        }

        [HttpGet("{cityId}")]
        public async Task<IActionResult> GetCityAsync(int cityId, bool trackChanges)
        {
            try
            {
                return Ok(await _mediator.Send(new GetCity { CityId = cityId, TrackChanges = trackChanges }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{cityId}")]
        public async Task<IActionResult> UpdateCityAsync(int cityId, CityForUpdateDto requestModel)
        {
            try
            {
                return Ok(await _mediator.Send(new UpdateCityCommand
                {
                    CityId = cityId,
                    CityForUpdateDto = requestModel
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{cityId}")]
        public async Task<IActionResult> DeleteCityAsync(int cityId)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteCityCommand { CityId = cityId }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
