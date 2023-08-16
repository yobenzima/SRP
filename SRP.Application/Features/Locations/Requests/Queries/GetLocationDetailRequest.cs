using MediatR;

using SRP.Application.DTOs.Locations;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Locations.Requests.Queries;

public class GetLocationDetailRequest : IRequest<LocationDto>
{
    public Guid Id { get; set; }
}
