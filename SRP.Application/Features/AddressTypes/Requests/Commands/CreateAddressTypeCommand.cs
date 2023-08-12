using MediatR;

using SRP.Application.DTOs.AddressType;
using SRP.Application.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Features.AddressTypes.Requests.Commands
{
    public class CreateAddressTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateAddressTypeDto? AddressTypeDto { get; set; }
    }
}
