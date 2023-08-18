using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.BEECertificationTypes.Validators;
using SRP.Application.Exceptions;
using SRP.Application.Features.BEECertificationTypes.Requests.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.BEECertificationTypes.Handlers.Commands;

public class UpdateBEECertificationTypeCommandHandler : IRequestHandler<UpdateBEECertificationTypeCommand, Unit>
{
    private readonly IBEECertificationTypeRepository mBEECertificationTypeRepository;
    private readonly IMapper mMapper;

    public UpdateBEECertificationTypeCommandHandler(IBEECertificationTypeRepository provinceRepository, IMapper mapper)
    {
        mBEECertificationTypeRepository = provinceRepository;
        mMapper = mapper;
    }

    public async Task<Unit> Handle(UpdateBEECertificationTypeCommand request, CancellationToken cancellationToken)
    {
        if(request.BEECertificationTypeDto is null)
            throw new ArgumentNullException(nameof(request), "Request is null!");

        // Validate the request
        var tValidator = new IBEECertificationTypeDtoValidator();
        var tValidationResult = await tValidator.ValidateAsync(request.BEECertificationTypeDto, CancellationToken.None);
        if(tValidationResult.IsValid == false)
            throw new ValidationException(tValidationResult);

        var tBEECertificationType = await mBEECertificationTypeRepository.GetByIdAsync(request.BEECertificationTypeDto.Id) ?? throw new EntityNotFoundException(request.BEECertificationTypeDto.Id);
        mMapper.Map(request.BEECertificationTypeDto, tBEECertificationType);
        await mBEECertificationTypeRepository.UpdateAsync(tBEECertificationType);
        return Unit.Value;
    }
}
