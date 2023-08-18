using MediatR;

using Microsoft.AspNetCore.Mvc;

using SRP.Application.DTOs.BEECertificationTypes;
using SRP.Application.Features.BEECertificationTypes.Requests.Commands;
using SRP.Application.Features.BEECertificationTypes.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BEECertificationTypeController : ControllerBase
    {
        private readonly IMediator mMediator;

        public BEECertificationTypeController(IMediator mediator)
        {
            mMediator = mediator;
        }

        // GET: api/<BEECertificationTypeController>
        [HttpGet]
        public async Task<ActionResult<List<BEECertificationTypeListDto>>> Get()
        {
            var tCertificationTypes = await mMediator.Send(new GetBEECertificationTypeDetailRequest());
            return Ok(tCertificationTypes);
        }


        // GET api/<BEECertificationTypeController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BEECertificationTypeDto>> Get(Guid id)
        {
            var tRequest = new GetBEECertificationTypeDetailRequest { Id = id };
            var tBEECertificationType = await mMediator.Send(tRequest);
            return Ok(tBEECertificationType);
        }


        // POST api/<BEECertificationTypeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateBEECertificationTypeDto address)
        {
            var tCommand = new CreateBEECertificationTypeCommand { BEECertificationTypeDto = address };
            var tResponse = await mMediator.Send(tCommand);
            return Ok(tResponse);
        }

        // PUT api/<BEECertificationTypeController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateBEECertificationTypeDto address)
        {
            var tCommand = new UpdateBEECertificationTypeCommand { Id = id, BEECertificationTypeDto = address };
            await mMediator.Send(tCommand);
            return NoContent();
        }

        // DELETE api/<BEECertificationTypeController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var tCommand = new DeleteBEECertificationTypeCommand { Id = id };
            await mMediator.Send(tCommand);
            return NoContent();
        }
    }
}
