using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Contracts.Persistence;

public interface ILocationRepository : IRepositoryBase<Location>
{
    Task<bool> CheckLocationExistsAsync(Guid provinceId, string locationName, decimal longitude, decimal latitude);
    Task<Location> GetLocationWithDetailsAsync(Guid id);
    Task<List<Location>> GetLocationsByProvinceAsync(Guid provinceId);
}
