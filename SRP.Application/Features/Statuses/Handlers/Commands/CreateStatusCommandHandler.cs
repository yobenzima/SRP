using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Statuses.Validators;
using SRP.Application.Features.Statuses.Requests.Commands;
using SRP.Domain.Entities;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Statuses.Handlers.Commands;

public class CreateStatusCommandHandler : IRequestHandler<CreateStatusCommand, BaseCommandResponse>
{
    private readonly IStatusRepository mStatusRepository;
    private readonly IMapper mMapper;

    public CreateStatusCommandHandler(IStatusRepository beeCertificationTypeRepository, IMapper mapper)
    {
        mStatusRepository = beeCertificationTypeRepository;
        mMapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
    {
        if(request.StatusDto is null)
            throw new ArgumentNullException(nameof(request.StatusDto),  "Request cannot be null!");

        var tResponse = new BaseCommandResponse();
        var tValidator = new CreateStatusDtoValidator(mStatusRepository);
        var tValidationResult = await tValidator.ValidateAsync(request.StatusDto, CancellationToken.None);
        if(tValidationResult.IsValid == false)
        {
            tResponse.Success = false;
            tResponse.Message = "Create BEE Certification Type failed";
            tResponse.Errors = tValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var tStatus = mMapper.Map<Status>(request.StatusDto);
            tStatus = await mStatusRepository.InsertAsync(tStatus);

            tResponse.Success = true;
            tResponse.Message = "BEE Certification Type created successfully";
            tResponse.Id = tStatus.Id;
        }
        return tResponse;
    }
}