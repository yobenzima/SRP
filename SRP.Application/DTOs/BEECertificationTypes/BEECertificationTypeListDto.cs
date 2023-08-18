﻿using SRP.Application.DTOs.BEECertificationTypes;
using SRP.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.BEECertificationTypes
{
    public class BEECertificationTypeListDto : BaseDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public BEECertificationTypeListDto? BEECertificationTypeType { get; set; }
    }
}
