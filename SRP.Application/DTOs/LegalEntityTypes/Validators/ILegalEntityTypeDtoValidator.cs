using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.LegalEntityTypes.Validators
{
    public class ILegalEntityTypeDtoValidator : AbstractValidator<ILegalEntityTypeDto>
    {
        private readonly ILegalEntityTypeRepository mLegalEntityTypeRepository;

        public ILegalEntityTypeDtoValidator(ILegalEntityTypeRepository documentTypeRepository)
        {  
            mLegalEntityTypeRepository = documentTypeRepository;

            RuleFor(p => p.Description)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50)
                .MinimumLength(4)
                .WithMessage("{PropertyName} must be not more than 50 characters.")
                .MustAsync(async (description, cancellationToken) =>
                    {
                        bool tExists = await mLegalEntityTypeRepository.CheckDescriptionExistsAsync(description);
                        return !tExists;
                    })
                .WithMessage("{PropertyName} must be unique.");
        }
    }
}
