using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.BEECertificationTypes.Validators
{
    public class IBEECertificationTypeDtoValidator : AbstractValidator<IBEECertificationTypeDto>
    {
        public IBEECertificationTypeDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50)
                .MinimumLength(4)
                .WithMessage("{PropertyName} must be a minimum of 4 characters and not more than 100 characters.");
        }
    }
}
