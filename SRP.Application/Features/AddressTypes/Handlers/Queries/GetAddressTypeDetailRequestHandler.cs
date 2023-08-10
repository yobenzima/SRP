using AutoMapper;

using MediatR;
using SRP.Application.DTOs.AddressType;
using SRP.Application.Features.AddressTypes.Requests.Queries;
using SRP.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.AddressTypes.Handlers.Queries
{
    public class GetAddressTypeDetailRequestHandler : IRequestHandler<GetAddressTypeDetailRequest, AddressTypeDto>
    {
        private readonly IAddressTypeRepository mAddressTypeRepository;
        private readonly IMapper mMapper;

        public GetAddressTypeDetailRequestHandler(IAddressTypeRepository addressTypeRepository, IMapper mapper)
        {
            mAddressTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<AddressTypeDto> Handle(GetAddressTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var tAddressType = await mAddressTypeRepository.GetByIdAsync(request.Id);
            return mMapper.Map<AddressTypeDto>(tAddressType);
        }
    }
}
