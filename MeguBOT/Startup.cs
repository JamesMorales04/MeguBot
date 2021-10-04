// <copyright file="Startup.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT
{
    using MeguBOT.Database.LangDB;
    using MeguBOT.Domain.Interfaces.Database;
    using MeguBOT.Domain.Interfaces.Lang;
    using MeguBOT.Infraestructure.Database.MongoDB;
    using MeguBOT.Lang;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using StackExchange.Redis;
    using IDatabase = MeguBOT.Domain.Interfaces.Database.IDatabase;

    public class Startup
    {
        public Startup()
        {
            this.ConfigurationSetup();
            this.ConfigureServices();
        }

        public IServiceCollection Services { get; set; }

        public IConfiguration Configuration { get; set; }

        private void ConfigurationSetup()
        {
            this.Configuration = new ConfigurationBuilder().AddJsonFile("app.config.json").AddUserSecrets<Startup>().Build();
        }

        private void ConfigureServices()
        {
            this.Services = new ServiceCollection();

            var redisConnection = ConnectionMultiplexer.Connect(
                new ConfigurationOptions
                {
                    EndPoints = { this.Configuration.GetConnectionString("Redis") },
                });
            var mongoConnection = new MongoDBConfiguration(this.Configuration.GetConnectionString("MongoDB"));
            var serverDB = new ServerDB(mongoConnection, redisConnection);

            this.Services.AddSingleton<IServerDB>(serverDB);
            this.Services.AddSingleton<ILang>(new SystemLang(serverDB));
            this.Services.AddSingleton<IDatabase>(mongoConnection);
            this.Services.AddSingleton<IConnectionMultiplexer>(redisConnection);
        }
    }
}
