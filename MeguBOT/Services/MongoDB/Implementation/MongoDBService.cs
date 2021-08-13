// <copyright file="MongoDBService.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Services.MongoDB.Implementation
{
    using System;
    using global::MongoDB.Driver;
    using MeguBOT.Services.MongoDB.Model;

    public class MongoDBService : IMongoDBService
    {
        private static readonly Lazy<MongoDBService> MongoConnection = new Lazy<MongoDBService>(() => new MongoDBService());
        private MongoClient mongoClient;

        private MongoDBService()
        {
        }

        public static MongoDBService Instance
        {
            get { return MongoConnection.Value; }
        }

        public MongoClient GetClient()
        {
            return this.mongoClient;
        }

        public void SetConnection(string connectionString)
        {
            MongoClientSettings settings = MongoClientSettings.FromConnectionString(connectionString);
            this.mongoClient = new MongoClient(settings);
        }

        public IMongoDatabase GetMeguBotDatabase()
        {
            return this.mongoClient.GetDatabase("MeguBot");
        }
    }
}
