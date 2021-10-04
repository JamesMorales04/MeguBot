// <copyright file="MongoDBConfiguration.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Infraestructure.Database.MongoDB
{
    using global::MongoDB.Driver;
    using MeguBOT.Domain.Interfaces.Database;

    public class MongoDBConfiguration : IDatabase
    {
        public MongoDBConfiguration(string connectionString)
        {
            MongoClientSettings settings = MongoClientSettings.FromConnectionString(connectionString);
            this.MongoClient = new MongoClient(settings);
        }

        public MongoClient MongoClient { get; set; }

        public IMongoDatabase GetMeguBotDatabase(string database)
        {
            return this.MongoClient.GetDatabase(database);
        }
    }
}
