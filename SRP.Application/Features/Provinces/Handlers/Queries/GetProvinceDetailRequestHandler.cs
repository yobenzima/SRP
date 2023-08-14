using AutoMapper;
using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Provinces;
using SRP.Application.Features.Provinces.Requests.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Provinces.Handlers.Queries;

public class GetProvinceDetailRequestHandler : IRequestHandler<GetProvinceDetailRequest, ProvinceDto>
{
    private readonly IProvinceRepository mProvinceRepository;
    private readonly IMapper mMapper;

    public GetProvinceDetailRequestHandler(IProvinceRepository provinceRepository, IMapper mapper)
    {
        mProvinceRepository = provinceRepository;
        mMapper = mapper;
    }

    public async Task<ProvinceDto> Handle(GetProvinceDetailRequest request, CancellationToken cancellationToken)
    {
        var tProvince = await mProvinceRepository.GetByIdAsync(request.Id);
        return mMapper.Map<ProvinceDto>(tProvince);
    }
}
