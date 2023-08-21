using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Events;

public class EntityCacheEvent : INotification
{
    public EntityCacheEvent(string key, CacheEvent cacheEvent)
    {
        Key = key;
        CacheEvent = cacheEvent;
    }

    public string Key { get; private set; }
    public CacheEvent CacheEvent { get; private set; }
}
