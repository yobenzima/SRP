using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Statuses.Validators;
using SRP.Application.Exceptions;
using SRP.Application.Features.Statuses.Requests.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Statuses.Handlers.Commands;

public class UpdateStatusCommandHandler : IRequestHandler<UpdateStatusCommand, Unit>
{
    private readonly IStatusRepository mStatusRepository;
    private readonly IMapper mMapper;

    public UpdateStatusCommandHandler(IStatusRepository statusRepository, IMapper mapper)
    {
        mStatusRepository = statusRepository;
        mMapper = mapper;
    }

    public async Task<Unit> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
    {
        if(request.StatusDto is null)
            throw new ArgumentNullException(nameof(request), "Request is null!");

        // Validate the request
        var tValidator = new IStatusDtoValidator(mStatusRepository);
        var tValidationResult = await tValidator.ValidateAsync(request.StatusDto, CancellationToken.None);
        if(tValidationResult.IsValid == false)
            throw new ValidationException(tValidationResult);

        var tStatus = await mStatusRepository.GetByIdAsync(request.StatusDto.Id) ?? throw new EntityNotFoundException(request.StatusDto.Id);
        mMapper.Map(request.StatusDto, tStatus);
        await mStatusRepository.UpdateAsync(tStatus);
        return Unit.Value;
    }
}
