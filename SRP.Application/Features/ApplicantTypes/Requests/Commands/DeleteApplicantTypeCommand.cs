using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.ApplicantTypes.Requests.Commands
{
    public class DeleteApplicantTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
