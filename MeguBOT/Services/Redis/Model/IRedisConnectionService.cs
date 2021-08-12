// <copyright file="IRedisConnectionService.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Services.Redis.Model
{
    using StackExchange.Redis;

    internal interface IRedisConnectionService
    {
        void SetRedisConnection(string endopoint);

        IDatabase GetRedisConnection();
    }
}
