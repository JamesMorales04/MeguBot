// <copyright file="BotCore.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT
{
    using System.Threading.Tasks;
    using DSharpPlus;
    using DSharpPlus.CommandsNext;
    using DSharpPlus.EventArgs;
    using DSharpPlus.Interactivity;
    using DSharpPlus.Interactivity.Extensions;
    using MeguBOT.Commands;
    using MeguBOT.Domain.Interfaces.Bot;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class BotCore : IBotCore
    {
        private IConfiguration configuration;
        private IServiceCollection services;

        private DiscordClient Client { get; set; }

        private InteractivityExtension Interactivity { get; set; }

        private CommandsNextExtension Commands { get; set; }

        public async Task RunAsync(IConfiguration configuration, IServiceCollection services)
        {
            this.configuration = configuration;
            this.services = services;

            DiscordConfiguration discordConfig = this.DiscordConfig();
            this.ClientConfig(ref discordConfig);
            this.CommandsConfig();

            await this.Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private DiscordConfiguration DiscordConfig()
        {
            DiscordConfiguration config = new()
            {
                Token = this.configuration.GetSection("BotSettings")["token"],
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
            };
            return config;
        }

        private void ClientConfig(ref DiscordConfiguration config)
        {
            this.Client = new DiscordClient(config);
            this.Client.Ready += this.OnClientReady;

            this.Client.UseInteractivity(new InteractivityConfiguration
            {
                Timeout = System.TimeSpan.FromMinutes(2),
            });
        }

        private void CommandsConfig()
        {
            CommandsNextConfiguration commandsConfig = new()
            {
                StringPrefixes = new string[]
                {
                    this.configuration.GetSection("BotSettings")["prefix"],
                },
                EnableDms = false,
                EnableMentionPrefix = true,
                DmHelp = true,
                Services = this.services.BuildServiceProvider(),
            };

            this.Commands = this.Client.UseCommandsNext(commandsConfig);
            this.Commands.SetHelpFormatter<HelpCommands>();
            this.Commands.RegisterCommands<ConfigCommands>();
            this.Commands.RegisterCommands<BasicTextBasedInteractions>();
        }

        private Task OnClientReady(object sender, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
