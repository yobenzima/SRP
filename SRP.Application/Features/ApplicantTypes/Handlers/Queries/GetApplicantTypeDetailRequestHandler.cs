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
    public class GetApplicantTypeDetailRequestHandler : IRequestHandler<GetApplicantTypeDetailRequest, ApplicantTypeListDto>
    {
        private readonly IApplicantTypeRepository mApplicantTypeRepository;
        private readonly IMapper mMapper;

        public GetApplicantTypeDetailRequestHandler(IApplicantTypeRepository addressTypeRepository, IMapper mapper)
        {
            mApplicantTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<ApplicantTypeListDto> Handle(GetApplicantTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var tApplicantType = await mApplicantTypeRepository.GetByIdAsync(request.Id);
            return mMapper.Map<ApplicantTypeListDto>(tApplicantType);
        }
    }
}
