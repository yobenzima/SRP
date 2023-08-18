using MediatR;

using SRP.Application.DTOs.LegalEntityTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.LegalEntityTypes.Requests.Commands
{
    public class UpdateLegalEntityTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public UpdateLegalEntityTypeDto? LegalEntityTypeDto { get; set; }
    }
}
