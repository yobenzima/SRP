﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace SRP.Domain.Entities;

public partial class FileUserLink : BaseEntity
{
    public Guid FileId { get; set; }

    public Guid UserId { get; set; }

    public virtual File File { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}