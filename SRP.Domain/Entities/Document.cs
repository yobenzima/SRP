﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace SRP.Domain.Entities;

public partial class Document : BaseEntity
{
    public Guid FileId { get; set; }

    public Guid? DocumentTypeId { get; set; }

    public Guid? LegalEntityId { get; set; }

    public string Name { get; set; } = null!;

    public string Extension { get; set; } = null!;

    public int Size { get; set; }

    public DateTime DocumentTS { get; set; }

    public byte[]? DataBytes { get; set; }

    public virtual DocumentType? DocumentType { get; set; }

    public virtual File File { get; set; } = null!;

    public virtual LegalEntity? LegalEntity { get; set; }
}