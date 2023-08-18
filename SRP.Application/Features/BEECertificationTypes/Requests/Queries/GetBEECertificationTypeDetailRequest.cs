using MediatR;

using SRP.Application.DTOs.BEECertificationTypes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.BEECertificationTypes.Requests.Queries;

public class GetBEECertificationTypeDetailRequest : IRequest<BEECertificationTypeDto>
{
    public Guid Id { get; set; }
}
