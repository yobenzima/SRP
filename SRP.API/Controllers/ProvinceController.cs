using MediatR;

using Microsoft.AspNetCore.Mvc;

using SRP.Application.DTOs.Provinces;
using SRP.Application.Features.Provinces.Requests.Commands;
using SRP.Application.Features.Provinces.Requests.Queries;

namespace SRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IMediator mMediator;

        public ProvinceController(IMediator mediator)
        {
            mMediator = mediator;
        }

        // GET: api/<ProvinceController>
        [HttpGet]
        public async Task<ActionResult<List<ProvinceListDto>>> Get()
        {
            var tProvinces = await mMediator.Send(new GetProvinceListRequest());
            return Ok(tProvinces);
        }

        // GET api/<ProvinceController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProvinceDto>> Get(Guid id)
        {
            var tRequest = new GetProvinceDetailRequest { Id = id };
            var tProvince = await mMediator.Send(tRequest);
            return Ok(tProvince);
        }

        // POST api/<ProvinceController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateProvinceDto province)
        {
            var tCommand = new CreateProvinceCommand { ProvinceDto = province };
            var tResponse = await mMediator.Send(tCommand);
            return Ok(tResponse);
        }

        // PUT api/<ProvinceController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateProvinceDto province)
        {
            var tCommand = new UpdateProvinceCommand { Id = id, ProvinceDto = province };
            await mMediator.Send(tCommand);
            return NoContent();
        }

        // DELETE api/<ProvinceController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var tCommand = new DeleteProvinceCommand { Id = id };
            await mMediator.Send(tCommand);
            return NoContent();
        }
    }
}
