using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.Features.Titles.Requests.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Titles.Handlers.Commands;

public class DeleteTitleCommandHandler : IRequestHandler<DeleteTitleCommand, Unit>
{
    private readonly ITitleRepository mTitleRepository;

    public DeleteTitleCommandHandler(ITitleRepository provinceRepository)
    {
        mTitleRepository = provinceRepository;
    }

    public async Task<Unit> Handle(DeleteTitleCommand request, CancellationToken cancellationToken)
    {
        if(request is null)
            throw new ArgumentNullException(nameof(request), "Request cannot be null");

        var tTitle = await mTitleRepository.GetByIdAsync(request.Id);
        await mTitleRepository.DeleteAsync(tTitle);

        return Unit.Value;
    }
}
