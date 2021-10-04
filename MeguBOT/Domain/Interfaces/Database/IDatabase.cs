// <copyright file="IDatabase.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Domain.Interfaces.Database
{
    using MongoDB.Driver;

    public interface IDatabase
    {
        /// <summary>
        /// Gets or sets this property always returns a value &lt; 1.
        /// </summary>
        public MongoClient MongoClient { get; set; }

        /// <summary>
        /// Gets MeguBot Database from mongo.
        /// </summary>
        /// <param name="database">Database name.</param>
        /// <returns> MeguBot database.</returns>
        public IMongoDatabase GetMeguBotDatabase(string database);
    }
}
