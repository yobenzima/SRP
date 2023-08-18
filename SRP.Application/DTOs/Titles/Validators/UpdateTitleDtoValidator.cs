using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Titles.Validators;

public class UpdateTitleDtoValidator : AbstractValidator<UpdateTitleDto>
{
    private readonly ITitleRepository mTitleRepository;

    public UpdateTitleDtoValidator(ITitleRepository titleRepository)
    {
        mTitleRepository = titleRepository;
        Include(new ITitleDtoValidator(mTitleRepository));
    }
}
