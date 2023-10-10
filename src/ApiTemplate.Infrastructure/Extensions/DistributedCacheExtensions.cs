﻿using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ApiTemplate.Infrastructure.Extensions;

public static class DistributedCacheExtensions
{
    public static async Task<T> GetOrCreateAsync<T>(this IDistributedCache cache, string key,  Func<DistributedCacheEntryOptions, Task<T>> factory)
    {
        var cached = await cache.GetStringAsync(key);
        if (!string.IsNullOrEmpty(cached))
        {
            return JsonConvert.DeserializeObject<T>(cached, new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            })!;
        }
        
        var entry = new DistributedCacheEntryOptions();
        var created = await factory(entry);
        
        await cache.SetStringAsync(key, JsonConvert.SerializeObject(created, settings: new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        }), entry);
        
        return created;
    }
}