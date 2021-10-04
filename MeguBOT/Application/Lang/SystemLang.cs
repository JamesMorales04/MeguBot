// <copyright file="SystemLang.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Lang
{
    using MeguBOT.Domain.Interfaces.Database;
    using MeguBOT.Domain.Interfaces.Lang;
    using System.Resources;

    public class SystemLang : ILang
    {
        private readonly IServerDB serverDB;
        private System.Globalization.CultureInfo currentSystemLang;

        public SystemLang(IServerDB serverDB)
        {
            this.serverDB = serverDB;
            this.serverDB.SaveAllGuildLangsOnRedis();
            this.ResourceManager = new ResourceManager("MeguBOT.Domain.Lang.Lang", this.GetType().Assembly);
        }

        private ResourceManager ResourceManager { get; set; }

        public void ChangeLang(string guildID, string lang)
        {
            this.serverDB.ModifyServerLang(guildID, lang);
        }

        public string GetResourceValue(string guildID, string name)
        {
            string lang = this.serverDB.GetServerLang(guildID);
            this.currentSystemLang = new System.Globalization.CultureInfo(lang);

            string value = this.ResourceManager.GetString(name, this.currentSystemLang);
            return !string.IsNullOrEmpty(value) ? value : null;
        }
    }
}