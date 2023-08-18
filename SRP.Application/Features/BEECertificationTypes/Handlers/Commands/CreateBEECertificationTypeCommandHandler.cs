using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.BEECertificationTypes.Validators;
using SRP.Application.Features.BEECertificationTypes.Requests.Commands;
using SRP.Domain.Entities;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.BEECertificationTypes.Handlers.Commands;

public class CreateBEECertificationTypeCommandHandler : IRequestHandler<CreateBEECertificationTypeCommand, BaseCommandResponse>
{
    private readonly IBEECertificationTypeRepository mBEECertificationTypeRepository;
    private readonly IMapper mMapper;

    public CreateBEECertificationTypeCommandHandler(IBEECertificationTypeRepository beeCertificationTypeRepository, IMapper mapper)
    {
        mBEECertificationTypeRepository = beeCertificationTypeRepository;
        mMapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateBEECertificationTypeCommand request, CancellationToken cancellationToken)
    {
        if(request.BEECertificationTypeDto is null)
            throw new ArgumentNullException(nameof(request.BEECertificationTypeDto),  "Request cannot be null!");

        var tResponse = new BaseCommandResponse();
        var tValidator = new CreateBEECertificationTypeDtoValidator();
        var tValidationResult = await tValidator.ValidateAsync(request.BEECertificationTypeDto, CancellationToken.None);
        if(tValidationResult.IsValid == false)
        {
            tResponse.Success = false;
            tResponse.Message = "Create BEE Certification Type failed";
            tResponse.Errors = tValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var tBEECertificationType = mMapper.Map<BEECertificationType>(request.BEECertificationTypeDto);
            tBEECertificationType = await mBEECertificationTypeRepository.InsertAsync(tBEECertificationType);

            tResponse.Success = true;
            tResponse.Message = "BEE Certification Type created successfully";
            tResponse.Id = tBEECertificationType.Id;
        }
        return tResponse;
    }
}