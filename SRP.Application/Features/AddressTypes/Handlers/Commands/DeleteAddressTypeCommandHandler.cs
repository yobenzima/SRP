using AutoMapper;

using MediatR;

using SRP.Application.Exceptions;
using SRP.Application.Features.AddressTypes.Requests.Commands;
using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.AddressTypes.Handlers.Commands
{
    public class DeleteAddressTypeCommandHandler : IRequestHandler<DeleteAddressTypeCommand, Unit>
    {
        private readonly IAddressTypeRepository mAddressTypeRepository;

        public DeleteAddressTypeCommandHandler(IAddressTypeRepository addressTypeRepository)
        {
            mAddressTypeRepository = addressTypeRepository;
        }

        public async Task<Unit> Handle(DeleteAddressTypeCommand request, CancellationToken cancellationToken)
        {
            if(request is null)
                throw new ArgumentNullException($"{nameof(DeleteAddressTypeCommand)} request is null");

            var tAddressType = await mAddressTypeRepository.GetByIdAsync(request.Id) ?? throw new EntityNotFoundException(request.Id);
            await mAddressTypeRepository.DeleteAsync(tAddressType);

            return Unit.Value;
        }
    }
}
