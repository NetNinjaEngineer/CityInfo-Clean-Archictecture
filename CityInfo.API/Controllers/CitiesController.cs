using CityInfo.Application.Features.City.Requests;
using CityInfo.Application.RequestFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityInfo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CitiesController>
        [HttpGet("GetCityListRequest")]
        public async Task<IActionResult> GetCityListRequestAsync()
        {
            var citiesList = await _mediator.Send(new GetCityList { TrackChanges = true });
            return Ok(citiesList);
        }

        [HttpGet("GetPagedCities")]
        public async Task<IActionResult> GetPagedCitiesAsync([FromQuery] CityRequestParameters cityRequestParameters)
        {
            var pagedResult = await _mediator.Send(new GetPagedCities
            {
                CityRequestParameters = cityRequestParameters
            });

            return Ok(pagedResult);
        }

        // GET api/<CitiesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CitiesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CitiesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CitiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
