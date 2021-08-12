// <copyright file="Configuration.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Configurations.AppConfig
{
    using System;
    using Microsoft.Extensions.Configuration;

    public sealed class Configuration
    {
        private static readonly Lazy<Configuration> RedisConnection = new Lazy<Configuration>(() => new Configuration());
        private IConfiguration configuration;

        private Configuration()
        {
            this.configuration = this.LoadConfiguration();
        }

        public static Configuration Instance
        {
            get { return RedisConnection.Value; }
        }

        public IConfiguration GetConfiguration()
        {
            return this.configuration;
        }

        private IConfiguration LoadConfiguration()
        {
            return new ConfigurationBuilder().AddJsonFile("app.config.json").Build();
        }
    }
}