using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.LegalEntityTypes.Validators;

public class UpdateLegalEntityTypeDtoValidator : AbstractValidator<UpdateLegalEntityTypeDto>
{
    private readonly ILegalEntityTypeRepository mLegalEntityTypeRepository;

    public UpdateLegalEntityTypeDtoValidator(ILegalEntityTypeRepository documentTypeRepository)
    {
        mLegalEntityTypeRepository = documentTypeRepository;

        Include(new ILegalEntityTypeDtoValidator(mLegalEntityTypeRepository));
    }
}
