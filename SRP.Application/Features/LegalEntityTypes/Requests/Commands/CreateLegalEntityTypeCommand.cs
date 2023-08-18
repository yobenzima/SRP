using MediatR;

using SRP.Application.DTOs.LegalEntityTypes;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.LegalEntityTypes.Requests.Commands
{
    public class CreateLegalEntityTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateLegalEntityTypeDto? LegalEntityTypeDto { get; set; }
    }
}
