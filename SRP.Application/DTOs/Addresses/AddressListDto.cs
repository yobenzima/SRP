﻿using SRP.Application.DTOs.AddressTypes;
using SRP.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Addresses
{
    public class AddressListDto : BaseDto
    {
        public string? Floor { get; set; }
        public string? Building { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public Guid? CountryId { get; set; }
        public AddressTypeListDto? AddressType { get; set; }
    }
}
