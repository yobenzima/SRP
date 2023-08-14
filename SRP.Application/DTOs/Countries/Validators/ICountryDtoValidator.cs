using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Countries.Validators
{
    public class ICountryDtoValidator : AbstractValidator<ICountryDto>
    {
        private readonly ICountryRepository mCountryRepository;

        public ICountryDtoValidator(ICountryRepository countryRepository)
        {
            mCountryRepository = countryRepository;

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100)
                .WithMessage("{PropertyName} must not be more than 100 characters.");

            RuleFor(p => p.ISO)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0)
                .LessThan(999)
                .WithMessage("{PropertyName} must be greater than 0 and less than 999.")
                .MustAsync(async (isoNum, cancellationToken) =>
                {
                    bool tExists = await mCountryRepository.CheckISOExistsAsync(isoNum);
                    return !tExists;
                }).WithMessage("{PropertyName} must be unique per country.}");

            RuleFor(p => p.A3)
               .NotEmpty()
               .WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(3)
               .MinimumLength(3)
               .WithMessage("{PropertyName} must be 3 characters in length.")
               .MustAsync(async (a3, cancellationToken) =>
               {
                   bool tExists = await mCountryRepository.CheckA3CodeExistsAsync(a3);
                   return !tExists;
               }).WithMessage("{PropertyName} must be unique per country.}");

            RuleFor(p => p.A2)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
               .MaximumLength(2)
               .MinimumLength(2)
               .WithMessage("{PropertyName} must be 2 characters in length.")
                .MustAsync(async (a2, cancellationToken) =>
                {
                    bool tExists = await mCountryRepository.Check2CodeExistsAsync(a2);
                    return !tExists;
                }).WithMessage("{PropertyName} must be unique per country.}");

            RuleFor(p => p.DialingCode)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0)
                .LessThan(999)
                .WithMessage("{PropertyName} must be greater than 0 and less than 999.")
                .MustAsync(async (dialingCode, cancellationToken) =>
                {
                    bool tExists = await mCountryRepository.CheckDialingCodeExistsAsync(dialingCode);
                    return !tExists;
                }).WithMessage("{PropertyName} must be unique per country.}");
        }
    }
}
