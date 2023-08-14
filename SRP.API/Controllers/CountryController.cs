using MediatR;

using Microsoft.AspNetCore.Mvc;

using SRP.Application.DTOs.Countries;
using SRP.Application.Features.Addresses.Requests.Commands;
using SRP.Application.Features.Addresses.Requests.Queries;
using SRP.Application.Features.Countries.Requests.Commands;
using SRP.Application.Features.Countries.Requests.Queries;
using SRP.Domain.Entities;

using System.Net;

namespace SRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator mMediator;

        public CountryController(IMediator mediator)
        {
            mMediator = mediator;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public async Task<ActionResult<List<CountryDto>>> Get()
        {
            var tCountries = await mMediator.Send(new GetCountryListRequest());
            return Ok(tCountries);
        }

        // GET api/<CountryController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CountryDto>> Get(Guid id)
        {
            var tRequest = new GetCountryDetailRequest { Id = id };
            var tCountry = await mMediator.Send(tRequest);
            return Ok(tCountry);
        }

        // POST api/<CountryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCountryDto country)
        {
            var tCommand = new CreateCountryCommand { CountryDto = country };
            var tResponse = await mMediator.Send(tCommand);
            return Ok(tResponse);
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateCountryDto country)
        {
            var tCommand = new UpdateCountryCommand { Id = id, CountryDto = country };
            await mMediator.Send(tCommand);
            return NoContent();
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var tCommand = new DeleteCountryCommand { Id = id };
            await mMediator.Send(tCommand);
            return NoContent();
        }
    }
}
