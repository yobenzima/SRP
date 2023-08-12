using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Country.Validators
{
    public class UpdateCountryDtoValidator : AbstractValidator<UpdateCountryDto>
    {
        private readonly ICountryRepository mCountryRepository;

        public UpdateCountryDtoValidator(ICountryRepository countryRepository)
        {
            mCountryRepository = countryRepository;

            Include(new ICountryDtoValidator(mCountryRepository));

            RuleFor(c => c.Id)
                .NotNull()
                .NotEmpty() //
                .NotEqual(Guid.Empty) // Must not be empty Guid e.g. 00000000-0000-0000-0000-000000000000
                .WithMessage("{PropertyName} must be present!");
        }
    }
}
