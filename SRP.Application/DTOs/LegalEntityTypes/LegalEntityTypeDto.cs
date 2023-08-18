using SRP.Application.DTOs.Addresses;
using SRP.Application.DTOs.Common;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.LegalEntityTypes
{
    public class LegalEntityTypeDto : BaseDto, ILegalEntityTypeDto
    { 
        public string Description { get; set; } = null!;
    }
}
