﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SRP.Domain.Entities;

public partial class LegalEntityAddressLink : BaseEntity
{
    public Guid LegalEntityId { get; set; }

    public Guid AddressId { get; set; }

    public virtual LegalEntity LegalEntity { get; set; }
}