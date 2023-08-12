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
        private readonly IEmailSender mEmailSender;
        private readonly IMapper mMapper;

        public CreateAddressCommandHandler(IAddressRepository addressRepository
            , IAddressTypeRepository addressTypeRepository
            , ICountryRepository countryRepository
            , IProvinceRepository provinceRepository
            , IEmailSender emailSender
            , IMapper mapper)
        {
            mAddressRepository = addressRepository;
            mAddressTypeRepository = addressTypeRepository;
            mCountryRepository = countryRepository;
            mProvinceRepository = provinceRepository;
            mEmailSender = emailSender;
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

            if(!tValidationResult.IsValid)
            {
                tResponse.Success = false;
                tResponse.Message = "Create address failed";
                tResponse.Errors = tValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var tAddress = mMapper.Map<Address>(request.AddressDto);
                tAddress = await mAddressRepository.InsertAsync(tAddress);

                tResponse.Success = true;
                tResponse.Message = "Address created successfully";
                tResponse.Id = tAddress.Id;
            }

            /**
             * Example usage of email service. This is not a good place to put this code. It is here for demonstration purposes only
            var tEmail = new Email
            {
                To = "yobenzima@gmail.com",
                Body = $"Address created successfully with id {tAddress.Id}",
                Subject = "Address created"
            };

            try
            {
                await mEmailSender.SendEmailAsync(tEmail);
            }
            catch(Exception ex)
            {
                // Properly log or handle error.
                // We cannot really 'throw' the exception here as
                // we do not want the main process to be interrupted
                // simply because an email was not sent.
                Console.WriteLine(ex.Message);
            }
            */

            return tResponse;
        }
    }
}
