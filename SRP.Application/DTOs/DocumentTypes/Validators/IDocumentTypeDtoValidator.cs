using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.DocumentTypes.Validators
{
    public class IDocumentTypeDtoValidator : AbstractValidator<IDocumentTypeDto>
    {
        private readonly IDocumentTypeRepository mDocumentTypeRepository;

        public IDocumentTypeDtoValidator(IDocumentTypeRepository documentTypeRepository)
        {  
            mDocumentTypeRepository = documentTypeRepository;

            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50)
                .MinimumLength(4)
                .WithMessage("{PropertyName} must be a minimum of 4 characters and not more than 100 characters.")
                .MustAsync(async (name, cancellationToken) =>
                {
                    bool tExists = await mDocumentTypeRepository.CheckNameExistsAsync(name);
                    return !tExists;
                })
                .WithMessage("{PropertyName} must be unique.");


            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("{PropertyName} must be not more than 255 characters.");
        }
    }
}
