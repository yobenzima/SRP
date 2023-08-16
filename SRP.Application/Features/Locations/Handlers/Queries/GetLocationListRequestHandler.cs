using AutoMapper;
using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Locations;
using SRP.Application.Features.Locations.Requests.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Locations.Handlers.Queries;

public class GetLocationListRequestHandler : IRequestHandler<GetLocationListRequest, List<LocationListDto>>
{
    private readonly ILocationRepository mLocationRepository;
    private readonly IMapper mMapper;

    public GetLocationListRequestHandler(ILocationRepository locationRepository, IMapper mapper)
    {
        mLocationRepository = locationRepository;
        mMapper = mapper;
    }

    public async Task<List<LocationListDto>> Handle(GetLocationListRequest request, CancellationToken cancellationToken)
    {
        var tLocations =  await mLocationRepository.GetLocationsByProvinceAsync(request.ProvinceId);
        return mMapper.Map<List<LocationListDto>>(tLocations);
    }
}
