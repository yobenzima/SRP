using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.Features.Provinces.Requests.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Provinces.Handlers.Commands;

public class DeleteProvinceCommandHandler : IRequestHandler<DeleteProvinceCommand, Unit>
{
    private readonly IProvinceRepository mProvinceRepository;

    public DeleteProvinceCommandHandler(IProvinceRepository provinceRepository)
    {
        mProvinceRepository = provinceRepository;
    }

    public async Task<Unit> Handle(DeleteProvinceCommand request, CancellationToken cancellationToken)
    {
        if(request is null)
            throw new ArgumentNullException(nameof(request), "Request cannot be null");

        var tProvince = await mProvinceRepository.GetByIdAsync(request.Id);
        await mProvinceRepository.DeleteAsync(tProvince);

        return Unit.Value;
    }
}
