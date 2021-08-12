// <copyright file="RedisConnectionService.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Services.Redis.Implementation
{
    using System;
    using MeguBOT.Services.Redis.Model;
    using Microsoft.Extensions.Configuration;
    using StackExchange.Redis;

    public sealed class RedisConnectionService : IRedisConnectionService
    {
        private static readonly Lazy<RedisConnectionService> RedisConnection = new Lazy<RedisConnectionService>(() => new RedisConnectionService());
        private IDatabase redisDatabase;

        private RedisConnectionService()
        {
        }

        public static RedisConnectionService Instance
        {
            get { return RedisConnection.Value; }
        }

        public void SetRedisConnection(string endopoint)
        {
            this.redisDatabase = ConnectionMultiplexer.Connect(new ConfigurationOptions { EndPoints = { endopoint } }).GetDatabase();
        }

        public IDatabase GetRedisConnection()
        {
            return this.redisDatabase;
        }
    }
}
