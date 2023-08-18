using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.BEECertificationTypes
{
    public interface IBEECertificationTypeDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}
