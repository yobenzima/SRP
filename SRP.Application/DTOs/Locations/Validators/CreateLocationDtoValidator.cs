using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Locations.Validators;

public class CreateLocationDtoValidator : AbstractValidator<CreateLocationDto>
{
    private readonly IProvinceRepository mProvinceRepository;

    public CreateLocationDtoValidator(IProvinceRepository provinceRepository)
    {
        mProvinceRepository = provinceRepository;

        Include(new ILocationDtoValidator(mProvinceRepository));

        RuleFor(l => l.Longitude)
            .InclusiveBetween(-180, 180)
            .WithMessage("{PropertyName} must be between -180 and 180.")
            .NotNull()
            .WithMessage("{PropertyName} is required.");

        RuleFor(l => l.Latitude)
            .InclusiveBetween(-90, 90)
            .WithMessage("{PropertyName} must be between -90 and 90.")
            .NotNull()
            .WithMessage("{PropertyName} is required.");  
    }
}
