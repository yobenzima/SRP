﻿using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.AddressType.Validators
{
    public class CreateAddressTypeValidator : AbstractValidator<CreateAddressTypeDto>
    {
        public CreateAddressTypeValidator()
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
