using Microsoft.Extensions.Caching.Memory;

using SRP.Application.Contracts.Persistence;
using SRP.Application.Exceptions;
using SRP.Domain.Entities;
using SRP.SharedKernel.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence.Repositories;

/// <summary>
/// Decorator class for the CountryRepository class.
/// This class is used to cache the results of the CountryRepository class.
/// </summary>
public class CachedCountryRepository : RepositoryBase<Country>, ICountryRepository
{
    private readonly SRPDbContext mDbContext;
    private readonly CountryRepository mDecorated;
    private readonly IMemoryCache mMemoryCache;

    public CachedCountryRepository(SRPDbContext dbContext, CountryRepository decorated, IMemoryCache memoryCache) : base(dbContext)
    {
        mDbContext = dbContext;
        mDecorated = decorated;
        mMemoryCache = memoryCache;
    }

    public override Task<Country?> GetByIdAsync(Guid id)
    {
        var tKey = $"{nameof(Country)}-{id}";
        
        return mMemoryCache.GetOrCreateAsync(
            tKey, 
            entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(CommonHelper.CacheTimeInMinutes));

                return mDecorated.GetByIdAsync(id);
            });
    }

    public Task<bool> Check2CodeExistsAsync(string a2)
    {
        return mDecorated.Check2CodeExistsAsync(a2);
    }

    public Task<bool> CheckA3CodeExistsAsync(string a3)
    {
        return mDecorated.CheckA3CodeExistsAsync(a3);
    }

    public Task<bool> CheckDialingCodeExistsAsync(int dialingCode)
    {
        return mDecorated.CheckDialingCodeExistsAsync(dialingCode);
    }

    public Task<bool> CheckISOExistsAsync(int isoNum)
    {
        return mDecorated.CheckISOExistsAsync(isoNum);
    }

    public Task<Country> GetCountryWithDetailsAsync(Guid id)
    {
        return mDecorated.GetCountryWithDetailsAsync(id);
    }
}
