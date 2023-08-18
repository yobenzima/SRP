using MediatR;

using Microsoft.AspNetCore.Mvc;
using SRP.Application.DTOs.LegalEntityTypes;
using SRP.Application.Features.LegalEntityTypes.Requests.Commands;

using SRP.Application.Features.LegalEntityTypes.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalEntityTypeController : ControllerBase
    {
        private readonly IMediator mMediator;

        public LegalEntityTypeController(IMediator mediator)
        {
            mMediator = mediator;
        }

        // GET: api/<LegalEntityTypeController>
        [HttpGet]
        public async Task<ActionResult<List<LegalEntityTypeDto>>> Get()
        {
            var tRequest = new GetLegalEntityTypeListRequest();
            var tLegalEntityTypes = await mMediator.Send(tRequest);
            return Ok(tLegalEntityTypes);
        }

        // GET api/<LegalEntityTypeController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<LegalEntityTypeDto>> Get(Guid id)
        {
            var tRequest = new GetLegalEntityTypeDetailRequest
            {
                Id = id
            };
            var tLegalEntityType = await mMediator.Send(tRequest);
            return Ok(tLegalEntityType);
        }

        // POST api/<LegalEntityTypeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLegalEntityTypeDto legalEntityType)
        {
            var tCommand = new CreateLegalEntityTypeCommand
            {
                LegalEntityTypeDto = legalEntityType
            };
            var tResponse = await mMediator.Send(tCommand);
            return Ok(tResponse);
        }

        // PUT api/<LegalEntityTypeController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateLegalEntityTypeDto legalEntityType)
        {
            var tCommand = new UpdateLegalEntityTypeCommand
            {
                Id = id,
                LegalEntityTypeDto = legalEntityType
            };
            await mMediator.Send(tCommand);
            return NoContent();
        }

        // DELETE api/<LegalEntityTypeController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var tCommand = new DeleteLegalEntityTypeCommand
            {
                Id = id
            };
            await mMediator.Send(tCommand);
            return NoContent();
        }
    }
}
