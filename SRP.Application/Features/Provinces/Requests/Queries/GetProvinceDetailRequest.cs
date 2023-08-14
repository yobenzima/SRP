using MediatR;

using SRP.Application.DTOs.Provinces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Provinces.Requests.Queries;

public class GetProvinceDetailRequest : IRequest<ProvinceDto>
{
    public Guid Id { get; set; }
}
