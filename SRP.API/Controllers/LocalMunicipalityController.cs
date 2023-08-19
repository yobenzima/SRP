using MediatR;

using Microsoft.AspNetCore.Mvc;

using SRP.Application.DTOs.LocalMunicipalities;
using SRP.Application.Features.LocalMunicipalities.Requests.Commands;
using SRP.Application.Features.LocalMunicipalities.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalMunicipalityController : ControllerBase
    {
        private readonly IMediator mMediator;

        public LocalMunicipalityController(IMediator mediator)
        {
            mMediator = mediator;
        }

        // GET: api/<LocalMunicipalityController>
        [HttpGet]
        public async Task<ActionResult<List<LocalMunicipalityListDto>>> Get()
        {
            var tLocalMunicipalities = await mMediator.Send(new GetLocalMunicipalityListRequest());
            return Ok(tLocalMunicipalities);
        }

        // GET api/<LocalMunicipalityController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LocalMunicipalityDto>> Get(Guid id)
        {
            var tRequest = new GetLocalMunicipalityDetailRequest { Id = id };
            var tLocalMunicipality = await mMediator.Send(tRequest);
            return Ok(tLocalMunicipality);
        }

        // POST api/<LocalMunicipalityController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLocalMunicipalityDto localMunicipality)
        {
            var tCommand = new CreateLocalMunicipalityCommand { LocalMunicipalityDto = localMunicipality };
            var tResponse = await mMediator.Send(tCommand);
            return Ok(tResponse);
        }

        // PUT api/<LocalMunicipalityController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateLocalMunicipalityDto localMunicipality)
        {
            var tCommand = new UpdateLocalMunicipalityCommand { Id = id, LocalMunicipalityDto = localMunicipality };
            await mMediator.Send(tCommand);
            return NoContent();
        }

        // DELETE api/<LocalMunicipalityController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var tCommand = new DeleteLocalMunicipalityCommand { Id = id };
            await mMediator.Send(tCommand);
            return NoContent();
        }
    }
}
