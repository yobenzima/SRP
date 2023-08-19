using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.Features.LocalMunicipalities.Requests.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.LocalMunicipalities.Handlers.Commands;

public class DeleteLocalMunicipalityCommandHandler : IRequestHandler<DeleteLocalMunicipalityCommand, Unit>
{
    private readonly ILocalMunicipalityRepository mLocalMunicipalityRepository;

    public DeleteLocalMunicipalityCommandHandler(ILocalMunicipalityRepository provinceRepository)
    {
        mLocalMunicipalityRepository = provinceRepository;
    }

    public async Task<Unit> Handle(DeleteLocalMunicipalityCommand request, CancellationToken cancellationToken)
    {
        if(request is null)
            throw new ArgumentNullException(nameof(request), "Request cannot be null");

        var tLocalMunicipality = await mLocalMunicipalityRepository.GetByIdAsync(request.Id);
        await mLocalMunicipalityRepository.DeleteAsync(tLocalMunicipality);

        return Unit.Value;
    }
}
