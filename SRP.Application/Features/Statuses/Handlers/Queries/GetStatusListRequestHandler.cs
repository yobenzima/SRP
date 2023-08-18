using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Statuses;
using SRP.Application.Features.Statuses.Requests.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Statuses.Handlers.Queries;

public class GetStatusListRequestHandler : IRequestHandler<GetStatusListRequest, List<StatusListDto>>
{
    private readonly IStatusRepository mStatusRepository;
    private readonly IMapper mMapper;

    public GetStatusListRequestHandler(IStatusRepository provinceRepository, IMapper mapper)
    {
        mStatusRepository = provinceRepository;
        mMapper = mapper;
    }

    public async Task<List<StatusListDto>> Handle(GetStatusListRequest request, CancellationToken cancellationToken)
    {
        var tStatuses = await mStatusRepository.GetAllAsync();
        return mMapper.Map<List<StatusListDto>>(tStatuses);
    }
}
