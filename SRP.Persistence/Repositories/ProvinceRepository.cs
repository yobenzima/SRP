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
    public class ProvinceRepository : RepositoryBase<Province>, IProvinceRepository
    {
        private readonly SRPDbContext mDbContext;

        public ProvinceRepository(SRPDbContext dbContext) : base(dbContext)
        {
            mDbContext = dbContext;
        }

        public async Task<bool> CheckProvinceExistsAsync(Guid? id)
        {
            return await mDbContext.Province
                .Where(p => p.Id == id)
                .AnyAsync();
        }

        public async Task<bool> CheckProvinceExistsAsync(Guid countryId, string provinceName)
        {
            return await mDbContext.Province
                .Where(p => p.CountryId == countryId && 
                       p.Name.ToLowerInvariant() == provinceName.ToLowerInvariant())
                .AnyAsync();
        }

        public async Task<Province> GetProvinceWithDetailsAsync(Guid id)
        {
            var tProvince = await mDbContext.Province
                .Where(p => p.Id == id)
                .Include(p => p.Country)
                .FirstOrDefaultAsync(); 

            return tProvince ?? throw new EntityNotFoundException(id);
        }
    }
}
