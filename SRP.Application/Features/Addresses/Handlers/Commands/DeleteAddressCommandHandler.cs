using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.Exceptions;
using SRP.Application.Features.Addresses.Requests.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Addresses.Handlers.Commands
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, Unit>
    {
        private readonly IAddressRepository mAddressRepository;

        public DeleteAddressCommandHandler(IAddressRepository addressRepository)
        {
            mAddressRepository = addressRepository;
        }

        public async Task<Unit> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            if(request is null)
                throw new ArgumentNullException(nameof(request));
            
            var tAddress = await mAddressRepository.GetByIdAsync(request.Id) ?? throw new EntityNotFoundException(request.Id);
            await mAddressRepository.DeleteAsync(tAddress);

            return Unit.Value;
        }
    }
}
