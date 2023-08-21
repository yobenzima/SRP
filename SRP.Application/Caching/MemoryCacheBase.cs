using MediatR;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using SRP.Application.Contracts.Infrastructure;
using SRP.Application.Events;
using SRP.SharedKernel.Extensions;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Infrastructure.Caching;

public class MemoryCacheBase : ICacheBase
{
    #region Fields
    private readonly IMemoryCache mMemoryCache;
    private readonly IMediator mMediator;

    private bool mDisposed;
    private static CancellationTokenSource mResetCacheToken = new();

    protected readonly ConcurrentDictionary<string, SemaphoreSlim> CacheEntries = new();
    #endregion

    #region Ctor
    public MemoryCacheBase(IMemoryCache memoryCache, IMediator mediator)
    {
        mMemoryCache = memoryCache;
        mMediator = mediator;
    }
    #endregion

    #region Methods
    public T Get<T>(string key, Func<T> acquire)
    {
        return Get(key, acquire, CommonHelper.CacheTimeInMinutes);
    }

    public T Get<T>(string key, Func<T> acquire, int cacheTime)
    {
        if(mMemoryCache.TryGetValue(key, out T? tCacheEntry)) return tCacheEntry;
        SemaphoreSlim? tSemaphoreSlim = CacheEntries.GetOrAdd(key, new SemaphoreSlim(1, 1));
        tSemaphoreSlim.Wait();
        try
        {
            if(!mMemoryCache.TryGetValue(key, out tCacheEntry))
            {
                tCacheEntry = acquire();
                if(tCacheEntry != null)
                {
                    var tCacheEntryOptions = new MemoryCacheEntryOptions();

                    mMemoryCache.Set(key, tCacheEntry, tCacheEntryOptions);
                }
            }
        }
        finally
        {
            tSemaphoreSlim.Release();
        }

        return tCacheEntry;
    }

    /// <summary>
    /// Gets or sets the value associated with the specified key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="acquire"></param>
    /// <returns></returns>
    public virtual Task<T> GetAsync<T>(string key, Func<Task<T>> acquire)
    {
        return GetAsync(key, acquire, CommonHelper.CacheTimeInMinutes);
    }

    /// <summary>
    /// Gets or sets the value associated with the specified key.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <param name="acquire"></param>
    /// <param name="cacheTime"></param>
    /// <returns></returns>
    public virtual async Task<T> GetAsync<T>(string key, Func<Task<T>> acquire, int cacheTime)
    {
        if(mMemoryCache.TryGetValue(key, out T tCacheEntry)) return tCacheEntry;
        SemaphoreSlim? tSemaphoreSlim = CacheEntries.GetOrAdd(key, new SemaphoreSlim(1, 1));
        await tSemaphoreSlim.WaitAsync();
        try
        {
            if(!mMemoryCache.TryGetValue(key, out tCacheEntry))
            {
                tCacheEntry = await acquire();
                if(tCacheEntry != null)
                    mMemoryCache.Set(key, tCacheEntry, GetMemoryCacheEntryOptions(cacheTime));
            }
        }
        finally
        {
            tSemaphoreSlim.Release();
        }

        return tCacheEntry;
    }


    public virtual Task RemoveAsync(string key, bool publisher = true)
    {
        //Remove item from caches
        mMemoryCache.Remove(key);
        //Publish event
        if(publisher)
            mMediator.Publish(new EntityCacheEvent(key, CacheEvent.Remove));

        return Task.CompletedTask;
    }

    public virtual Task RemoveByPrefixAsync(string pattern, bool publisher = true)
    {
        // Get cache keys that matches our pattern
        var tEntriesToRemove = CacheEntries.Keys.Where(p => p.StartsWith(pattern, StringComparison.OrdinalIgnoreCase)).ToList();
        // Remove matching cache entries
        foreach(var tEntry in tEntriesToRemove)
            mMemoryCache.Remove(tEntry);

        //Publish event
        if(publisher)
            mMediator.Publish(new EntityCacheEvent(pattern, CacheEvent.RemovePrefix));

        return Task.CompletedTask;
    }


    public virtual Task Clear(bool publisher = true)
    {
        foreach(var tEntry in CacheEntries.Keys.ToList())
            mMemoryCache.Remove(tEntry);

        // Cancel reset cache token
        mResetCacheToken.Cancel();
        // Dispose reset cache token
        mResetCacheToken.Dispose();

        // Create new reset cache token
        mResetCacheToken = new CancellationTokenSource();

        return Task.CompletedTask;
    }

    /// <summary>
    /// Dispose
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    /// <summary>
    /// Dispose
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if(mDisposed)
            return;

        if(disposing)
        {
            // Dispose managed resources
            mResetCacheToken?.Dispose();
        }
        mDisposed = true;
    }
    #endregion

    #region Utilities
    private MemoryCacheEntryOptions GetMemoryCacheEntryOptions(int cacheTime)
    {
        var options = new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(cacheTime) }
            .AddExpirationToken(new CancellationChangeToken(mResetCacheToken.Token))
            .RegisterPostEvictionCallback(PostEvictionCallback);

        return options;
    }

    private void PostEvictionCallback(object key, object value, EvictionReason reason, object state)
    {
        if(reason != EvictionReason.Replaced)
            CacheEntries.TryRemove(key.ToString()!, out var _);

    }
    #endregion
}
