using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.BEECertificationTypes.Validators;

public class UpdateBEECertificationTypeDtoValidator : AbstractValidator<UpdateBEECertificationTypeDto>
{
    public UpdateBEECertificationTypeDtoValidator()
    {
        Include(new IBEECertificationTypeDtoValidator());
    }
}
