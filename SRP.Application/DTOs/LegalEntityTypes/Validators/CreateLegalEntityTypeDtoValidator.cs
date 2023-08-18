using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.LegalEntityTypes.Validators
{
    public class CreateLegalEntityTypeDtoValidator : AbstractValidator<CreateLegalEntityTypeDto>
    {
        private readonly ILegalEntityTypeRepository mLegalEntityTypeRepository;

        public CreateLegalEntityTypeDtoValidator(ILegalEntityTypeRepository documentTypeRepository)
        {
            mLegalEntityTypeRepository = documentTypeRepository;
            Include(new ILegalEntityTypeDtoValidator(mLegalEntityTypeRepository));
        }
    }
}
