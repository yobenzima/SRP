﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace SRP.Domain.Entities;

public partial class BEECertificationType : BaseEntity
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<LegalEntity> LegalEntity { get; set; } = new List<LegalEntity>();
}