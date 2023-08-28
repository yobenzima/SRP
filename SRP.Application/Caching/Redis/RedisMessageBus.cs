using Microsoft.Extensions.DependencyInjection;

using Newtonsoft.Json;

using SRP.Application.Caching.Message;
using SRP.Application.Configuration;
using SRP.Application.Contracts.Infrastructure;

using StackExchange.Redis;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SRP.Application.Caching.Redis;

public sealed class RedisMessageBus : IMessageBus
{
    private readonly ISubscriber mSubscriber;
    private readonly IServiceProvider mServiceProvider;
    private readonly RedisConfig mRedisConfig;

    private static readonly string ClientId = Guid.NewGuid().ToString("N");

    public RedisMessageBus(ISubscriber subscriber, IServiceProvider serviceProvider, RedisConfig redisConfig)
    {
        mSubscriber = subscriber;
        mServiceProvider = serviceProvider;
        mRedisConfig = redisConfig;

        SubscribeAsync();
    }

    public void OnSubscriptionChanged(IMessageEvent message)
    {
        using var tScope = mServiceProvider.CreateScope();
        var tCache = tScope.ServiceProvider.GetRequiredService<ICacheBase>();
        switch(message.MessageType)
        {
            case (int)MessageEventType.RemoveKey:
                _ = tCache.RemoveAsync(message.Key, false);
                break;
            case (int)MessageEventType.RemoveByPrefix:
                _ = tCache.RemoveByPrefix(message.Key, false);
                break;
            case (int)MessageEventType.ClearCache:
                _ = tCache.Clear(false);
                break;
        }
    }

    public async Task PublishAsync<TMessage>(TMessage message) where TMessage : IMessageEvent
    {
        try
        {
            var tClient = new MessageEventClient
            {
                ClientId = ClientId,
                Key = message.Key,
                MessageType = message.MessageType,
            };

            var tMessage = JsonConvert.SerializeObject(tClient);
            await mSubscriber.PublishAsync(mRedisConfig.RedisPubSubChannel, tMessage);
        }
        catch(Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    public Task SubscribeAsync()
    {
        mSubscriber.SubscribeAsync(mRedisConfig.RedisPubSubChannel, (_, redisValue) =>
        {
            try
            {
                var tMessage = JsonConvert.DeserializeObject<MessageEventClient>(redisValue);
                if(tMessage != null && tMessage.ClientId != ClientId)
                    OnSubscriptionChanged(tMessage);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        });

        return Task.CompletedTask;
    }
}
