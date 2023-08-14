using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.Exceptions;
using SRP.Application.Features.Countries.Requests.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Countries.Handlers.Commands
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Unit>
    {
        private readonly ICountryRepository mCountryRepository;

        public DeleteCountryCommandHandler(ICountryRepository countryRepository)
        {
            mCountryRepository = countryRepository;
        }

        public async Task<Unit> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            if(request is null)
                throw new ArgumentNullException(nameof(request), "Request cannot null!");

            var tAddressType = await mCountryRepository.GetByIdAsync(request.Id) ?? throw new EntityNotFoundException(request.Id);
            await mCountryRepository.DeleteAsync(tAddressType);

            return Unit.Value;
        }
    }
}
