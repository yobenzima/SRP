using MediatR;
using SRP.Application.DTOs.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Addresses.Requests.Queries
{
    public class GetAddressDetailRequest : IRequest<AddressDto>
    {
        public Guid Id { get; set; }
    }
}
