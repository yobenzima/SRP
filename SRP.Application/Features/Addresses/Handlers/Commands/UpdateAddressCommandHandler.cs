using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Address.Validators;
using SRP.Application.Exceptions;
using SRP.Application.Features.Addresses.Requests.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Addresses.Handlers.Commands
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, Unit>
    {
        private readonly IAddressRepository mAddressRepository;
        private readonly IAddressTypeRepository mAddressTypeRepository;
        private readonly ICountryRepository mCountryRepository;
        private readonly IProvinceRepository mProvinceRepository;
        private readonly IMapper mMapper;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository, IAddressTypeRepository addressTypeRepository, ICountryRepository countryRepository, IProvinceRepository provinceRepository, IMapper mapper)
        {
            mAddressRepository = addressRepository;
            mAddressTypeRepository = addressTypeRepository;
            mCountryRepository = countryRepository;
            mProvinceRepository = provinceRepository;
            mMapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            // Check that the request is valid
            if(request.AddressDto is null)
                throw new ArgumentNullException($"{nameof(UpdateAddressCommand)} is null!"); //TODO: Add proper error handling

            // Validate the request
            var tAddressValidator = new UpdateAddressDtoValidator(mAddressTypeRepository, mCountryRepository, mProvinceRepository);
            var tValidationResult = await tAddressValidator.ValidateAsync(request.AddressDto, CancellationToken.None);

            if (!tValidationResult.IsValid)
                throw new ValidationException(tValidationResult);   

            // Fetch existing address using Id of passed in request
            var tAddress = await mAddressRepository.GetByIdAsync(request.AddressDto.Id) ?? throw new EntityNotFoundException(request.AddressDto.Id);

            // Map - update the existing address with the new values that may have been changed
            mMapper.Map(request.AddressDto, tAddress);

            // Update
            await mAddressRepository.UpdateAsync(tAddress);

            return Unit.Value;
        }
    }
}
