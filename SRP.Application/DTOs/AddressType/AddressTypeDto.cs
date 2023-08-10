using SRP.Application.DTOs.Address;
using SRP.Application.DTOs.Common;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.AddressType
{
    public class AddressTypeDto : BaseDto, IAddressTypeDto
    {
        public string? Name { get; set; }
        public IList<AddressDto> Addresses { get; set; } = new List<AddressDto>();
    }
}
