using MediatR;

using Microsoft.AspNetCore.Mvc;

using SRP.Application.DTOs.Statuses;
using SRP.Application.Features.Statuses.Requests.Commands;
using SRP.Application.Features.Statuses.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IMediator mMediator;

        public StatusController(IMediator mediator)
        {
            mMediator = mediator;
        }

        // GET: api/<StatusController>
        [HttpGet]
        public async Task<ActionResult<List<StatusListDto>>> Get()
        {
            var tStatuses = await mMediator.Send(new GetStatusListRequest());
            return Ok(tStatuses);
        }

        // GET api/<StatusController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<StatusDto>> Get(Guid id)
        {
            var tRequest = new GetStatusDetailRequest { Id = id };
            var tStatus = await mMediator.Send(tRequest);
            return Ok(tStatus);
        }

        // POST api/<StatusController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateStatusDto province)
        {
            var tCommand = new CreateStatusCommand { StatusDto = province };
            var tResponse = await mMediator.Send(tCommand);
            return Ok(tResponse);
        }

        // PUT api/<StatusController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateStatusDto province)
        {
            var tCommand = new UpdateStatusCommand { Id = id, StatusDto = province };
            await mMediator.Send(tCommand);
            return NoContent();
        }

        // DELETE api/<StatusController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var tCommand = new DeleteStatusCommand { Id = id };
            await mMediator.Send(tCommand);
            return NoContent();
        }
    }
}
