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

public class GetStatusDetailRequestHandler : IRequestHandler<GetStatusDetailRequest, StatusDto>
{
    private readonly IStatusRepository mStatusRepository;
    private readonly IMapper mMapper;

    public GetStatusDetailRequestHandler(IStatusRepository provinceRepository, IMapper mapper)
    {
        mStatusRepository = provinceRepository;
        mMapper = mapper;
    }

    public async Task<StatusDto> Handle(GetStatusDetailRequest request, CancellationToken cancellationToken)
    {
        var tStatus = await mStatusRepository.GetByIdAsync(request.Id);
        return mMapper.Map<StatusDto>(tStatus);
    }
}
