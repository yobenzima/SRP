using Microsoft.EntityFrameworkCore;

using SRP.Application.Contracts.Persistence;
using SRP.Application.Exceptions;
using SRP.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence.Repositories
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        private readonly SRPDbContext mDbContext;

        public LocationRepository(SRPDbContext dbContext) : base(dbContext)
        {
            mDbContext = dbContext;
        }

        public async Task<bool> CheckLocationExistsAsync(Guid provinceId, string locationName, decimal longitude, decimal latitude)
        {
            return await mDbContext.Location
                .Where(l => l.ProvinceId == provinceId && 
                       l.Name.ToLower() == locationName.ToLowerInvariant() &&
                       l.Longitude == longitude &&
                       l.Latitude == latitude)
                .AnyAsync();
        }

        public async Task<List<Location>> GetLocationsByProvinceAsync(Guid provinceId)
        {
            return await mDbContext.Location
                .Where(l => l.ProvinceId == provinceId)
                .OrderBy(l => l.Name)
                .ThenBy(l => l.Province.Name)
                .ToListAsync();
        }

        public async Task<Location> GetLocationWithDetailsAsync(Guid id)
        {
            var tLocation = await mDbContext.Location
                .Where(l => l.Id == id)
                .Include(l => l.Province)
                .FirstOrDefaultAsync();

            return tLocation ?? throw new EntityNotFoundException(id);
        }
    }
}
