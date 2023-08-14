using MediatR;

using SRP.Application.DTOs.Addresses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Addresses.Requests.Commands
{
    public class UpdateAddressCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }

        public UpdateAddressDto? AddressDto { get; set; }
    }
}
