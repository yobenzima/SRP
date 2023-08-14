using SRP.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Provinces
{
    public class UpdateProvinceDto : BaseDto, IProvinceDto
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; } = null!;
    }
}
