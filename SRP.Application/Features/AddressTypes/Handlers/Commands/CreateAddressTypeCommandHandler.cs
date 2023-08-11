using AutoMapper;

using FluentValidation;

using MediatR;

using SRP.Application.DTOs.AddressType.Validators;
using SRP.Application.Features.AddressTypes.Requests.Commands;
using SRP.Application.Contracts.Persistence;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.AddressTypes.Handlers.Commands
{
    public class CreateAddressTypeCommandHandler : IRequestHandler<CreateAddressTypeCommand, Guid>
    {
        private readonly IAddressTypeRepository mAddressTypeRepository;
        private readonly IMapper mMapper;

        public CreateAddressTypeCommandHandler(IAddressTypeRepository addressTypeRepository, IMapper mapper)
        {
            mAddressTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<Guid> Handle(CreateAddressTypeCommand request, CancellationToken cancellationToken)
        {
            if(request.AddressTypeDto is null)
                throw new ArgumentNullException(nameof(request));

            // Validate request
            var tValidator = new CreateAddressTypeValidator();
            var tValidationResult = await tValidator.ValidateAsync(request.AddressTypeDto, CancellationToken.None);
            if (!tValidationResult.IsValid)
                throw new ValidationException(tValidationResult.Errors);

            var tAddressType = mMapper.Map<AddressType>(request.AddressTypeDto);
            tAddressType = await mAddressTypeRepository.InsertAsync(tAddressType);
            return tAddressType.Id;
        }
    }
}
