using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Provinces.Validators;
using SRP.Application.Exceptions;
using SRP.Application.Features.Provinces.Requests.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Provinces.Handlers.Commands;

public class UpdateProvinceCommandHandler : IRequestHandler<UpdateProvinceCommand, Unit>
{
    private readonly IProvinceRepository mProvinceRepository;
    private readonly IMapper mMapper;

    public UpdateProvinceCommandHandler(IProvinceRepository provinceRepository, IMapper mapper)
    {
        mProvinceRepository = provinceRepository;
        mMapper = mapper;
    }

    public async Task<Unit> Handle(UpdateProvinceCommand request, CancellationToken cancellationToken)
    {
        if(request.ProvinceDto is null)
            throw new ArgumentNullException(nameof(request), "Request is null!");

        // Validate the request
        var tValidator = new IProvinceDtoValidator();
        var tValidationResult = await tValidator.ValidateAsync(request.ProvinceDto, CancellationToken.None);
        if(tValidationResult.IsValid == false)
            throw new ValidationException(tValidationResult);

        var tProvince = await mProvinceRepository.GetByIdAsync(request.ProvinceDto.Id) ?? throw new EntityNotFoundException(request.ProvinceDto.Id);
        mMapper.Map(request.ProvinceDto, tProvince);
        await mProvinceRepository.UpdateAsync(tProvince);
        return Unit.Value;
    }
}
