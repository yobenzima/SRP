using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Provinces.Validators
{
    public class UpdateProvinceDtoValidator : AbstractValidator<UpdateProvinceDto>
    {
        public UpdateProvinceDtoValidator()
        {
            Include(new IProvinceDtoValidator());

            RuleFor(p => p.Id)
                .NotNull()
                .NotEmpty() //
                .NotEqual(Guid.Empty) // Must not be empty Guid e.g. 00000000-0000-0000-0000-000000000000
                .WithMessage("{PropertyName} must be present!");
        }
    }
}
