﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace SRP.Domain.Entities;

public partial class AddressType : BaseEntity
{
    public string? Name { get; set; }

    public virtual ICollection<Address> Address { get; set; } = new List<Address>();
}