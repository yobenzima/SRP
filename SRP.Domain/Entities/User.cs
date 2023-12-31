﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace SRP.Domain.Entities;

public partial class User : BaseEntity
{
    public string Email { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public string? VerificationCode { get; set; }

    public DateTime? VerificationCodeExpiryTS { get; set; }

    public bool IsVerified { get; set; }

    public string? PasswordResetCode { get; set; }

    public DateTime? PasswordResetCodeExpiryTS { get; set; }

    public bool IsEnabled { get; set; }

    public DateTime? LastLogonTS { get; set; }

    public int BadLogonCount { get; set; }

    public DateTime? LastBadPasswordAttemptTS { get; set; }

    public bool ChangePasswordAtNextLogon { get; set; }

    public bool UserCannotChangePassword { get; set; }

    public bool PasswordNeverExpires { get; set; }

    public string? AliasName { get; set; }

    public bool IsInternal { get; set; }

    public virtual ICollection<FileUserLink> FileUserLink { get; set; } = new List<FileUserLink>();

    public virtual ICollection<Session> Session { get; set; } = new List<Session>();
}