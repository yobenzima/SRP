using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.LocalMunicipalities;
using SRP.Application.Features.LocalMunicipalities.Requests.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.LocalMunicipalities.Handlers.Queries;

public class GetLocalMunicipalityListRequestHandler : IRequestHandler<GetLocalMunicipalityListRequest, List<LocalMunicipalityListDto>>
{
    private readonly ILocalMunicipalityRepository mLocalMunicipalityRepository;
    private readonly IMapper mMapper;

    public GetLocalMunicipalityListRequestHandler(ILocalMunicipalityRepository provinceRepository, IMapper mapper)
    {
        mLocalMunicipalityRepository = provinceRepository;
        mMapper = mapper;
    }

    public async Task<List<LocalMunicipalityListDto>> Handle(GetLocalMunicipalityListRequest request, CancellationToken cancellationToken)
    {
        var tLocalMunicipalities = await mLocalMunicipalityRepository.GetAllAsync();
        return mMapper.Map<List<LocalMunicipalityListDto>>(tLocalMunicipalities);
    }
}
