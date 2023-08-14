using MediatR;

using SRP.Application.DTOs.Countries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Countries.Requests.Queries;

public class GetCountryListRequest : IRequest<List<CountryListDto>>
{
}
