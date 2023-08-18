using MediatR;
using SRP.Application.DTOs.LegalEntityTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.LegalEntityTypes.Requests.Queries
{
    public class GetLegalEntityTypeDetailRequest : IRequest<LegalEntityTypeListDto>
    {
        public Guid Id { get; set; }
    }
}
