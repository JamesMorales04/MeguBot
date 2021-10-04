// <copyright file="ServerDB.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Database.LangDB
{
    using MeguBOT.Domain.Interfaces.Database;
    using MeguBOT.Domain.Models;
    using MongoDB.Driver;
    using StackExchange.Redis;
    using IDatabase = MeguBOT.Domain.Interfaces.Database.IDatabase;

    internal class ServerDB : IServerDB
    {
        private readonly IConnectionMultiplexer redis;

        private readonly IMongoCollection<ServerModel> serverCollection;

        public ServerDB(IDatabase mongoDB, IConnectionMultiplexer redis)
        {
            this.redis = redis;
            this.serverCollection = mongoDB.GetMeguBotDatabase("MeguBot").GetCollection<ServerModel>("DiscordLang");
        }

        public void ModifyServerLang(string guildID, string lang)
        {
            var filter = Builders<ServerModel>.Filter.Eq("_id", guildID);
            var update = Builders<ServerModel>.Update.Set("lang", lang);

            var langCollectionByGuild = this.serverCollection.FindOneAndUpdate<ServerModel>(filter, update);

            this.redis.GetDatabase().KeyDelete($"lang:{guildID}");

            if (langCollectionByGuild == null)
            {
                ServerModel newGuild = new() { DiscordGuild = guildID, ServerLang = lang };
                this.serverCollection.InsertOne(newGuild);
            }

            this.SetLangDataOnRedis(guildID, lang);
        }

        public string GetServerLang(string guildID)
        {
            return this.redis.GetDatabase().StringGet($"lang:{guildID}");
        }

        public void SaveAllGuildLangsOnRedis()
        {
            var allLangsPerGuild = this.serverCollection.Find(_ => true).ToList();

            foreach (var guildLang in allLangsPerGuild)
            {
                this.SetLangDataOnRedis(guildLang.DiscordGuild, guildLang.ServerLang);
            }
        }

        private void SetLangDataOnRedis(string guildID, string lang)
        {
            this.redis.GetDatabase().StringSet($"lang:{guildID}", lang);
        }
    }
}
