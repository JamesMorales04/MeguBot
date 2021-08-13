// <copyright file="LangDB.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Database.LangDB
{
    using System;
    using System.Threading.Tasks;
    using MeguBOT.Database.LangDB.Model;
    using MongoDB.Driver;

    internal class LangDB : DatabaseCore
    {
        private IMongoCollection<LangDBModel> langCollection;

        public LangDB()
        {
            this.langCollection = this.GetMeguBotDatabase().GetCollection<LangDBModel>("DiscordLang");
        }

        public void ModifyServerLang(string guildID, string lang)
        {
            var filter = Builders<LangDBModel>.Filter.Eq("_id", guildID);
            var update = Builders<LangDBModel>.Update.Set("lang", lang);

            var langCollectionByGuild = this.langCollection.FindOneAndUpdate<LangDBModel>(filter, update);

            this.GetMeguBotRedis().KeyDelete($"lang:{guildID}");

            if (langCollectionByGuild == null)
            {
                LangDBModel newGuild = new LangDBModel { DiscordGuild = guildID, ServerLang = lang };
                this.langCollection.InsertOne(newGuild);
            }

            this.SetLangDataOnRedis(guildID, lang);
        }

        public string GetServerLang(string guildID)
        {
            return this.GetMeguBotRedis().StringGet($"lang:{guildID}");
        }

        public void SaveAllGuildLangsOnRedis()
        {
            var allLangsPerGuild = this.langCollection.Find(_ => true).ToList();

            foreach (var guildLang in allLangsPerGuild)
            {
                this.SetLangDataOnRedis(guildLang.DiscordGuild, guildLang.ServerLang);
            }
        }

        private void SetLangDataOnRedis(string guildID, string lang)
        {
            this.GetMeguBotRedis().StringSet($"lang:{guildID}", lang);
        }
    }
}
