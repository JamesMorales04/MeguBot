// <copyright file="ILang.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Domain.Interfaces.Lang
{
    public interface ILang
    {
        /// <summary>
        /// Modifies bot local language.
        /// </summary>
        /// <param name="guildID">Discord guild id.</param>
        /// <param name="lang">New lang.</param>
        public void ChangeLang(string guildID, string lang);

        /// <summary>
        /// Gets the locally stored language element.
        /// </summary>
        /// <param name="guildID">Discord guild id.</param>
        /// <param name="name">Text identifier.</param>
        /// <returns>Stored language value.</returns>
        public string GetResourceValue(string guildID, string name);
    }
}
