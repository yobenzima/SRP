using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.LocalMunicipalities.Validators
{
    public class ILocalMunicipalityDtoValidator : AbstractValidator<ILocalMunicipalityDto>
    {
        private readonly ILocalMunicipalityRepository mLocalMunicipalityRepository;

        public ILocalMunicipalityDtoValidator(ILocalMunicipalityRepository localMunicipalityRepository)
        {
            mLocalMunicipalityRepository = localMunicipalityRepository;

            RuleFor(p => p.Code)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(6)
            .MinimumLength(2)
            .WithMessage("{PropertyName} must be a minimum of 3 characters and not more than 5 characters.")
            .MustAsync(async (code, cancellationToken) =>
            {
                bool tExists = await mLocalMunicipalityRepository.IsCodeUnique(code);
                return !tExists;
            })
            .WithMessage("{PropertyName} must be unique.");

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(110)
                .WithMessage("{PropertyName} must be not more than 100 characters.")
                .MustAsync(async (description, cancellationToken) =>
                {
                    bool tExists = await mLocalMunicipalityRepository.CheckNameExistsAsync(description);
                    return !tExists;
                })
                .WithMessage("{PropertyName} must be unique.");
        }
    }
}
