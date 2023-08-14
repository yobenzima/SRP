using SRP.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.DTOs.Locations;

public class LocationDto : BaseDto, ILocationDto
{
    public Guid? ProvinceId { get; set; }
    public string Name { get; set; } = null!;
    public string ProvinceName { get; set; } = null!;
    public string CountryName { get; set; } = null!;
    public long Longitude { get; set; }
    public long Latitude { get; set; }
}
