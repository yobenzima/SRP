using MediatR;

using SRP.Application.DTOs.Titles;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Titles.Requests.Commands;

public class CreateTitleCommand : IRequest<BaseCommandResponse>
{
    public CreateTitleDto? TitleDto { get; set; }
}
