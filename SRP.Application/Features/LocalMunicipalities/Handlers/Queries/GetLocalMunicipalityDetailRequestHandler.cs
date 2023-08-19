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

public class GetLocalMunicipalityDetailRequestHandler : IRequestHandler<GetLocalMunicipalityDetailRequest, LocalMunicipalityDto>
{
    private readonly ILocalMunicipalityRepository mLocalMunicipalityRepository;
    private readonly IMapper mMapper;

    public GetLocalMunicipalityDetailRequestHandler(ILocalMunicipalityRepository provinceRepository, IMapper mapper)
    {
        mLocalMunicipalityRepository = provinceRepository;
        mMapper = mapper;
    }

    public async Task<LocalMunicipalityDto> Handle(GetLocalMunicipalityDetailRequest request, CancellationToken cancellationToken)
    {
        var tLocalMunicipality = await mLocalMunicipalityRepository.GetByIdAsync(request.Id);
        return mMapper.Map<LocalMunicipalityDto>(tLocalMunicipality);
    }
}
