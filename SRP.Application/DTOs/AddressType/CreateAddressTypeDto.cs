﻿using SRP.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.AddressType
{
    public class CreateAddressTypeDto : IAddressTypeDto
    {
        public string? Name { get; set; }
    }
}
