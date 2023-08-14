
using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Countries.Validators
{
    public class CreateCountryDtoValidator : AbstractValidator<CreateCountryDto>
    {
        private readonly ICountryRepository? mCountryRepository;

        public CreateCountryDtoValidator(ICountryRepository countryRepository)
        {
            mCountryRepository = countryRepository;

            Include(new ICountryDtoValidator(mCountryRepository));
        }
    }
}
