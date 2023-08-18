using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.ApplicantTypes.Validators;

public class UpdateApplicantTypeDtoValidator : AbstractValidator<UpdateApplicantTypeDto>
{
    public UpdateApplicantTypeDtoValidator()
    {
        Include(new IApplicantTypeDtoValidator());
    }
}
