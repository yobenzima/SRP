using AutoMapper;
using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Countries;
using SRP.Application.Features.Countries.Requests.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Countries.Handlers.Queries;

public class GetCountryListRequestHandler : IRequestHandler<GetCountryListRequest, List<CountryListDto>>
{
    private readonly ICountryRepository mCountryRepository;
    private readonly IMapper mMapper;

    public GetCountryListRequestHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        mCountryRepository = countryRepository;
        mMapper = mapper;
    }

    public async Task<List<CountryListDto>> Handle(GetCountryListRequest request, CancellationToken cancellationToken)
    {
        var tCountries = await mCountryRepository.GetAllAsync();
        return mMapper.Map<List<CountryListDto>>(tCountries);
    }
}
