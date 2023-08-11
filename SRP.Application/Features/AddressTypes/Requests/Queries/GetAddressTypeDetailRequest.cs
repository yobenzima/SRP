using MediatR;
using SRP.Application.DTOs.AddressType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.AddressTypes.Requests.Queries
{
    public class GetAddressTypeDetailRequest : IRequest<AddressTypeListDto>
    {
        public Guid Id { get; set; }
    }
}
