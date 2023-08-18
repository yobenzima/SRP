using MediatR;

using SRP.Application.DTOs.Titles;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Titles.Requests.Queries;

public class GetTitleListRequest : IRequest<List<TitleListDto>>
{
}
