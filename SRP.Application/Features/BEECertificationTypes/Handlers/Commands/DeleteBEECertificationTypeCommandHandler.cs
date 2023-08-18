using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.Features.BEECertificationTypes.Requests.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.BEECertificationTypes.Handlers.Commands;

public class DeleteBEECertificationTypeCommandHandler : IRequestHandler<DeleteBEECertificationTypeCommand, Unit>
{
    private readonly IBEECertificationTypeRepository mBEECertificationTypeRepository;

    public DeleteBEECertificationTypeCommandHandler(IBEECertificationTypeRepository provinceRepository)
    {
        mBEECertificationTypeRepository = provinceRepository;
    }

    public async Task<Unit> Handle(DeleteBEECertificationTypeCommand request, CancellationToken cancellationToken)
    {
        if(request is null)
            throw new ArgumentNullException(nameof(request), "Request cannot be null");

        var tBEECertificationType = await mBEECertificationTypeRepository.GetByIdAsync(request.Id);
        await mBEECertificationTypeRepository.DeleteAsync(tBEECertificationType);

        return Unit.Value;
    }
}
