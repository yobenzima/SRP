using AutoMapper;
using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.BEECertificationTypes;
using SRP.Application.Features.BEECertificationTypes.Requests.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.BEECertificationTypes.Handlers.Queries;

public class GetBEECertificationTypeDetailRequestHandler : IRequestHandler<GetBEECertificationTypeDetailRequest, BEECertificationTypeDto>
{
    private readonly IBEECertificationTypeRepository mBEECertificationTypeRepository;
    private readonly IMapper mMapper;

    public GetBEECertificationTypeDetailRequestHandler(IBEECertificationTypeRepository provinceRepository, IMapper mapper)
    {
        mBEECertificationTypeRepository = provinceRepository;
        mMapper = mapper;
    }

    public async Task<BEECertificationTypeDto> Handle(GetBEECertificationTypeDetailRequest request, CancellationToken cancellationToken)
    {
        var tBEECertificationType = await mBEECertificationTypeRepository.GetByIdAsync(request.Id);
        return mMapper.Map<BEECertificationTypeDto>(tBEECertificationType);
    }
}
