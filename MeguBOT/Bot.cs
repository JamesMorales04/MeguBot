// <copyright file="Bot.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT
{
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using DSharpPlus;
    using DSharpPlus.CommandsNext;
    using DSharpPlus.EventArgs;
    using DSharpPlus.Interactivity;
    using DSharpPlus.Interactivity.Extensions;
    using MeguBOT.Commands;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    internal class Bot
    {
        private DiscordClient Client { get; set; }

        private InteractivityExtension Interactivity { get; set; }

        private CommandsNextExtension Commands { get; set; }

        public async Task RunAsync()
        {
            string json = this.ReadJsonParameters().Result;
            ConfigJson configJson = JsonConvert.DeserializeObject<ConfigJson>(json);
            DiscordConfiguration config = this.DiscordConfig(ref configJson);
            this.ClientConfig(ref config);
            this.CommandsConfig(ref configJson);

            await this.Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private async Task<string> ReadJsonParameters()
        {
            using FileStream file = File.OpenRead("config.json");
            using StreamReader reader = new StreamReader(file, new UTF8Encoding(false));
            return await reader.ReadToEndAsync().ConfigureAwait(false);
        }

        private DiscordConfiguration DiscordConfig(ref ConfigJson configJson)
        {
            DiscordConfiguration config = new DiscordConfiguration
            {
                Token = configJson.Token,
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

        private void CommandsConfig(ref ConfigJson configJson)
        {
            CommandsNextConfiguration commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[]
                {
                    configJson.Prefix,
                },
                EnableDms = false,
                EnableMentionPrefix = true,
                DmHelp = true,
            };

            this.Commands = this.Client.UseCommandsNext(commandsConfig);
            this.Commands.SetHelpFormatter<HelpCommands>();
            this.Commands.RegisterCommands<BasicTextBasedInteractions>();
            this.Commands.RegisterCommands<ConfigCommands>();
        }

        private Task OnClientReady(object sender, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
