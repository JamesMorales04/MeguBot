// <copyright file="HelpCommands.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Commands
{
    using System.Collections.Generic;
    using DSharpPlus.CommandsNext;
    using DSharpPlus.CommandsNext.Converters;
    using DSharpPlus.CommandsNext.Entities;
    using DSharpPlus.Entities;
    using MeguBOT.Lang;

    internal class HelpCommands : BaseHelpFormatter
    {
        private DiscordEmbedBuilder embed;
        private SystemLang langManager;

        public HelpCommands(CommandContext context)
            : base(context)
        {
            this.embed = new DiscordEmbedBuilder();
            this.langManager = SystemLang.GetInstance();
            context.Channel.SendMessageAsync($"{this.langManager.GetResourceValue("dmhelp")}").ConfigureAwait(false);
        }

        public override BaseHelpFormatter WithCommand(Command command)
        {
            this.embed.AddField(command.Name, this.langManager.GetResourceValue(command.Name));
            return this;
        }

        public override BaseHelpFormatter WithSubcommands(IEnumerable<Command> commands)
        {
            foreach (var command in commands)
            {
                this.embed.AddField(command.Name, this.langManager.GetResourceValue(command.Name));
            }

            return this;
        }

        public override CommandHelpMessage Build()
        {
            return new CommandHelpMessage(embed: this.embed);
        }
    }
}
