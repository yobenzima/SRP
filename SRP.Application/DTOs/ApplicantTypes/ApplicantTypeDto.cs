using SRP.Application.DTOs.Addresses;
using SRP.Application.DTOs.Common;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.ApplicantTypes
{
    public class ApplicantTypeDto : BaseDto, IApplicantTypeDto
    {
        public string? Code { get; set; } 
        public string? Description { get; set; }
    }
}
