using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Provinces
{
    public interface IProvinceDto
    {
        Guid CountryId { get; set; }
        string Name { get; set; }
    }
}
