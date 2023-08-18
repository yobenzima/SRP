using MediatR;

using SRP.Application.DTOs.Titles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Titles.Requests.Queries;

public class GetTitleDetailRequest : IRequest<TitleDto>
{
    public Guid Id { get; set; }
}
