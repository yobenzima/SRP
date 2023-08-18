using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Titles.Validators;
using SRP.Application.Features.Titles.Requests.Commands;
using SRP.Domain.Entities;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Titles.Handlers.Commands;

public class CreateTitleCommandHandler : IRequestHandler<CreateTitleCommand, BaseCommandResponse>
{
    private readonly ITitleRepository mTitleRepository;
    private readonly IMapper mMapper;

    public CreateTitleCommandHandler(ITitleRepository beeCertificationTypeRepository, IMapper mapper)
    {
        mTitleRepository = beeCertificationTypeRepository;
        mMapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateTitleCommand request, CancellationToken cancellationToken)
    {
        if(request.TitleDto is null)
            throw new ArgumentNullException(nameof(request.TitleDto),  "Request cannot be null!");

        var tResponse = new BaseCommandResponse();
        var tValidator = new CreateTitleDtoValidator();
        var tValidationResult = await tValidator.ValidateAsync(request.TitleDto, CancellationToken.None);
        if(tValidationResult.IsValid == false)
        {
            tResponse.Success = false;
            tResponse.Message = "Create BEE Certification Type failed";
            tResponse.Errors = tValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var tTitle = mMapper.Map<Title>(request.TitleDto);
            tTitle = await mTitleRepository.InsertAsync(tTitle);

            tResponse.Success = true;
            tResponse.Message = "BEE Certification Type created successfully";
            tResponse.Id = tTitle.Id;
        }
        return tResponse;
    }
}