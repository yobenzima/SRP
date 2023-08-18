using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Titles.Validators;
using SRP.Application.Exceptions;
using SRP.Application.Features.Titles.Requests.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Titles.Handlers.Commands;

public class UpdateTitleCommandHandler : IRequestHandler<UpdateTitleCommand, Unit>
{
    private readonly ITitleRepository mTitleRepository;
    private readonly IMapper mMapper;

    public UpdateTitleCommandHandler(ITitleRepository provinceRepository, IMapper mapper)
    {
        mTitleRepository = provinceRepository;
        mMapper = mapper;
    }

    public async Task<Unit> Handle(UpdateTitleCommand request, CancellationToken cancellationToken)
    {
        if(request.TitleDto is null)
            throw new ArgumentNullException(nameof(request), "Request is null!");

        // Validate the request
        var tValidator = new ITitleDtoValidator(mTitleRepository);
        var tValidationResult = await tValidator.ValidateAsync(request.TitleDto, CancellationToken.None);
        if(tValidationResult.IsValid == false)
            throw new ValidationException(tValidationResult);

        var tTitle = await mTitleRepository.GetByIdAsync(request.TitleDto.Id) ?? throw new EntityNotFoundException(request.TitleDto.Id);
        mMapper.Map(request.TitleDto, tTitle);
        await mTitleRepository.UpdateAsync(tTitle);
        return Unit.Value;
    }
}
