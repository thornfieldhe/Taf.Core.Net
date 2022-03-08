// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RedisClient.cs" company="" author="何翔华">
//   
// </copyright>
// <summary>
//   Redis
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using FreeRedis;
using System.Collections.Generic;
using Taf.Core.Utility;

// 何翔华
// Taf.Core.Net.Utility
// RedisClient.cs

namespace Taf.Core.Net.Utility.Cache;

using System;

/// <summary>
/// Redis单例客户端
/// </summary>
public class StaticRedisClient:SingletonBase<StaticRedisClient>{
    public void Config(string  connectionString) => Client = new RedisClient(connectionString);
    
    public RedisClient Client{ get; private set; }
    
    /// <summary>
    ///     缓存过期时间
    /// </summary>
    public  int Expiry =>43200;
}
