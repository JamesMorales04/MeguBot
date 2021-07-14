// <copyright file="ConfigCommands.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Commands
{
    using System.Threading.Tasks;
    using DSharpPlus.CommandsNext;
    using DSharpPlus.CommandsNext.Attributes;

    internal class ConfigCommands : BaseCommandsModified
    {
        [Command("langconf")]
        public async Task Lang(CommandContext context, string lang)
        {
            switch (lang)
            {
                case "es":
                    this.LangManager.ChangeLang(lang);
                    await context.Channel.SendMessageAsync($"{this.LangManager.GetResourceValue("langChange")} {this.LangManager.GetResourceValue(lang)}").ConfigureAwait(false);
                    break;
                case "en":
                    this.LangManager.ChangeLang(lang);
                    await context.Channel.SendMessageAsync($"{this.LangManager.GetResourceValue("langChange")} {this.LangManager.GetResourceValue(lang)}").ConfigureAwait(false);
                    break;
                default:
                    await context.Channel.SendMessageAsync($"{this.LangManager.GetResourceValue("badlang")}").ConfigureAwait(false);
                    break;
            }
        }
    }
}
