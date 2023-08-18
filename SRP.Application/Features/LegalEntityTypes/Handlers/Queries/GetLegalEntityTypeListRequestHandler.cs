using AutoMapper;

using MediatR;
using SRP.Application.DTOs.LegalEntityTypes;
using SRP.Application.Features.LegalEntityTypes.Requests.Queries;
using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.LegalEntityTypes.Handlers.Queries
{
    public class GetLegalEntityTypeListRequestHandler : IRequestHandler<GetLegalEntityTypeListRequest, List<LegalEntityTypeListDto>>
    {
        private readonly ILegalEntityTypeRepository mLegalEntityTypeRepository;
        private readonly IMapper mMapper;

        public GetLegalEntityTypeListRequestHandler(ILegalEntityTypeRepository addressTypeRepository, IMapper mapper)
        {
            mLegalEntityTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<List<LegalEntityTypeListDto>> Handle(GetLegalEntityTypeListRequest request, CancellationToken cancellationToken)
        {
            var tLegalEntityType = await mLegalEntityTypeRepository.GetAllAsync();
            return mMapper.Map<List<LegalEntityTypeListDto>>(tLegalEntityType);
        }
    }
}
