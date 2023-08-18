using MediatR;

using Microsoft.AspNetCore.Mvc;

using SRP.Application.DTOs.Titles;
using SRP.Application.Features.Titles.Requests.Commands;
using SRP.Application.Features.Titles.Requests.Queries;

namespace SRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly IMediator mMediator;

        public TitleController(IMediator mediator)
        {
            mMediator = mediator;
        }

        // GET: api/<TitleController>
        [HttpGet]
        public async Task<ActionResult<List<TitleListDto>>> Get()
        {
            var tTitles = await mMediator.Send(new GetTitleListRequest());
            return Ok(tTitles);
        }

        // GET api/<TitleController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TitleDto>> Get(Guid id)
        {
            var tRequest = new GetTitleDetailRequest { Id = id };
            var tTitle = await mMediator.Send(tRequest);
            return Ok(tTitle);
        }

        // POST api/<TitleController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateTitleDto province)
        {
            var tCommand = new CreateTitleCommand { TitleDto = province };
            var tResponse = await mMediator.Send(tCommand);
            return Ok(tResponse);
        }

        // PUT api/<TitleController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateTitleDto province)
        {
            var tCommand = new UpdateTitleCommand { Id = id, TitleDto = province };
            await mMediator.Send(tCommand);
            return NoContent();
        }

        // DELETE api/<TitleController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var tCommand = new DeleteTitleCommand { Id = id };
            await mMediator.Send(tCommand);
            return NoContent();
        }
    }
}
