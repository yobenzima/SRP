using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.ApplicantTypes
{
    public interface IApplicantTypeDto
    {
        public string? Code { get; set; }
        string? Description { get; set; }
    }
}
