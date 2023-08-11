using MediatR;

using Microsoft.AspNetCore.Mvc;

using SRP.Application.DTOs.AddressType;
using SRP.Application.Features.AddressTypes.Requests.Commands;
using SRP.Application.Features.AddressTypes.Requests.Queries;

namespace SRP.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressTypeController : ControllerBase
{
    private readonly IMediator mMediator;

    public AddressTypeController(IMediator mediator)
    {
        mMediator = mediator;
    }

    // GET: api/<AddressTypeController>
    [HttpGet]
    public async Task<ActionResult<List<AddressTypeDto>>> Get()
    {
        var tRequest = new GetAddressTypeListRequest();
        var tAddressTypes = await mMediator.Send(tRequest);
        return Ok(tAddressTypes);
    }

    // GET api/<AddressTypeController>/5
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AddressTypeDto>> Get(Guid id)
    {
        var tRequest = new GetAddressTypeDetailRequest
        {
            Id = id
        };
        var tAddressType = await mMediator.Send(tRequest);
        return Ok(tAddressType);
    }

    // POST api/<AddressTypeController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreateAddressTypeDto addressType)
    {
        var tCommand = new CreateAddressTypeCommand
        {
            AddressTypeDto = addressType
        };
        var tResponse = await mMediator.Send(tCommand);
        return Ok(tResponse);
    }

    // PUT api/<AddressTypeController>/5
    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Put(Guid id, [FromBody] UpdateAddressTypeDto addressType)
    {
        var tCommand = new UpdateAddressTypeCommand
        {
            Id = id,
            AddressTypeDto = addressType
        };
        await mMediator.Send(tCommand);
        return NoContent();
    }

    // DELETE api/<AddressTypeController>/5
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var tCommand = new DeleteAddressTypeCommand
        {
            Id = id
        };
        await mMediator.Send(tCommand);
        return NoContent();
    }
}
