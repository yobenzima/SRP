using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Country.Validators;
using SRP.Application.Features.Country.Requests.Commands;
using SRP.Application.Responses;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Country.Handlers.Commands
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, BaseCommandResponse>
    {
        private readonly ICountryRepository mCountryRepository;
        private readonly IMapper mMapper;

        public CreateCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            mCountryRepository = countryRepository;
            mMapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            if(request.CountryDto is null)
                throw new ArgumentNullException(nameof(request));   

            var tResponse = new BaseCommandResponse();
            // Validate request
            var tValidator = new CreateCountryDtoValidator(mCountryRepository);
            var tValidationResult = await tValidator.ValidateAsync(request.CountryDto, CancellationToken.None);

            if(!tValidationResult.IsValid)
            {
                tResponse.Success = false;
                tResponse.Message = "Create Country failed";
                tResponse.Errors = tValidationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var tCountry = mMapper.Map<SRP.Domain.Entities.Country>(request.CountryDto);
                tCountry = await mCountryRepository.InsertAsync(tCountry);

                tResponse.Success = true;
                tResponse.Message = "Address Type created successfully";
                tResponse.Id = tCountry.Id;
            }

            return tResponse;
        }
    }
}
