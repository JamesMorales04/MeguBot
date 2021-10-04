// <copyright file="BasicTextBasedInteractions.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Commands
{
    using System;
    using System.Threading.Tasks;
    using DSharpPlus.CommandsNext;
    using DSharpPlus.CommandsNext.Attributes;
    using DSharpPlus.Entities;
    using MeguBOT.Domain.Interfaces.Lang;

    public class BasicTextBasedInteractions : BaseCommandModule
    {
        private readonly Random randomNumber;

        public BasicTextBasedInteractions()
        {
            this.randomNumber = new Random();
        }

        public ILang LangManager { private get; set; }

        [Command("insult")]
        public async Task Insult(CommandContext context, DiscordMember member)
        {
            await context.Channel.SendMessageAsync($"{member.Mention} {this.LangManager.GetResourceValue(context.Guild.Id.ToString(), $"insult{this.randomNumber.Next(1, 4)}")}").ConfigureAwait(false);
        }

        [Command("insult")]
        public async Task Insult(CommandContext context)
        {
            await context.Channel.SendMessageAsync($"{this.LangManager.GetResourceValue(context.Guild.Id.ToString(), $"insult{this.randomNumber.Next(1, 4)}")}").ConfigureAwait(false);
        }
    }
}
