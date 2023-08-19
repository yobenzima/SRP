using MediatR;

using SRP.Application.DTOs.LocalMunicipalities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.LocalMunicipalities.Requests.Queries;

public class GetLocalMunicipalityListRequest : IRequest<List<LocalMunicipalityListDto>>
{
}
