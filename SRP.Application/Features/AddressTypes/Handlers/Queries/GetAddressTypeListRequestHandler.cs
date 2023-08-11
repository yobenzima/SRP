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
    public class GetAddressTypeListRequestHandler : IRequestHandler<GetAddressTypeListRequest, List<AddressTypeListDto>>
    {
        private readonly IAddressTypeRepository mAddressTypeRepository;
        private readonly IMapper mMapper;

        public GetAddressTypeListRequestHandler(IAddressTypeRepository addressTypeRepository, IMapper mapper)
        {
            mAddressTypeRepository = addressTypeRepository;
            mMapper = mapper;
        }

        public async Task<List<AddressTypeListDto>> Handle(GetAddressTypeListRequest request, CancellationToken cancellationToken)
        {
            var tAddressType = await mAddressTypeRepository.GetAllAsync();
            return mMapper.Map<List<AddressTypeListDto>>(tAddressType);
        }
    }
}
