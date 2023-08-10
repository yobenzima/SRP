using MediatR;
using SRP.Application.DTOs.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Addresses.Requests.Queries
{
    public class GetAddressListRequest : IRequest<List<AddressDto>>
    {
    }
}
