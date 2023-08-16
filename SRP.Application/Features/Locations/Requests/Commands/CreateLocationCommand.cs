using MediatR;

using SRP.Application.DTOs.Locations;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Locations.Requests.Commands;

public class CreateLocationCommand : IRequest<BaseCommandResponse>
{
    public CreateLocationDto? LocationDto { get; set; }
}
