using Microsoft.Extensions.Caching.Memory;

using SRP.Application.Caching.Constants;
using SRP.Application.Contracts.Infrastructure;
using SRP.Application.Contracts.Persistence;
using SRP.Application.Exceptions;
using SRP.Domain.Entities;
using SRP.SharedKernel.Extensions;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Persistence.Repositories;

/// <summary>
/// Decorator for the CountryRepository class.
/// This class is used to cache the results of the CountryRepository class.
/// </summary>
public class CachedCountryRepository : RepositoryBase<Country>, ICountryRepository
{
    private readonly SRPDbContext mDbContext;
    private readonly CountryRepository mDecorated;
    private readonly ICacheBase mCacheBase;

    public CachedCountryRepository(SRPDbContext dbContext, CountryRepository decorated, ICacheBase cacheBase) : base(dbContext)
    {
        mDbContext = dbContext;
        mDecorated = decorated;
        mCacheBase = cacheBase;
    }

    public override async Task<List<Country>?> GetAllAsync()
    {
        var tCacheKey = String.Format(CacheKey.COUNTRYATTRIBUTES_ALL);
        return await mCacheBase.GetAsync(tCacheKey, () => mDecorated.GetAllAsync());            
    }

    public override Task<Country?> GetByIdAsync(Guid id)
    {
        // Create a cache key using the id.
        var tCacheKey = String.Format(CacheKey.COUNTRYATTRIBUTES_BY_ID_KEY, id);
        // Return the cached value if it exists, otherwise create it.
        return mCacheBase.GetAsync(
            tCacheKey, () =>  mDecorated.GetByIdAsync(id));
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
