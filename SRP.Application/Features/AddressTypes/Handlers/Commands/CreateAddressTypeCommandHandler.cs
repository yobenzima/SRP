using AutoMapper;

using FluentValidation;

using MediatR;

using SRP.Application.DTOs.AddressTypes.Validators;
using SRP.Application.Features.AddressTypes.Requests.Commands;
using SRP.Application.Contracts.Persistence;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRP.Application.Responses;

namespace SRP.Application.Features.AddressTypes.Handlers.Commands
{
    public class CreateAddressTypeCommandHandler : IRequestHandler<CreateAddressTypeCommand, BaseCommandResponse>
    {
        private readonly IAddressTypeRepository mAddressTypeRepository;
        private readonly IMapper mMapper;

        public CreateAddressTypeCommandHandler(IAddressTypeRepository addressTypeRepository, IMapper mapper)
        {
            mAddressTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAddressTypeCommand request, CancellationToken cancellationToken)
        {
            if(request.AddressTypeDto is null)
                throw new ArgumentNullException(nameof(request));

            var tResponse = new BaseCommandResponse();
            // Validate request
            var tValidator = new CreateAddressTypeValidator();
            var tValidationResult = await tValidator.ValidateAsync(request.AddressTypeDto, CancellationToken.None);
            if(!tValidationResult.IsValid)
            {
                tResponse.Success = false;
                tResponse.Message = "Create Address Type failed";
                tResponse.Errors = tValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var tAddressType = mMapper.Map<AddressType>(request.AddressTypeDto);
                tAddressType = await mAddressTypeRepository.InsertAsync(tAddressType);
  
                tResponse.Success = true;
                tResponse.Message = "Address Type created successfully";
                tResponse.Id = tAddressType.Id;
            }

            return tResponse;
        }
    }
}
