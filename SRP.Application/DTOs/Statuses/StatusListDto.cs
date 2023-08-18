using SRP.Application.DTOs.Statuses;
using SRP.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Statuses
{
    public class StatusListDto : BaseDto
    {
        public string Code { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
