using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Country.Validators;
using SRP.Application.Exceptions;
using SRP.Application.Features.Country.Requests.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Country.Handlers.Commands
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Unit>
    {
        private readonly ICountryRepository mCountryRepository;
        private readonly IMapper mMapper;

        public UpdateCountryCommandHandler(ICountryRepository countryRepository, IMapper mapper)
        {
            mCountryRepository = countryRepository;
            mMapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            if(request.CountryDto is null)
                throw new ArgumentNullException($"{nameof(UpdateCountryCommand)} is null!"); //TODO: Add proper error handling

            // Validate the request
            var tValidator = new ICountryDtoValidator(mCountryRepository);
            var tValidationResult = await tValidator.ValidateAsync(request.CountryDto, CancellationToken.None);

            if(!tValidationResult.IsValid)
                throw new ValidationException(tValidationResult);
  
            var tCountry = await mCountryRepository.GetByIdAsync(request.CountryDto.Id) ?? throw new EntityNotFoundException(request.CountryDto.Id);
            mMapper.Map(request.CountryDto, tCountry);
            await mCountryRepository.UpdateAsync(tCountry);

            return Unit.Value;
        }
    }
}
