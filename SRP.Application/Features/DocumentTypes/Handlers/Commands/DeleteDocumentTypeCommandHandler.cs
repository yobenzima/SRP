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
    public class DeleteDocumentTypeCommandHandler : IRequestHandler<DeleteDocumentTypeCommand, Unit>
    {
        private readonly IDocumentTypeRepository mDocumentTypeRepository;

        public DeleteDocumentTypeCommandHandler(IDocumentTypeRepository addressTypeRepository)
        {
            mDocumentTypeRepository = addressTypeRepository;
        }

        public async Task<Unit> Handle(DeleteDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            if(request is null)
                throw new ArgumentNullException($"{nameof(DeleteDocumentTypeCommand)} request is null");

            var tDocumentType = await mDocumentTypeRepository.GetByIdAsync(request.Id) ?? throw new EntityNotFoundException(request.Id);
            await mDocumentTypeRepository.DeleteAsync(tDocumentType);

            return Unit.Value;
        }
    }
}
