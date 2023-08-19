using MediatR;

using SRP.Application.DTOs.LocalMunicipalities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.LocalMunicipalities.Requests.Commands;

public class UpdateLocalMunicipalityCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public UpdateLocalMunicipalityDto? LocalMunicipalityDto { get; set; }
}

