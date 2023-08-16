using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Provinces.Validators;
using SRP.Application.Features.Provinces.Requests.Commands;
using SRP.Domain.Entities;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Provinces.Handlers.Commands;

public class CreateProvinceCommandHandler : IRequestHandler<CreateProvinceCommand, BaseCommandResponse>
{
    private readonly IProvinceRepository mProvinceRepository;
    private readonly ICountryRepository mCountryRepository;
    private readonly IMapper mMapper;

    public CreateProvinceCommandHandler(IProvinceRepository provinceRepository, ICountryRepository countryRepository, IMapper mapper)
    {
        mProvinceRepository = provinceRepository;
        mCountryRepository = countryRepository;
        mMapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateProvinceCommand request, CancellationToken cancellationToken)
    {
        if(request.ProvinceDto is null)
            throw new ArgumentException(nameof(request.ProvinceDto),  "Request cannot be null!");

        var tResponse = new BaseCommandResponse();
        var tValidator = new CreateProvinceDtoValidator(mCountryRepository, mProvinceRepository);
        var tValidationResult = await tValidator.ValidateAsync(request.ProvinceDto, CancellationToken.None);
        if(tValidationResult.IsValid == false)
        {
            tResponse.Success = false;
            tResponse.Message = "Create Province failed";
            tResponse.Errors = tValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var tProvince = mMapper.Map<Province>(request.ProvinceDto);
            tProvince = await mProvinceRepository.InsertAsync(tProvince);

            tResponse.Success = true;
            tResponse.Message = "Province created successfully";
            tResponse.Id = tProvince.Id;
        }
        return tResponse;
    }
}