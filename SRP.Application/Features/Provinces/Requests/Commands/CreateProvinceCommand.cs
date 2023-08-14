using MediatR;

using SRP.Application.DTOs.Provinces;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Provinces.Requests.Commands;

public class CreateProvinceCommand : IRequest<BaseCommandResponse>
{
    public CreateProvinceDto? ProvinceDto { get; set; }
}
