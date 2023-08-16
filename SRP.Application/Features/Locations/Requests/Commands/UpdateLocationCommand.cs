using MediatR;

using SRP.Application.DTOs.Locations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Locations.Requests.Commands;

public class UpdateLocationCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public UpdateLocationDto? LocationDto { get; set; }
}
