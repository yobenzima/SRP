using AutoMapper;

using MediatR;

using SRP.Application.Exceptions;
using SRP.Application.Features.LegalEntityTypes.Requests.Commands;
using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.LegalEntityTypes.Handlers.Commands
{
    public class UpdateLegalEntityTypeCommandHandler : IRequestHandler<UpdateLegalEntityTypeCommand, Unit>
    {
        private readonly ILegalEntityTypeRepository mLegalEntityTypeRepository;
        private readonly IMapper mMapper;

        public UpdateLegalEntityTypeCommandHandler(ILegalEntityTypeRepository addressTypeRepository, IMapper mapper)
        {
            mLegalEntityTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLegalEntityTypeCommand request, CancellationToken cancellationToken)
        {
            // Check that the request is valid
            if(request.LegalEntityTypeDto is null)
                return Unit.Value; //TODO: Add proper error handling

            // Fetch existing address type using Id of passed in request
            var tLegalEntityType = await mLegalEntityTypeRepository.GetByIdAsync(request.LegalEntityTypeDto.Id) ?? throw new EntityNotFoundException(request.LegalEntityTypeDto.Id);

            // Map - update the existing address type with the new values that may have been changed
            mMapper.Map(request.LegalEntityTypeDto, tLegalEntityType);

            // Update
            await mLegalEntityTypeRepository.UpdateAsync(tLegalEntityType);

            return Unit.Value;
        }
    }
}
