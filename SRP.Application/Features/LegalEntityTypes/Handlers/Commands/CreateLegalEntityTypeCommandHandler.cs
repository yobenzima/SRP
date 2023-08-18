using AutoMapper;

using FluentValidation;

using MediatR;

using SRP.Application.DTOs.LegalEntityTypes.Validators;
using SRP.Application.Features.LegalEntityTypes.Requests.Commands;
using SRP.Application.Contracts.Persistence;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRP.Application.Responses;

namespace SRP.Application.Features.LegalEntityTypes.Handlers.Commands
{
    public class CreateLegalEntityTypeCommandHandler : IRequestHandler<CreateLegalEntityTypeCommand, BaseCommandResponse>
    {
        private readonly ILegalEntityTypeRepository mLegalEntityTypeRepository;
        private readonly IMapper mMapper;

        public CreateLegalEntityTypeCommandHandler(ILegalEntityTypeRepository addressTypeRepository, IMapper mapper)
        {
            mLegalEntityTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLegalEntityTypeCommand request, CancellationToken cancellationToken)
        {
            if(request.LegalEntityTypeDto is null)
                throw new ArgumentNullException(nameof(request));

            var tResponse = new BaseCommandResponse();
            // Validate request
            var tValidator = new CreateLegalEntityTypeDtoValidator(mLegalEntityTypeRepository);
            var tValidationResult = await tValidator.ValidateAsync(request.LegalEntityTypeDto, CancellationToken.None);
            if(!tValidationResult.IsValid)
            {
                tResponse.Success = false;
                tResponse.Message = "Create Address Type failed";
                tResponse.Errors = tValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var tLegalEntityType = mMapper.Map<LegalEntityType>(request.LegalEntityTypeDto);
                tLegalEntityType = await mLegalEntityTypeRepository.InsertAsync(tLegalEntityType);
  
                tResponse.Success = true;
                tResponse.Message = "Address Type created successfully";
                tResponse.Id = tLegalEntityType.Id;
            }

            return tResponse;
        }
    }
}
