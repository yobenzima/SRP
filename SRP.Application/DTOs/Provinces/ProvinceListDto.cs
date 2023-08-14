using SRP.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Provinces
{
    public class ProvinceListDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string CountryName { get; set; } = null!;
    }
}
