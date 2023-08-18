using AutoMapper;

using FluentValidation;

using MediatR;

using SRP.Application.DTOs.DocumentTypes.Validators;
using SRP.Application.Features.DocumentTypes.Requests.Commands;
using SRP.Application.Contracts.Persistence;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRP.Application.Responses;

namespace SRP.Application.Features.DocumentTypes.Handlers.Commands
{
    public class CreateDocumentTypeCommandHandler : IRequestHandler<CreateDocumentTypeCommand, BaseCommandResponse>
    {
        private readonly IDocumentTypeRepository mDocumentTypeRepository;
        private readonly IMapper mMapper;

        public CreateDocumentTypeCommandHandler(IDocumentTypeRepository addressTypeRepository, IMapper mapper)
        {
            mDocumentTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            if(request.DocumentTypeDto is null)
                throw new ArgumentNullException(nameof(request));

            var tResponse = new BaseCommandResponse();
            // Validate request
            var tValidator = new CreateDocumentTypeDtoValidator(mDocumentTypeRepository);
            var tValidationResult = await tValidator.ValidateAsync(request.DocumentTypeDto, CancellationToken.None);
            if(!tValidationResult.IsValid)
            {
                tResponse.Success = false;
                tResponse.Message = "Create Address Type failed";
                tResponse.Errors = tValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var tDocumentType = mMapper.Map<DocumentType>(request.DocumentTypeDto);
                tDocumentType = await mDocumentTypeRepository.InsertAsync(tDocumentType);
  
                tResponse.Success = true;
                tResponse.Message = "Address Type created successfully";
                tResponse.Id = tDocumentType.Id;
            }

            return tResponse;
        }
    }
}
