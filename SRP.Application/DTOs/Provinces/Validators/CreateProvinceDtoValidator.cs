using FluentValidation;

using SRP.Application.Contracts.Persistence;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Provinces.Validators
{
    public class CreateProvinceDtoValidator : AbstractValidator<CreateProvinceDto>
    {
        private readonly ICountryRepository mCountryRepository;
        private readonly IProvinceRepository mProvinceRepository;

        public CreateProvinceDtoValidator(ICountryRepository countryRepository, IProvinceRepository provinceRepository)
        {
            mCountryRepository = countryRepository;
            mProvinceRepository = provinceRepository;

            Include(new IProvinceDtoValidator());

            RuleFor(p => p.CountryId)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("{PropertyName} is required.")
                .MustAsync(async (countryId, cancellationToken) =>
                {
                    var tExists = await mCountryRepository.ExistsAsync(countryId);
                    return !tExists;
                }).WithMessage("The selected {PropertyName} does not exist.");

            RuleFor(p => p.Name).CustomAsync(async (name, context, cancellationToken) =>
            {
                Guid tCountryId = context.RootContextData["CountryId"] as Guid? ?? Guid.Empty;
                var tExists = await mProvinceRepository.CheckProvinceExistsAsync(tCountryId, name);
                if (tExists)
                    context.AddFailure("The specified province already exists.");
            });       
        }    
    }
}
