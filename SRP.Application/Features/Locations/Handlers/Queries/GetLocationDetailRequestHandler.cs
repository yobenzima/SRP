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

public class GetLocationDetailRequestHandler : IRequestHandler<GetLocationDetailRequest, LocationDto>
{
    private readonly ICountryRepository mLocationRepository;
    private readonly IMapper mMapper;

    public GetLocationDetailRequestHandler(ICountryRepository locationRepository, IMapper mapper)
    {
        mLocationRepository = locationRepository;
        mMapper = mapper;
    }

    public async Task<LocationDto> Handle(GetLocationDetailRequest request, CancellationToken cancellationToken)
    {
        var tLocation = await mLocationRepository.GetByIdAsync(request.Id);
        return mMapper.Map<LocationDto>(tLocation);
    }
}
