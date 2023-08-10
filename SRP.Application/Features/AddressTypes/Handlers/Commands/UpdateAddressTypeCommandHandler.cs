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
    public class UpdateAddressTypeCommandHandler : IRequestHandler<UpdateAddressTypeCommand, Unit>
    {
        private readonly IAddressTypeRepository mAddressTypeRepository;
        private readonly IMapper mMapper;

        public UpdateAddressTypeCommandHandler(IAddressTypeRepository addressTypeRepository, IMapper mapper)
        {
            mAddressTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAddressTypeCommand request, CancellationToken cancellationToken)
        {
            // Check that the request is valid
            if(request.AddressTypeDto is null)
                return Unit.Value; //TODO: Add proper error handling

            // Fetch existing address type using Id of passed in request
            var tAddressType = await mAddressTypeRepository.GetByIdAsync(request.AddressTypeDto.Id) ?? throw new EntityNotFoundException(request.AddressTypeDto.Id);

            // Map - update the existing address type with the new values that may have been changed
            mMapper.Map(request.AddressTypeDto, tAddressType);

            // Update
            await mAddressTypeRepository.UpdateAsync(tAddressType);

            return Unit.Value;
        }
    }
}
