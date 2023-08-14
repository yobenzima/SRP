using SRP.Application.DTOs.Common;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Provinces
{
    public class ProvinceDto: BaseDto, IProvinceDto
    {
        public string Name { get; set; } = null!;
    }
}
