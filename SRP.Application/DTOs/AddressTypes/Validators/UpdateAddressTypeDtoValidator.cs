using FluentValidation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.AddressTypes.Validators;

public class UpdateAddressTypeDtoValidator : AbstractValidator<UpdateAddressTypeDto>
{
    public UpdateAddressTypeDtoValidator()
    {
        Include(new IAddressTypeDtoValidator());
    }
}
