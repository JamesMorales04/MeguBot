// <copyright file="IBotCore.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Domain.Interfaces.Bot
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public interface IBotCore
    {
        /// <summary>
        /// Run the Bot.
        /// </summary>
        /// <param name="configuration">Program Configuration.</param>
        /// <param name="services">Program Services.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public Task RunAsync(IConfiguration configuration, IServiceCollection services);
    }
}
