// <copyright file="MeguBot.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>
namespace MeguBOT
{
    public class MeguBot
    {
        public static void Main()
        {
            Startup setup = new();
            BotCore bot = new();

            bot.RunAsync(setup.Configuration, setup.Services).GetAwaiter().GetResult();
        }
    }
}
