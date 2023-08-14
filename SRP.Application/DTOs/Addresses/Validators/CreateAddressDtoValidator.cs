using FluentValidation;
using FluentValidation.Validators;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Addresses.Validators
{
    public class CreateAddressDtoValidator : AbstractValidator<CreateAddressDto>
    {
        private readonly IAddressTypeRepository? mAddressTypeRepository;
        private readonly ICountryRepository? mCountryRepository;
        private readonly IProvinceRepository? mProvinceRepository;

        public CreateAddressDtoValidator(IAddressTypeRepository addressTypeRepository, ICountryRepository countryRepository, IProvinceRepository provinceRepository)
        {
            mAddressTypeRepository = addressTypeRepository;
            mCountryRepository = countryRepository;
            mProvinceRepository = provinceRepository;

            Include(new IAddressDtoValidator(mAddressTypeRepository, mCountryRepository, mProvinceRepository));
        }
    }
}
