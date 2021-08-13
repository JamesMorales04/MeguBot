// <copyright file="DatabaseCore.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Database
{
    using MeguBOT.Services.MongoDB.Implementation;
    using MeguBOT.Services.Redis.Implementation;
    using MongoDB.Driver;
    using StackExchange.Redis;

    internal class DatabaseCore
    {
        private IMongoDatabase meguBotDatabase;
        private IDatabase meguBotRedis;

        public DatabaseCore()
        {
            this.meguBotDatabase = MongoDBService.Instance.GetMeguBotDatabase();
            this.meguBotRedis = RedisConnectionService.Instance.GetRedisConnection();
        }

        public IMongoDatabase GetMeguBotDatabase()
        {
            return this.meguBotDatabase;
        }

        public IDatabase GetMeguBotRedis()
        {
            return this.meguBotRedis;
        }
    }
}
