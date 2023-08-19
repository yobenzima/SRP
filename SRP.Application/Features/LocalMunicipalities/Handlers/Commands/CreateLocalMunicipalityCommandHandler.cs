using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.LocalMunicipalities.Validators;
using SRP.Application.Features.LocalMunicipalities.Requests.Commands;
using SRP.Domain.Entities;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.LocalMunicipalities.Handlers.Commands;

public class CreateLocalMunicipalityCommandHandler : IRequestHandler<CreateLocalMunicipalityCommand, BaseCommandResponse>
{
    private readonly ILocalMunicipalityRepository mLocalMunicipalityRepository;
    private readonly IMapper mMapper;

    public CreateLocalMunicipalityCommandHandler(ILocalMunicipalityRepository localMunicipalityRepository, IMapper mapper)
    {
        mLocalMunicipalityRepository = localMunicipalityRepository;
        mMapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateLocalMunicipalityCommand request, CancellationToken cancellationToken)
    {
        if(request.LocalMunicipalityDto is null)
            throw new ArgumentNullException(nameof(request.LocalMunicipalityDto),  "Request cannot be null!");

        var tResponse = new BaseCommandResponse();
        var tValidator = new CreateLocalMunicipalityDtoValidator(mLocalMunicipalityRepository);
        var tValidationResult = await tValidator.ValidateAsync(request.LocalMunicipalityDto, CancellationToken.None);
        if(tValidationResult.IsValid == false)
        {
            tResponse.Success = false;
            tResponse.Message = "Create Local Municipality failed";
            tResponse.Errors = tValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
        else
        {
            var tLocalMunicipality = mMapper.Map<LocalMunicipality>(request.LocalMunicipalityDto);
            tLocalMunicipality = await mLocalMunicipalityRepository.InsertAsync(tLocalMunicipality);

            tResponse.Success = true;
            tResponse.Message = "Local Municipality created successfully";
            tResponse.Id = tLocalMunicipality.Id;
        }
        return tResponse;
    }
}