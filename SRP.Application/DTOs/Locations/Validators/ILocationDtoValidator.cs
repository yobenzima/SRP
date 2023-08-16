using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Locations.Validators;

public class ILocationDtoValidator : AbstractValidator<ILocationDto>
{
    private readonly IProvinceRepository mProvinceRepository;

    public ILocationDtoValidator(IProvinceRepository provinceRepository)
    {
        mProvinceRepository = provinceRepository;

        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName} is required.")
            .MaximumLength(100)
            .WithMessage("{PropertyName} must not exceed 100 characters.");

        RuleFor(p => p.ProvinceId)
            .NotEqual(Guid.Empty) // Must not be empty Guid e.g. 00000000-0000-0000-0000-000000000000
            .When(p => p.ProvinceId.HasValue) // Must be a valid Guid if provided
            .MustAsync(async (provinceId, cancellationToken) =>
            {
                // Selected Province must exist in the database
                bool tExists = await mProvinceRepository.CheckProvinceExistsAsync(provinceId);
                return !tExists;
            })
            .WithMessage("{PropertyName} is invalid.");
    }
}
