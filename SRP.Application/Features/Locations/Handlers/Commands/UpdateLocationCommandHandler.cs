using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Locations.Validators;
using SRP.Application.Exceptions;
using SRP.Application.Features.Locations.Requests.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Locations.Handlers.Commands
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, Unit>
    {
        private readonly IProvinceRepository mProvinceRepository;
        private readonly ILocationRepository mLocationRepository;
        private readonly IMapper mMapper;

        public UpdateLocationCommandHandler(IProvinceRepository provinceRepository, ILocationRepository locationRepository, IMapper mapper)
        {
            mProvinceRepository = provinceRepository;
            mLocationRepository = locationRepository;
            mMapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            if(request.LocationDto is null)
                throw new ArgumentNullException(nameof(request.LocationDto), "Request is null!");

            var tValidator = new ILocationDtoValidator(mProvinceRepository);
            var tValidationResult = await tValidator.ValidateAsync(request.LocationDto, CancellationToken.None);
            if(tValidationResult.IsValid == false)
                throw new ValidationException(tValidationResult);

            var tLocation = await mLocationRepository.GetByIdAsync(request.LocationDto.Id) ?? throw new EntityNotFoundException(request.LocationDto.Id);
            mMapper.Map(request.LocationDto, tLocation);
            await mLocationRepository.UpdateAsync(tLocation);
            return Unit.Value;
        }
    }
}
