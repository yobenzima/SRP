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
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        private readonly SRPDbContext mDbContext;

        public CountryRepository(SRPDbContext dbContext) : base(dbContext)
        {
            mDbContext = dbContext;
        }

        public async Task<bool> Check2CodeExistsAsync(string a2)
        {
            return await mDbContext.Country
                .Where(c => c.A2 == a2)
                .AnyAsync();
        }

        public async Task<bool> CheckA3CodeExistsAsync(string a3)
        {
            return await mDbContext.Country
                .Where(c => c.A3 == a3)
                .AnyAsync();
        }

        public async Task<bool> CheckDialingCodeExistsAsync(int dialingCode)
        {
            return await mDbContext.Country
                .Where(c => c.DialingCode == dialingCode)
                .AnyAsync();
        }

        public async Task<bool> CheckISOExistsAsync(int isoNum)
        {
            return await mDbContext.Country
                .Where(c => c.ISO == isoNum)
                .AnyAsync();
        }

        public async Task<Country> GetCountryWithDetailsAsync(Guid id)
        {
            var tCountry = await mDbContext.Country
                .Where(c => c.Id == id)
                .Include(c => c.Province)
                .FirstOrDefaultAsync();

            return tCountry ?? throw new EntityNotFoundException(id);
        }
    }
}
