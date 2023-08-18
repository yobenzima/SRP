using MediatR;

using Microsoft.AspNetCore.Mvc;
using SRP.Application.DTOs.DocumentTypes;
using SRP.Application.Features.DocumentTypes.Requests.Commands;

using SRP.Application.Features.DocumentTypes.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SRP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IMediator mMediator;

        public DocumentTypeController(IMediator mediator)
        {
            mMediator = mediator;
        }

        // GET: api/<DocumentTypeController>
        [HttpGet]
        public async Task<ActionResult<List<DocumentTypeDto>>> Get()
        {
            var tRequest = new GetDocumentTypeListRequest();
            var tDocumentTypes = await mMediator.Send(tRequest);
            return Ok(tDocumentTypes);
        }

        // GET api/<DocumentTypeController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DocumentTypeDto>> Get(Guid id)
        {
            var tRequest = new GetDocumentTypeDetailRequest
            {
                Id = id
            };
            var tDocumentType = await mMediator.Send(tRequest);
            return Ok(tDocumentType);
        }

        // POST api/<DocumentTypeController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateDocumentTypeDto documentType)
        {
            var tCommand = new CreateDocumentTypeCommand
            {
                DocumentTypeDto = documentType
            };
            var tResponse = await mMediator.Send(tCommand);
            return Ok(tResponse);
        }

        // PUT api/<DocumentTypeController>/5
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] UpdateDocumentTypeDto documentType)
        {
            var tCommand = new UpdateDocumentTypeCommand
            {
                Id = id,
                DocumentTypeDto = documentType
            };
            await mMediator.Send(tCommand);
            return NoContent();
        }

        // DELETE api/<DocumentTypeController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var tCommand = new DeleteDocumentTypeCommand
            {
                Id = id
            };
            await mMediator.Send(tCommand);
            return NoContent();
        }
    }
}
