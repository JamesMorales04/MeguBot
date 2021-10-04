// <copyright file="ConfigCommands.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Commands
{
    using System.Threading.Tasks;
    using DSharpPlus.CommandsNext;
    using DSharpPlus.CommandsNext.Attributes;
    using MeguBOT.Domain.Interfaces.Lang;

    public class ConfigCommands : BaseCommandModule
    {
        public ILang LangManager { private get; set; }

        [Command("langconf")]
        public async Task Lang(CommandContext context, string lang)
        {
            string guildID = context.Guild.Id.ToString();

            switch (lang)
            {
                case "es":
                    this.LangManager.ChangeLang(guildID, lang);
                    await context.Channel.SendMessageAsync($"{this.LangManager.GetResourceValue(guildID, "langChange")} {this.LangManager.GetResourceValue(guildID, lang)}").ConfigureAwait(false);
                    break;
                case "en":
                    this.LangManager.ChangeLang(guildID, lang);
                    await context.Channel.SendMessageAsync($"{this.LangManager.GetResourceValue(guildID, "langChange")} {this.LangManager.GetResourceValue(guildID, lang)}").ConfigureAwait(false);
                    break;
                default:
                    await context.Channel.SendMessageAsync($"{this.LangManager.GetResourceValue(guildID, "badlang")}").ConfigureAwait(false);
                    break;
            }
        }
    }
}
