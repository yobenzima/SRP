using MediatR;

using SRP.Application.DTOs.ApplicantTypes;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.ApplicantTypes.Requests.Commands
{
    public class CreateApplicantTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateApplicantTypeDto? ApplicantTypeDto { get; set; }
    }
}
