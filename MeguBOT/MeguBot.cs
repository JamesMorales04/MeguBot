// <copyright file="MeguBot.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>
namespace MeguBOT
{
    using MeguBOT.Configurations.AppConfig;
    using MeguBOT.Services.MongoDB.Implementation;
    using MeguBOT.Services.Redis.Implementation;
    using Microsoft.Extensions.Configuration;

    public class MeguBot
    {
        public static void Main(string[] args)
        {
            ServicesConfiguration();
            Bot bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();
        }

        private static void ServicesConfiguration()
        {
            Configuration config = Configuration.Instance;
            RedisConnectionService redisServer = RedisConnectionService.Instance;
            MongoDBService mongoService = MongoDBService.Instance;

            redisServer.SetRedisConnection(config.GetConfiguration().GetConnectionString("Redis"));
            mongoService.SetConnection(config.GetConfiguration().GetConnectionString("MongoDB"));
        }
    }
}
