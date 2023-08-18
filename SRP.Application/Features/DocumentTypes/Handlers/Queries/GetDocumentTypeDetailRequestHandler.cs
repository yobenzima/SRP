using AutoMapper;

using MediatR;
using SRP.Application.DTOs.DocumentTypes;
using SRP.Application.Features.DocumentTypes.Requests.Queries;
using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.DocumentTypes.Handlers.Queries
{
    public class GetDocumentTypeDetailRequestHandler : IRequestHandler<GetDocumentTypeDetailRequest, DocumentTypeListDto>
    {
        private readonly IDocumentTypeRepository mDocumentTypeRepository;
        private readonly IMapper mMapper;

        public GetDocumentTypeDetailRequestHandler(IDocumentTypeRepository addressTypeRepository, IMapper mapper)
        {
            mDocumentTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<DocumentTypeListDto> Handle(GetDocumentTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var tDocumentType = await mDocumentTypeRepository.GetByIdAsync(request.Id);
            return mMapper.Map<DocumentTypeListDto>(tDocumentType);
        }
    }
}
