// <copyright file="FunCommands.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Commands
{
    using System.Threading.Tasks;
    using DSharpPlus.CommandsNext;
    using DSharpPlus.CommandsNext.Attributes;
    using DSharpPlus.Interactivity.Extensions;

    internal class FunCommands : BaseCommandModule
    {
        [Command("ping")]
        public async Task Ping(CommandContext context)
        {
            await context.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }

        [Command("insult")]
        [Description("Simple test ping command")]
        public async Task Insult(CommandContext context, [Description("Target name")] string name)
        {
            await context.Channel.SendMessageAsync($"{name} Manco de mrd").ConfigureAwait(false);
        }

        [Command("add")]
        [Description("Simple test add command")]
        public async Task Add(CommandContext context, [Description("First Number")] int numberOne, int numberTwo)
        {
            await context.Channel.SendMessageAsync((numberOne + numberTwo).ToString()).ConfigureAwait(false);
        }

        [Command("response")]
        public async Task Response(CommandContext context)
        {
            DSharpPlus.Interactivity.InteractivityExtension interactivity = context.Client.GetInteractivity();

            var message = await interactivity.WaitForMessageAsync(x => x.Channel == context.Channel).ConfigureAwait(false);

            await context.Channel.SendMessageAsync(message.Result.Content);
        }

        [Command("responseEmoji")]
        public async Task ResponseEmoji(CommandContext context)
        {
            DSharpPlus.Interactivity.InteractivityExtension interactivity = context.Client.GetInteractivity();

            var message = await interactivity.WaitForReactionAsync(x => x.Channel == context.Channel).ConfigureAwait(false);

            await context.Channel.SendMessageAsync(message.Result.Emoji);
        }
    }
}
