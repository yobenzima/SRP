﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace SRP.Domain.Entities;

public partial class DocumentType : BaseSubEntity
{
    public int SortIndex { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Document>? Document { get; set; } = new List<Document>();
}