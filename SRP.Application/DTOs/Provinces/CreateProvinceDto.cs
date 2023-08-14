using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Provinces
{
    public class CreateProvinceDto: IProvinceDto
    {
        public string Name { get; set; } = null!;
        public Guid CountryId { get; set; }
    }
}
