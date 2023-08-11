﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace SRP.Domain.Entities;

public partial class Country : BaseEntity
{
    public string Name { get; set; } = null!;

    public int ISO { get; set; }

    public string A3 { get; set; } = null!;

    public string A2 { get; set; } = null!;

    public int DialingCode { get; set; }

    public virtual ICollection<Address> Address { get; set; } = new List<Address>();

    public virtual ICollection<Province> Province { get; set; } = new List<Province>();
}