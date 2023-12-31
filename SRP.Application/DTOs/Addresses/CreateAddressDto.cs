﻿using SRP.Application.DTOs.AddressTypes;
using SRP.Application.DTOs.Common;
using SRP.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Addresses;

public class CreateAddressDto : IAddressDto
{
    public Guid AddressTypeId { get; set; }
    public int SlotIndex { get; set; }
    public string? Floor { get; set; }
    public string? Building { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public Guid? LocationId { get; set; }
    public Guid ProvinceId { get; set; }
    public Guid CountryId { get; set; }
}
