using MediatR;

using SRP.Application.DTOs.DocumentTypes;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.DocumentTypes.Requests.Commands
{
    public class CreateDocumentTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateDocumentTypeDto? DocumentTypeDto { get; set; }
    }
}
