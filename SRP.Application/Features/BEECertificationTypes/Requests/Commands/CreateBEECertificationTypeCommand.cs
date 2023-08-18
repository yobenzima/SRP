using MediatR;

using SRP.Application.DTOs.BEECertificationTypes;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.BEECertificationTypes.Requests.Commands;

public class CreateBEECertificationTypeCommand : IRequest<BaseCommandResponse>
{
    public CreateBEECertificationTypeDto? BEECertificationTypeDto { get; set; }
}
