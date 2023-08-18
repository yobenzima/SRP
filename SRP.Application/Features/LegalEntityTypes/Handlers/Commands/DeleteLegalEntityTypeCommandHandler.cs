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
    public class DeleteLegalEntityTypeCommandHandler : IRequestHandler<DeleteLegalEntityTypeCommand, Unit>
    {
        private readonly ILegalEntityTypeRepository mLegalEntityTypeRepository;

        public DeleteLegalEntityTypeCommandHandler(ILegalEntityTypeRepository addressTypeRepository)
        {
            mLegalEntityTypeRepository = addressTypeRepository;
        }

        public async Task<Unit> Handle(DeleteLegalEntityTypeCommand request, CancellationToken cancellationToken)
        {
            if(request is null)
                throw new ArgumentNullException($"{nameof(DeleteLegalEntityTypeCommand)} request is null");

            var tLegalEntityType = await mLegalEntityTypeRepository.GetByIdAsync(request.Id) ?? throw new EntityNotFoundException(request.Id);
            await mLegalEntityTypeRepository.DeleteAsync(tLegalEntityType);

            return Unit.Value;
        }
    }
}
