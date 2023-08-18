using AutoMapper;

using MediatR;

using SRP.Application.Exceptions;
using SRP.Application.Features.ApplicantTypes.Requests.Commands;
using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.ApplicantTypes.Handlers.Commands
{
    public class DeleteApplicantTypeCommandHandler : IRequestHandler<DeleteApplicantTypeCommand, Unit>
    {
        private readonly IApplicantTypeRepository mApplicantTypeRepository;

        public DeleteApplicantTypeCommandHandler(IApplicantTypeRepository addressTypeRepository)
        {
            mApplicantTypeRepository = addressTypeRepository;
        }

        public async Task<Unit> Handle(DeleteApplicantTypeCommand request, CancellationToken cancellationToken)
        {
            if(request is null)
                throw new ArgumentNullException($"{nameof(DeleteApplicantTypeCommand)} request is null");

            var tApplicantType = await mApplicantTypeRepository.GetByIdAsync(request.Id) ?? throw new EntityNotFoundException(request.Id);
            await mApplicantTypeRepository.DeleteAsync(tApplicantType);

            return Unit.Value;
        }
    }
}
