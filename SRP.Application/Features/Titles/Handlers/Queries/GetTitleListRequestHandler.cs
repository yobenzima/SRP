using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Titles;
using SRP.Application.Features.Titles.Requests.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Titles.Handlers.Queries;

public class GetTitleListRequestHandler : IRequestHandler<GetTitleListRequest, List<TitleListDto>>
{
    private readonly ITitleRepository mTitleRepository;
    private readonly IMapper mMapper;

    public GetTitleListRequestHandler(ITitleRepository provinceRepository, IMapper mapper)
    {
        mTitleRepository = provinceRepository;
        mMapper = mapper;
    }

    public async Task<List<TitleListDto>> Handle(GetTitleListRequest request, CancellationToken cancellationToken)
    {
        var tTitles = await mTitleRepository.GetAllAsync();
        return mMapper.Map<List<TitleListDto>>(tTitles);
    }
}
