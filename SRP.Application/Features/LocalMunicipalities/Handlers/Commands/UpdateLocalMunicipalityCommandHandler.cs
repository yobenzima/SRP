using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.LocalMunicipalities.Validators;
using SRP.Application.Exceptions;
using SRP.Application.Features.LocalMunicipalities.Requests.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.LocalMunicipalities.Handlers.Commands;

public class UpdateLocalMunicipalityCommandHandler : IRequestHandler<UpdateLocalMunicipalityCommand, Unit>
{
    private readonly ILocalMunicipalityRepository mLocalMunicipalityRepository;
    private readonly IMapper mMapper;

    public UpdateLocalMunicipalityCommandHandler(ILocalMunicipalityRepository localMunicipalityRepository, IMapper mapper)
    {
        mLocalMunicipalityRepository = localMunicipalityRepository;
        mMapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLocalMunicipalityCommand request, CancellationToken cancellationToken)
    {
        if(request.LocalMunicipalityDto is null)
            throw new ArgumentNullException(nameof(request), "Request is null!");

        // Validate the request
        var tValidator = new ILocalMunicipalityDtoValidator(mLocalMunicipalityRepository);
        var tValidationResult = await tValidator.ValidateAsync(request.LocalMunicipalityDto, CancellationToken.None);
        if(tValidationResult.IsValid == false)
            throw new ValidationException(tValidationResult);

        var tLocalMunicipality = await mLocalMunicipalityRepository.GetByIdAsync(request.LocalMunicipalityDto.Id) ?? throw new EntityNotFoundException(request.LocalMunicipalityDto.Id);
        mMapper.Map(request.LocalMunicipalityDto, tLocalMunicipality);
        await mLocalMunicipalityRepository.UpdateAsync(tLocalMunicipality);
        return Unit.Value;
    }
}
