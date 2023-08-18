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

public class GetTitleDetailRequestHandler : IRequestHandler<GetTitleDetailRequest, TitleDto>
{
    private readonly ITitleRepository mTitleRepository;
    private readonly IMapper mMapper;

    public GetTitleDetailRequestHandler(ITitleRepository provinceRepository, IMapper mapper)
    {
        mTitleRepository = provinceRepository;
        mMapper = mapper;
    }

    public async Task<TitleDto> Handle(GetTitleDetailRequest request, CancellationToken cancellationToken)
    {
        var tTitle = await mTitleRepository.GetByIdAsync(request.Id);
        return mMapper.Map<TitleDto>(tTitle);
    }
}
