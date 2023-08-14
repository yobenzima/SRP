using MediatR;

using SRP.Application.DTOs.Countries;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Countries.Requests.Commands;

public class CreateCountryCommand : IRequest<BaseCommandResponse>
{
    public CreateCountryDto? CountryDto { get; set; }
}
