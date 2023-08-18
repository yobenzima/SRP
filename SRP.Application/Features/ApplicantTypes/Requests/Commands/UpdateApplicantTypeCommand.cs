using MediatR;

using SRP.Application.DTOs.ApplicantTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.ApplicantTypes.Requests.Commands
{
    public class UpdateApplicantTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public UpdateApplicantTypeDto? ApplicantTypeDto { get; set; }
    }
}
