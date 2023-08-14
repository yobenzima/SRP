using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Countries.Requests.Commands;

public class DeleteCountryCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
