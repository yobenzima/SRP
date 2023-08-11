﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace SRP.Domain.Entities;

public partial class Session : BaseEntity
{
    public Guid UserId { get; set; }

    public string IPAddress { get; set; } = null!;

    public DateTime InitializeTS { get; set; }

    public DateTime SlidingExpiryTS { get; set; }

    public DateTime HardExpiryTS { get; set; }

    public virtual User User { get; set; } = null!;
}