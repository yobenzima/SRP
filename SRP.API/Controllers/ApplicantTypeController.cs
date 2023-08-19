using MediatR;

using Microsoft.AspNetCore.Mvc;

using SRP.Application.DTOs.ApplicantTypes;
using SRP.Application.Features.ApplicantTypes.Requests.Commands;
using SRP.Application.Features.ApplicantTypes.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantTypeController : ControllerBase
    {
        private readonly IMediator mMediator;

        public ApplicantTypeController(IMediator mediator)
        {
            mMediator = mediator;
        }

        // GET: api/<ApplicantTypeController>
        [HttpGet]
        public async Task<ActionResult<List<ApplicantTypeDto>>> Get()
        {
            var tRequest = new GetApplicantTypeListRequest();
            var tApplicantTypes = await mMediator.Send(tRequest);
            return Ok(tApplicantTypes);
        }

        // GET api/<ApplicantTypeController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ApplicantTypeDto>> Get(Guid id)
        {
            var tRequest = new GetApplicantTypeDetailRequest
            {
                Id = id
            };
            var tApplicantType = await mMediator.Send(tRequest);
            return Ok(tApplicantType);
        }

        // POST api/<ApplicantTypeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateApplicantTypeDto applicantType)
        {
            var tCommand = new CreateApplicantTypeCommand
            {
                ApplicantTypeDto = applicantType
            };
            var tResponse = await mMediator.Send(tCommand);
            return Ok(tResponse);
        }

        // PUT api/<ApplicantTypeController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateApplicantTypeDto applicantType)
        {
            var tCommand = new UpdateApplicantTypeCommand
            {
                Id = id,
                ApplicantTypeDto = applicantType
            };
            await mMediator.Send(tCommand);
            return NoContent();
        }

        // DELETE api/<ApplicantTypeController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var tCommand = new DeleteApplicantTypeCommand
            {
                Id = id
            };
            await mMediator.Send(tCommand);
            return NoContent();
        }
    }
}
