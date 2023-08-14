using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Addresses.Validators
{
    public class IAddressDtoValidator : AbstractValidator<IAddressDto>
    {
        private readonly IAddressTypeRepository mAddressTypeRepository;
        private readonly ICountryRepository mCountryRepository;
        private readonly IProvinceRepository mProvinceRepository;

        public IAddressDtoValidator(IAddressTypeRepository addressTypeRepository, ICountryRepository countryRepository, IProvinceRepository provinceRepository)
        {
            mAddressTypeRepository = addressTypeRepository;
            mCountryRepository = countryRepository;
            mProvinceRepository = provinceRepository;

            RuleFor(p => p.AddressTypeId)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull()
            .NotEqual(Guid.Empty) // Must not be empty Guid e.g. 00000000-0000-0000-0000-000000000000    
            .MustAsync(async (addressTypeId, cancellationToken) =>
            {
                bool tExists = await mAddressTypeRepository.ExistsAsync(addressTypeId);
                return !tExists;
            })
            .WithMessage("{PropertyName} is invalid.");

            RuleFor(p => p.SlotIndex)
                .NotNull()
                .GreaterThan(0)
                .LessThan(100)
                .WithMessage("{PropertyName} must be greater than 0 and not more than 100.");

            RuleFor(p => p.Floor)
                .MaximumLength(20)
                .WithMessage("{PropertyName} not be more than 20 characters.");

            RuleFor(p => p.Building)
                .MaximumLength(50)
                .WithMessage("{PropertyName} must not be more than 50 characters.");

            RuleFor(p => p.Street)
                .MaximumLength(150)
                .WithMessage("{PropertyName} must not be more than 150 characters.");

            RuleFor(p => p.City)
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not be more than 100 characters.");

            RuleFor(p => p.PostalCode)
                .MaximumLength(4)
                .MaximumLength(4)
                .WithMessage("{PropertyName} must not be less than or more than 4 characters.");

            RuleFor(p => p.ProvinceId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .NotEqual(Guid.Empty) // Must not be empty Guid e.g. 00000000-0000-0000-0000-000000000000
                .MustAsync(async (provinceId, cancellationToken) =>
                {
                    bool tExists = await mProvinceRepository.ExistsAsync(provinceId);
                    return !tExists;
                })
                .WithMessage("{PropertyName} is invalid.");

            RuleFor(p => p.CountryId)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .NotEqual(Guid.Empty) // Must not be empty Guid e.g. 00000000-0000-0000-0000-000000000000
                .MustAsync(async (countryId, cancellationToken) =>
                {
                    bool tExists = await mCountryRepository.ExistsAsync(countryId);
                    return !tExists;
                })
                .WithMessage("{PropertyName} is invalid.");
        }
    }
}
