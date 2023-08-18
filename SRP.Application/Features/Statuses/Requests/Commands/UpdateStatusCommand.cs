using MediatR;

using SRP.Application.DTOs.Statuses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Statuses.Requests.Commands;

public class UpdateStatusCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public UpdateStatusDto? StatusDto { get; set; }
}

