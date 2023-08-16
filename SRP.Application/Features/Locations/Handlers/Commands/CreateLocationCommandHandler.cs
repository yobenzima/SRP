using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Locations.Validators;
using SRP.Application.Features.Locations.Requests.Commands;
using SRP.Application.Responses;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Locations.Handlers.Commands
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, BaseCommandResponse>
    {
        private readonly ILocationRepository mLocationRepository;
        private readonly IProvinceRepository mProvinceRepository;
        private readonly IMapper mMapper;

        public CreateLocationCommandHandler(ILocationRepository locationRepository, IProvinceRepository provinceRepository, IMapper mapper)
        {
            mLocationRepository = locationRepository;
            mProvinceRepository = provinceRepository;
            mMapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            if(request.LocationDto is null)
                throw new ArgumentNullException(nameof(request.LocationDto), "Request cannot be null");

            var tResponse = new BaseCommandResponse();
            var tValidator = new CreateLocationDtoValidator(mProvinceRepository);
            var tValidationResult = await tValidator.ValidateAsync(request.LocationDto, CancellationToken.None);

            if(tValidationResult.IsValid == false)
            {
                tResponse.Success = false;
                tResponse.Message = "Create Location failed";
                tResponse.Errors = tValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var tLocation = mMapper.Map<Location>(request.LocationDto);
                tLocation = await mLocationRepository.InsertAsync(tLocation);

                tResponse.Success = true;
                tResponse.Message = "Location created successfully";
                tResponse.Id = tLocation.Id;
            }

            return tResponse;
        }
    }
}
