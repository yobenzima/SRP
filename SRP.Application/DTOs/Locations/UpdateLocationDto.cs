using SRP.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Locations;

public class UpdateLocationDto : BaseDto, ILocationDto
{
    public Guid? ProvinceId { get; set; }
    public string Name { get; set; } = null!;
    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
}
