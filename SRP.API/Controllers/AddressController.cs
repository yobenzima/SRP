using MediatR;

using Microsoft.AspNetCore.Mvc;

using SRP.Application.DTOs.Address;
using SRP.Application.Features.Addresses.Requests.Commands;
using SRP.Application.Features.Addresses.Requests.Queries;

namespace SRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator mMediator;   

        public AddressController(IMediator mediator)
        {
            mMediator = mediator;
        }

        // GET: api/<AddressController>
        [HttpGet]
        public async Task<ActionResult<List<AddressDto>>> Get()
        {
            var tAddresses = await mMediator.Send(new GetAddressListRequest());
            return Ok(tAddresses);
        }

        // GET api/<AddressController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AddressDto>> Get(Guid id)
        {
            var tRequest = new GetAddressDetailRequest { Id = id };
            var tAddress = await mMediator.Send(tRequest);
            return Ok(tAddress);
        }

        // POST api/<AddressController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateAddressDto address)
        {
            var tCommand = new CreateAddressCommand { AddressDto = address };
            var tResponse = await mMediator.Send(tCommand);
            return Ok(tResponse);
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateAddressDto address)
        {
            var tCommand = new UpdateAddressCommand { Id = id, AddressDto = address };
            await mMediator.Send(tCommand);
            return NoContent();
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var tCommand = new DeleteAddressCommand {  Id = id };
            await mMediator.Send(tCommand);
            return NoContent();
        }
    }
}
