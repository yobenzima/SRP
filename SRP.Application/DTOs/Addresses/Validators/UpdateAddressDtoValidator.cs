using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Addresses.Validators
{
    public class UpdateAddressDtoValidator : AbstractValidator<UpdateAddressDto>
    {
        private readonly IAddressTypeRepository? mAddressTypeRepository;
        private readonly ICountryRepository? mCountryRepository;
        private readonly IProvinceRepository? mProvinceRepository;

        public UpdateAddressDtoValidator(IAddressTypeRepository addressTypeRepository, ICountryRepository countryRepository, IProvinceRepository provinceRepository)
        {
            mAddressTypeRepository = addressTypeRepository;
            mCountryRepository = countryRepository;
            mProvinceRepository = provinceRepository;

            Include(new IAddressDtoValidator(mAddressTypeRepository, mCountryRepository, mProvinceRepository));

            RuleFor(a => a.Id)
                .NotNull()
                .NotEmpty() //
                .NotEqual(Guid.Empty) // Must not be empty Guid e.g. 00000000-0000-0000-0000-000000000000
                .WithMessage("{PropertyName} must be present!");
        }
    }
}
