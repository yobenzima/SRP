using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Infrastructure;
using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Address.Validators;
using SRP.Application.Exceptions;
using SRP.Application.Features.Addresses.Requests.Commands;
using SRP.Application.Models;
using SRP.Application.Responses;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Addresses.Handlers.Commands
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, BaseCommandResponse>
    {
        private readonly IAddressRepository mAddressRepository;
        private readonly IAddressTypeRepository mAddressTypeRepository;
        private readonly ICountryRepository mCountryRepository;
        private readonly IProvinceRepository mProvinceRepository;
        private readonly IMapper mMapper;

        public CreateAddressCommandHandler(IAddressRepository addressRepository
            , IAddressTypeRepository addressTypeRepository
            , ICountryRepository countryRepository
            , IProvinceRepository provinceRepository
            , IMapper mapper)
        {
            mAddressRepository = addressRepository;
            mAddressTypeRepository = addressTypeRepository;
            mCountryRepository = countryRepository;
            mProvinceRepository = provinceRepository;
            mMapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            if(request.AddressDto is null)
                throw new ArgumentNullException(nameof(request));

            var tResponse = new BaseCommandResponse();
            // Validate request
            var tValidator = new CreateAddressDtoValidator(mAddressTypeRepository, mCountryRepository, mProvinceRepository);
            var tValidationResult = await tValidator.ValidateAsync(request.AddressDto, CancellationToken.None);
            
            if (tValidationResult.IsValid == false)
            {
                tResponse.Success = false;
                tResponse.Message = "Create address failed";
                tResponse.Errors = tValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var tAddress = mMapper.Map<Address>(request.AddressDto);
                tAddress = await mAddressRepository.AddAsync(tAddress);

                tResponse.Success = true;
                tResponse.Message = "Address created successfully";
                tResponse.Id = tAddress.Id;
            }

            return tResponse;
        }
    }
}
