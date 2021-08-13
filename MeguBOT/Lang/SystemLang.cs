// <copyright file="SystemLang.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Lang
{
    using System;
    using System.Resources;
    using MeguBOT.Database.LangDB;

    internal class SystemLang
    {
        private static SystemLang instance;

        private LangDB langDB;
        private System.Globalization.CultureInfo currentSystemLang;

        private SystemLang()
        {
            this.langDB = new LangDB();
            this.langDB.SaveAllGuildLangsOnRedis();
            this.ResourceManager = new ResourceManager("MeguBOT.Lang.Lang", this.GetType().Assembly);
        }

        private ResourceManager ResourceManager { get; set; }

        public static SystemLang GetInstance()
        {
            if (instance == null)
            {
                instance = new SystemLang();
            }

            return instance;
        }

        public void ChangeLang(string guildID, string lang)
        {
            this.langDB.ModifyServerLang(guildID, lang);
        }

        public string GetResourceValue(string guildID, string name)
        {
            string lang = this.langDB.GetServerLang(guildID);
            this.currentSystemLang = new System.Globalization.CultureInfo(lang);

            string value = this.ResourceManager.GetString(name, this.currentSystemLang);
            return !string.IsNullOrEmpty(value) ? value : null;
        }
    }
}