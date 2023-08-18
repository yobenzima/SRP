using MediatR;
using SRP.Application.DTOs.DocumentTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.DocumentTypes.Requests.Queries
{
    public class GetDocumentTypeDetailRequest : IRequest<DocumentTypeListDto>
    {
        public Guid Id { get; set; }
    }
}
