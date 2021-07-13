// <copyright file="FunCommands.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Commands
{
    using System.Threading.Tasks;
    using DSharpPlus.CommandsNext;
    using DSharpPlus.CommandsNext.Attributes;
    using DSharpPlus.Interactivity.Extensions;

    internal class FunCommands : BaseCommandsModified
    {
        // Reference Code not a real funcionality
        [Command("ping")]
        public async Task Ping(CommandContext context)
        {
            await context.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }

        // Reference Code not a real funcionality
        [Command("add")]
        public async Task Add(CommandContext context, [Description("First Number")] int numberOne, int numberTwo)
        {
            await context.Channel.SendMessageAsync((numberOne + numberTwo).ToString()).ConfigureAwait(false);
        }

        // Reference Code not a real funcionality
        [Command("response")]
        public async Task Response(CommandContext context)
        {
            DSharpPlus.Interactivity.InteractivityExtension interactivity = context.Client.GetInteractivity();

            var message = await interactivity.WaitForMessageAsync(x => x.Channel == context.Channel).ConfigureAwait(false);

            await context.Channel.SendMessageAsync(message.Result.Content);
        }

        // Reference Code not a real funcionality
        [Command("responseEmoji")]
        public async Task ResponseEmoji(CommandContext context)
        {
            DSharpPlus.Interactivity.InteractivityExtension interactivity = context.Client.GetInteractivity();

            var message = await interactivity.WaitForReactionAsync(x => x.Channel == context.Channel).ConfigureAwait(false);

            await context.Channel.SendMessageAsync(message.Result.Emoji);
        }
    }
}
