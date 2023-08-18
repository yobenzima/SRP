using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.Features.Statuses.Requests.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Statuses.Handlers.Commands;

public class DeleteStatusCommandHandler : IRequestHandler<DeleteStatusCommand, Unit>
{
    private readonly IStatusRepository mStatusRepository;

    public DeleteStatusCommandHandler(IStatusRepository provinceRepository)
    {
        mStatusRepository = provinceRepository;
    }

    public async Task<Unit> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
    {
        if(request is null)
            throw new ArgumentNullException(nameof(request), "Request cannot be null");

        var tStatus = await mStatusRepository.GetByIdAsync(request.Id);
        await mStatusRepository.DeleteAsync(tStatus);

        return Unit.Value;
    }
}
