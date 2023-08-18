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
    public class GetDocumentTypeListRequestHandler : IRequestHandler<GetDocumentTypeListRequest, List<DocumentTypeListDto>>
    {
        private readonly IDocumentTypeRepository mDocumentTypeRepository;
        private readonly IMapper mMapper;

        public GetDocumentTypeListRequestHandler(IDocumentTypeRepository addressTypeRepository, IMapper mapper)
        {
            mDocumentTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<List<DocumentTypeListDto>> Handle(GetDocumentTypeListRequest request, CancellationToken cancellationToken)
        {
            var tDocumentType = await mDocumentTypeRepository.GetAllSortedAsync();
            return mMapper.Map<List<DocumentTypeListDto>>(tDocumentType);
        }
    }
}
