using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.DocumentTypes.Validators;

public class UpdateDocumentTypeDtoValidator : AbstractValidator<UpdateDocumentTypeDto>
{
    private readonly IDocumentTypeRepository mDocumentTypeRepository;

    public UpdateDocumentTypeDtoValidator(IDocumentTypeRepository documentTypeRepository)
    {
        mDocumentTypeRepository = documentTypeRepository;

        Include(new IDocumentTypeDtoValidator(mDocumentTypeRepository));
    }
}
