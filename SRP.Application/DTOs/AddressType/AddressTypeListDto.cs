using SRP.Application.DTOs.Address;
using SRP.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.AddressType
{
    public class AddressTypeListDto : BaseDto
    {
        public string? Name { get; set; }

        public virtual ICollection<AddressListDto> Address { get; set; } = new List<AddressListDto>();
    }
}
