using MediatR;

using Microsoft.Extensions.Caching.Memory;

using SRP.Application.Caching.Message;
using SRP.Application.Contracts.Infrastructure;
using SRP.Infrastructure.Caching;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Caching.Redis;

public class RedisMessageCacheManager : MemoryCacheBase, ICacheBase
{
    private readonly IMemoryCache mMemoryCache;
    private readonly IMessageBus mMessageBus;

    public RedisMessageCacheManager(IMemoryCache memoryCache, IMediator mediator, IMessageBus messageBus) : base(memoryCache, mediator)
    {
        mMemoryCache = memoryCache;
        mMessageBus = messageBus;
    }

    /// <summary>
    /// Removes the value with specified key from the cache
    /// </summary>
    /// <param name="key"></param>
    /// <param name="publisher"></param>
    /// <returns></returns>
    public override Task RemoveAsync(string key, bool publisher = true)
    {
        mMemoryCache.Remove(key);

        if(publisher)
            _ = mMessageBus.PublishAsync(new MessageEvent { Key = key, MessageType = (int)MessageEventType.RemoveKey });

        return Task.CompletedTask;
    }

    /// <summary>
    /// Removes items by key prefix
    /// </summary>
    /// <param name="prefix"></param>
    /// <param name="publisher"></param>
    /// <returns></returns>
    public override Task RemoveByPrefix(string prefix, bool publisher = true)
    {
        var tEntriesToRemove = CacheEntries.Where(x => x.Key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase));
        foreach(var tEntry in tEntriesToRemove)
            mMemoryCache.Remove(tEntry.Key);

        if(publisher)
            _ = mMessageBus.PublishAsync(new MessageEvent { Key = prefix, MessageType = (int)MessageEventType.RemoveKey });

        return Task.CompletedTask;
    }

    /// <summary>
    /// Clear all cache data
    /// </summary>
    /// <param name="publisher"></param>
    /// <returns></returns>
    public override Task Clear(bool publisher = true)
    {
        base.Clear();
        if(publisher)
            _ = mMessageBus.PublishAsync(new MessageEvent { MessageType = (int)MessageEventType.ClearCache });

        return Task.CompletedTask;
    }
}
