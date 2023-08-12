﻿using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Country;
using SRP.Application.Features.Country.Requests.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Country.Handlers.Queries;

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
