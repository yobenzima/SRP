using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.DocumentTypes.Requests.Commands
{
    public class DeleteDocumentTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
