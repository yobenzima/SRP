using AutoMapper;

using MediatR;

using SRP.Application.Contracts.Persistence;
using SRP.Application.DTOs.Address;
using SRP.Application.Features.Addresses.Requests.Queries;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Addresses.Handlers.Queries
{
    public class GetAddressListRequestHandler : IRequestHandler<GetAddressListRequest, List<AddressDto>>
    {
        private readonly IAddressRepository mAddressRepository;
        private readonly IMapper mMapper;

        public GetAddressListRequestHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            mAddressRepository = addressRepository;
            mMapper = mapper;
        }

        public async Task<List<AddressDto>> Handle(GetAddressListRequest request, CancellationToken cancellationToken)
        {
            var tAddressList = await mAddressRepository.GetAllAsync();
            return mMapper.Map<List<AddressDto>>(tAddressList);
        }
    }
}
