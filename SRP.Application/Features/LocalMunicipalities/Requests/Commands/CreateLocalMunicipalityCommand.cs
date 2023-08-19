using MediatR;

using SRP.Application.DTOs.LocalMunicipalities;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.LocalMunicipalities.Requests.Commands;

public class CreateLocalMunicipalityCommand : IRequest<BaseCommandResponse>
{
    public CreateLocalMunicipalityDto? LocalMunicipalityDto { get; set; }
}
