using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Titles.Requests.Commands;

public class DeleteTitleCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
}
