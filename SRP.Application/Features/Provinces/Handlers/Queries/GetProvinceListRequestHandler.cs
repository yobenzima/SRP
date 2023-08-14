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

public class GetProvinceListRequestHandler : IRequestHandler<GetProvinceListRequest, List<ProvinceListDto>>
{
    private readonly IProvinceRepository mProvinceRepository;
    private readonly IMapper mMapper;

    public GetProvinceListRequestHandler(IProvinceRepository provinceRepository, IMapper mapper)
    {
        mProvinceRepository = provinceRepository;
        mMapper = mapper;
    }

    public async Task<List<ProvinceListDto>> Handle(GetProvinceListRequest request, CancellationToken cancellationToken)
    {
        var tProvinces = await mProvinceRepository.GetAllAsync();
        return mMapper.Map<List<ProvinceListDto>>(tProvinces);
    }
}
