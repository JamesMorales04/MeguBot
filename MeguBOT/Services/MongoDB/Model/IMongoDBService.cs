// <copyright file="IMongoDBService.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Services.MongoDB.Model
{
    using global::MongoDB.Driver;

    internal interface IMongoDBService
    {
        void SetConnection(string connectionString);

        MongoClient GetClient();
    }
}
