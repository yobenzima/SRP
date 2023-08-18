using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Titles.Validators
{
    public class ITitleDtoValidator : AbstractValidator<ITitleDto>
    {
        private readonly ITitleRepository mTitleRepository;

        public ITitleDtoValidator(ITitleRepository titleRepository)
        {
            mTitleRepository = titleRepository;

            RuleFor(p => p.Code)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(6)
            .MinimumLength(2)
            .WithMessage("{PropertyName} must be a minimum of 2 characters and not more than 6 characters.")
            .MustAsync(async (code, cancellationToken) =>
            {
                bool tExists = await mTitleRepository.IsCodeUnique(code);
                return !tExists;
            })
            .WithMessage("{PropertyName} must be unique.");

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(15)
                .WithMessage("{PropertyName} must be not more than 15 characters.")
                .MustAsync(async (description, cancellationToken) =>
                {
                    bool tExists = await mTitleRepository.CheckDescriptionExistsAsync(description);
                    return !tExists;
                })
                .WithMessage("{PropertyName} must be unique.");
        }
    }
}
