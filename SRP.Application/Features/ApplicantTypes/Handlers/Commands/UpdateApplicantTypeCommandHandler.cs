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
    public class UpdateApplicantTypeCommandHandler : IRequestHandler<UpdateApplicantTypeCommand, Unit>
    {
        private readonly IApplicantTypeRepository mApplicantTypeRepository;
        private readonly IMapper mMapper;

        public UpdateApplicantTypeCommandHandler(IApplicantTypeRepository addressTypeRepository, IMapper mapper)
        {
            mApplicantTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<Unit> Handle(UpdateApplicantTypeCommand request, CancellationToken cancellationToken)
        {
            // Check that the request is valid
            if(request.ApplicantTypeDto is null)
                return Unit.Value; //TODO: Add proper error handling

            // Fetch existing address type using Id of passed in request
            var tApplicantType = await mApplicantTypeRepository.GetByIdAsync(request.ApplicantTypeDto.Id) ?? throw new EntityNotFoundException(request.ApplicantTypeDto.Id);

            // Map - update the existing address type with the new values that may have been changed
            mMapper.Map(request.ApplicantTypeDto, tApplicantType);

            // Update
            await mApplicantTypeRepository.UpdateAsync(tApplicantType);

            return Unit.Value;
        }
    }
}
