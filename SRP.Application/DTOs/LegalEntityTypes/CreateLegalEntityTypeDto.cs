using SRP.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.LegalEntityTypes
{
    public class CreateLegalEntityTypeDto : ILegalEntityTypeDto
    {
        public string Description { get; set; } = null!;
    }
}
