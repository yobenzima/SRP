﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace SRP.Domain.Entities;

public partial class ApplicantType : BaseSubEntity
{
    public string? Code { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Application> Application { get; set; } = new List<Application>();
}