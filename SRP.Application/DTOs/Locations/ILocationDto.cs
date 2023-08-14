using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Locations;

public interface ILocationDto
{
   Guid? ProvinceId { get; set; }
   string Name { get; set; }
}
