using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.LocalMunicipalities.Requests.Commands;

public class DeleteLocalMunicipalityCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
