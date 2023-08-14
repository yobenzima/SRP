using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Addresses;
using SRP.Application.Features.Addresses.Requests.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Addresses.Handlers.Queries
{
    public class GetAddressDetailRequestHandler : IRequestHandler<GetAddressDetailRequest, AddressDto>
    {
        private readonly IAddressRepository mAddressRepository;
        private readonly IMapper mMapper;

        public GetAddressDetailRequestHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            mAddressRepository = addressRepository;
            mMapper = mapper;
        }

        public async Task<AddressDto> Handle(GetAddressDetailRequest request, CancellationToken cancellationToken)
        {
            var tAddress = await mAddressRepository.GetByIdAsync(request.Id);
            return mMapper.Map<AddressDto>(tAddress);
        }
    }
}
