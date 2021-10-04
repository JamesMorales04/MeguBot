// <copyright file="IServerDB.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Domain.Interfaces.Database
{
    public interface IServerDB
    {
        /// <summary>
        /// Modifies the server language.
        /// </summary>
        /// <param name="guildID">Discord guild id.</param>
        /// <param name="lang">New lang.</param>
        public void ModifyServerLang(string guildID, string lang);

        /// <summary>
        /// Gets the language of the server.
        /// </summary>
        /// <param name="guildID">Discord guild id.</param>
        /// <returns>Current server language.</returns>
        public string GetServerLang(string guildID);

        /// <summary>
        /// Store all languages stored in mongo per server in the redis cache.
        /// </summary>
        public void SaveAllGuildLangsOnRedis();
    }
}
