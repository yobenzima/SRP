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

public class GetBEECertificationTypeListRequestHandler : IRequestHandler<GetBEECertificationTypeListRequest, List<BEECertificationTypeListDto>>
{
    private readonly IBEECertificationTypeRepository mBEECertificationTypeRepository;
    private readonly IMapper mMapper;

    public GetBEECertificationTypeListRequestHandler(IBEECertificationTypeRepository provinceRepository, IMapper mapper)
    {
        mBEECertificationTypeRepository = provinceRepository;
        mMapper = mapper;
    }

    public async Task<List<BEECertificationTypeListDto>> Handle(GetBEECertificationTypeListRequest request, CancellationToken cancellationToken)
    {
        var tBEECertificationTypes = await mBEECertificationTypeRepository.GetAllAsync();
        return mMapper.Map<List<BEECertificationTypeListDto>>(tBEECertificationTypes);
    }
}
