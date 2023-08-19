using FluentValidation;

using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.LocalMunicipalities.Validators;

public class UpdateLocalMunicipalityDtoValidator : AbstractValidator<UpdateLocalMunicipalityDto>
{
    private readonly ILocalMunicipalityRepository mLocalMunicipalityRepository;

    public UpdateLocalMunicipalityDtoValidator(ILocalMunicipalityRepository localMunicipalityRepository)
    {
        mLocalMunicipalityRepository = localMunicipalityRepository;
        Include(new ILocalMunicipalityDtoValidator(mLocalMunicipalityRepository));
    }
}
