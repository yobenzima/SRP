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
    public class GetLegalEntityTypeDetailRequestHandler : IRequestHandler<GetLegalEntityTypeDetailRequest, LegalEntityTypeListDto>
    {
        private readonly ILegalEntityTypeRepository mLegalEntityTypeRepository;
        private readonly IMapper mMapper;

        public GetLegalEntityTypeDetailRequestHandler(ILegalEntityTypeRepository addressTypeRepository, IMapper mapper)
        {
            mLegalEntityTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<LegalEntityTypeListDto> Handle(GetLegalEntityTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var tLegalEntityType = await mLegalEntityTypeRepository.GetByIdAsync(request.Id);
            return mMapper.Map<LegalEntityTypeListDto>(tLegalEntityType);
        }
    }
}
