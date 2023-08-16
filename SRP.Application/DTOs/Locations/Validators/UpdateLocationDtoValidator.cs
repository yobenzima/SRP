using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Locations.Validators;

public class UpdateLocationDtoValidator : AbstractValidator<UpdateLocationDto>
{
    private readonly IProvinceRepository mProvinceRepository;
    private readonly ILocationRepository mLocationRepository;

    public UpdateLocationDtoValidator(IProvinceRepository provinceRepository, ILocationRepository locationRepository)
    {
        mProvinceRepository = provinceRepository;
        mLocationRepository = locationRepository;

        Include(new ILocationDtoValidator(mProvinceRepository));

        RuleFor(c => c.Id)
            .NotNull()
            .NotEmpty() //
            .NotEqual(Guid.Empty) // Must not be empty Guid e.g. 00000000-0000-0000-0000-000000000000
            .WithMessage("{PropertyName} must be present!");

        RuleFor(c => c.Longitude)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} is required.")
            .InclusiveBetween(-180, 180).WithMessage("{PropertyName} must be between -180 and 180.");

        RuleFor(c => c.Latitude)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("{PropertyName} is required.")
            .InclusiveBetween(-90, 90).WithMessage("{PropertyName} must be between -90 and 90.");

        RuleFor(c => c.Name)
            .CustomAsync(async (name, context, cancellationToken) =>
            {
                Guid tProvinceId = context.RootContextData["ProvinceId"] as Guid? ?? Guid.Empty;
                decimal tLongitude = context.RootContextData["Longitude"] as decimal? ?? 0;
                decimal tLatitude = context.RootContextData["Latitude"] as decimal? ?? 0;
                var tExists = await mLocationRepository.CheckLocationExistsAsync(tProvinceId, name, tLongitude, tLatitude);
                if(tExists)
                    context.AddFailure("The specified location already exists.");
            });
    }
}
