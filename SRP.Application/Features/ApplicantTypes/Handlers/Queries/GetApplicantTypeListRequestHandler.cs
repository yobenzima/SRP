using AutoMapper;

using MediatR;
using SRP.Application.DTOs.ApplicantTypes;
using SRP.Application.Features.ApplicantTypes.Requests.Queries;
using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.ApplicantTypes.Handlers.Queries
{
    public class GetApplicantTypeListRequestHandler : IRequestHandler<GetApplicantTypeListRequest, List<ApplicantTypeListDto>>
    {
        private readonly IApplicantTypeRepository mApplicantTypeRepository;
        private readonly IMapper mMapper;

        public GetApplicantTypeListRequestHandler(IApplicantTypeRepository addressTypeRepository, IMapper mapper)
        {
            mApplicantTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<List<ApplicantTypeListDto>> Handle(GetApplicantTypeListRequest request, CancellationToken cancellationToken)
        {
            var tApplicantType = await mApplicantTypeRepository.GetAllAsync();
            return mMapper.Map<List<ApplicantTypeListDto>>(tApplicantType);
        }
    }
}
