using MediatR;

using SRP.Application.DTOs.Statuses;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Statuses.Requests.Commands;

public class CreateStatusCommand : IRequest<BaseCommandResponse>
{
    public CreateStatusDto? StatusDto { get; set; }
}
