using MediatR;

using SRP.Application.DTOs.Countries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Countries.Requests.Commands;

public class UpdateCountryCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public UpdateCountryDto? CountryDto { get; set; }
}
