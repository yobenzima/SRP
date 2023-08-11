﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace SRP.Domain.Entities;

public partial class Contact : BaseEntity
{
    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string? FixedPhoneNumber { get; set; }

    public string MobileNumber { get; set; } = null!;

    public string? WhatsAppNumber { get; set; }

    public string EmailAddress { get; set; } = null!;

    public virtual ICollection<LegalEntityContactLink> LegalEntityContactLink { get; set; } = new List<LegalEntityContactLink>();
}