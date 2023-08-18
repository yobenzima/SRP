using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.LegalEntityTypes.Requests.Commands
{
    public class DeleteLegalEntityTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
