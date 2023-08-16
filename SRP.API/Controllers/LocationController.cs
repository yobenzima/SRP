using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SRP.Application.DTOs.Locations;
using SRP.Application.Features.Countries.Requests.Commands;

using SRP.Application.Features.Countries.Requests.Queries;
using SRP.Application.Features.Locations.Requests.Commands;
using SRP.Application.Features.Locations.Requests.Queries;

namespace SRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator mMediator;

        public LocationController(IMediator mediator)
        {
            mMediator = mediator;
        }

        // GET: api/<LocationController>
        [HttpGet]
        public async Task<ActionResult<List<LocationDto>>> Get()
        {
            var tCountries = await mMediator.Send(new GetLocationListRequest());
            return Ok(tCountries);
        }

        // GET api/<LocationController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LocationDto>> Get(Guid id)
        {
            var tRequest = new GetLocationDetailRequest { Id = id };
            var tLocation = await mMediator.Send(tRequest);
            return Ok(tLocation);
        }

        // POST api/<LocationController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLocationDto location)
        {
            var tCommand = new CreateLocationCommand { LocationDto = location };
            var tResponse = await mMediator.Send(tCommand);
            return Ok(tResponse);
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateLocationDto location)
        {
            var tCommand = new UpdateLocationCommand { Id = id, LocationDto = location };
            await mMediator.Send(tCommand);
            return NoContent();
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var tCommand = new DeleteLocationCommand { Id = id };
            await mMediator.Send(tCommand);
            return NoContent();
        }
    }
}
