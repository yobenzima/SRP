using AutoMapper;

using MediatR;

using SRP.Application.Exceptions;
using SRP.Application.Features.DocumentTypes.Requests.Commands;
using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.DocumentTypes.Handlers.Commands
{
    public class UpdateDocumentTypeCommandHandler : IRequestHandler<UpdateDocumentTypeCommand, Unit>
    {
        private readonly IDocumentTypeRepository mDocumentTypeRepository;
        private readonly IMapper mMapper;

        public UpdateDocumentTypeCommandHandler(IDocumentTypeRepository addressTypeRepository, IMapper mapper)
        {
            mDocumentTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            // Check that the request is valid
            if(request.DocumentTypeDto is null)
                return Unit.Value; //TODO: Add proper error handling

            // Fetch existing address type using Id of passed in request
            var tDocumentType = await mDocumentTypeRepository.GetByIdAsync(request.DocumentTypeDto.Id) ?? throw new EntityNotFoundException(request.DocumentTypeDto.Id);

            // Map - update the existing address type with the new values that may have been changed
            mMapper.Map(request.DocumentTypeDto, tDocumentType);

            // Update
            await mDocumentTypeRepository.UpdateAsync(tDocumentType);

            return Unit.Value;
        }
    }
}
