using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Provinces.Requests.Commands;

public class DeleteProvinceCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
