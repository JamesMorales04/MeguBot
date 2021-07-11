// <copyright file="TeamCommands.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Commands
{
    using System.Threading.Tasks;
    using DSharpPlus.CommandsNext;
    using DSharpPlus.CommandsNext.Attributes;
    using DSharpPlus.Entities;
    using DSharpPlus.Interactivity.Extensions;

    internal class TeamCommands : BaseCommandModule
    {
        [Command("join")]
        public async Task Join(CommandContext context)
        {
            var joinEmbed = new DiscordEmbedBuilder
            {
                Title = "Would you like to join?",
                Thumbnail = new DiscordEmbedBuilder.EmbedThumbnail { Url = context.Client.CurrentUser.AvatarUrl },
                Color = DiscordColor.Green,
            };

            DiscordMessage joinMessage = await context.Channel.SendMessageAsync(embed: joinEmbed).ConfigureAwait(false);
            DiscordEmoji thumsUpEmoji = DiscordEmoji.FromName(context.Client, ":+1");
            DiscordEmoji thumsDownEmoji = DiscordEmoji.FromName(context.Client, ":-1");

            await joinMessage.CreateReactionAsync(thumsUpEmoji).ConfigureAwait(false);
            await joinMessage.CreateReactionAsync(thumsDownEmoji).ConfigureAwait(false);

            DSharpPlus.Interactivity.InteractivityExtension interactivity = context.Client.GetInteractivity();

            var result = await interactivity.WaitForReactionAsync(
                x => (x.Message == joinMessage &&
                x.Message.Author.Id == context.Member.Id &&
                x.Emoji == thumsUpEmoji) ||
                x.Emoji == thumsDownEmoji).ConfigureAwait(false);

            if (result.Result.Emoji == thumsUpEmoji)
            {
                var role = context.Guild.GetRole(691825272462508092);
                await context.Member.GrantRoleAsync(role);
            }
            else
            {
                // NO
            }
        }
    }
}
