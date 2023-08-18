using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Statuses.Validators
{
    public class IStatusDtoValidator : AbstractValidator<IStatusDto>
    {
        private readonly IStatusRepository mStatusRepository;

        public IStatusDtoValidator(IStatusRepository statusRepository)
        {
            mStatusRepository = statusRepository;

            RuleFor(p => p.Code)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(10)
            .MinimumLength(4)
            .WithMessage("{PropertyName} must be a minimum of 4 characters and not more than 50 characters.")
            .MustAsync(async (code, cancellationToken) =>
            {
                bool tExists = await mStatusRepository.IsCodeUnique(code);
                return !tExists;
            })
            .WithMessage("{PropertyName} must be unique.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(32)
                .WithMessage("{PropertyName} must be not more than 32 characters.")
                .MustAsync(async (description, cancellationToken) =>
                {
                    bool tExists = await mStatusRepository.CheckDescriptionExistsAsync(description);
                    return !tExists;
                })
                .WithMessage("{PropertyName} must be unique.");
        }

    }
}
