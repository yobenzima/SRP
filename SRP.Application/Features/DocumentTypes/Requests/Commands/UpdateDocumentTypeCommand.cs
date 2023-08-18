using MediatR;

using SRP.Application.DTOs.DocumentTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.DocumentTypes.Requests.Commands
{
    public class UpdateDocumentTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public UpdateDocumentTypeDto? DocumentTypeDto { get; set; }
    }
}
