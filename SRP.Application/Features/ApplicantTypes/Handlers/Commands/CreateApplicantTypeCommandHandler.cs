using AutoMapper;

using FluentValidation;

using MediatR;

using SRP.Application.DTOs.ApplicantTypes.Validators;
using SRP.Application.Features.ApplicantTypes.Requests.Commands;
using SRP.Application.Contracts.Persistence;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRP.Application.Responses;

namespace SRP.Application.Features.ApplicantTypes.Handlers.Commands
{
    public class CreateApplicantTypeCommandHandler : IRequestHandler<CreateApplicantTypeCommand, BaseCommandResponse>
    {
        private readonly IApplicantTypeRepository mApplicantTypeRepository;
        private readonly IMapper mMapper;

        public CreateApplicantTypeCommandHandler(IApplicantTypeRepository addressTypeRepository, IMapper mapper)
        {
            mApplicantTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateApplicantTypeCommand request, CancellationToken cancellationToken)
        {
            if(request.ApplicantTypeDto is null)
                throw new ArgumentNullException(nameof(request));

            var tResponse = new BaseCommandResponse();
            // Validate request
            var tValidator = new CreateApplicantTypeDtoValidator();
            var tValidationResult = await tValidator.ValidateAsync(request.ApplicantTypeDto, CancellationToken.None);
            if(!tValidationResult.IsValid)
            {
                tResponse.Success = false;
                tResponse.Message = "Create Address Type failed";
                tResponse.Errors = tValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var tApplicantType = mMapper.Map<ApplicantType>(request.ApplicantTypeDto);
                tApplicantType = await mApplicantTypeRepository.InsertAsync(tApplicantType);
  
                tResponse.Success = true;
                tResponse.Message = "Address Type created successfully";
                tResponse.Id = tApplicantType.Id;
            }

            return tResponse;
        }
    }
}
