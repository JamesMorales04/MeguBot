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
    using MeguBOT.Domain.Interfaces.Lang;
    using MeguBOT.Lang;

    public class HelpCommands : BaseHelpFormatter
    {
        private readonly DiscordEmbedBuilder embed;
        private readonly string guildID;

        public HelpCommands(CommandContext context)
            : base(context)
        {
            this.guildID = context.Guild.Id.ToString();
            this.embed = new DiscordEmbedBuilder();

            this.LangManager = (SystemLang)context.Services.GetService(typeof(ILang));

            context.Channel.SendMessageAsync($"{this.LangManager.GetResourceValue(this.guildID, "dmhelp")}").ConfigureAwait(false);
        }

        public SystemLang LangManager { private get; set; }

        public override BaseHelpFormatter WithCommand(Command command)
        {
            this.embed.AddField(command.Name, this.LangManager.GetResourceValue(this.guildID, command.Name));
            return this;
        }

        public override BaseHelpFormatter WithSubcommands(IEnumerable<Command> commands)
        {
            foreach (var command in commands)
            {
                this.embed.AddField(command.Name, this.LangManager.GetResourceValue(this.guildID, command.Name));
            }

            return this;
        }

        public override CommandHelpMessage Build()
        {
            return new CommandHelpMessage(embed: this.embed);
        }
    }
}
