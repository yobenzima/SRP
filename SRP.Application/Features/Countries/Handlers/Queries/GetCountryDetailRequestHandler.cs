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

public class GetCountryDetailRequestHandler : IRequestHandler<GetCountryDetailRequest, CountryDto>
{
    private readonly ICountryRepository mCountryRepository;
    private readonly IMapper mMapper;

    public GetCountryDetailRequestHandler(ICountryRepository countryRepository, IMapper mapper)
    {
        mCountryRepository = countryRepository;
        mMapper = mapper;
    }

    public async Task<CountryDto> Handle(GetCountryDetailRequest request, CancellationToken cancellationToken)
    {
        var tCountry = await mCountryRepository.GetByIdAsync(request.Id);
        return mMapper.Map<CountryDto>(tCountry);
    }
}
