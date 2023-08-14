using MediatR;

using SRP.Application.DTOs.Addresses;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.Addresses.Requests.Commands
{
    public class CreateAddressCommand: IRequest<BaseCommandResponse>
    {
        public CreateAddressDto? AddressDto { get; set; }
    }
}
