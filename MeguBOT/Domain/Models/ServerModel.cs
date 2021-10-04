// <copyright file="ServerModel.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Domain.Models
{
    using MongoDB.Bson.Serialization.Attributes;

    public class ServerModel
    {
        [BsonId]
        [BsonElement("guild")]
        public string DiscordGuild { get; set; }

        [BsonElement("lang")]
        [BsonDefaultValue("en")]
        public string ServerLang { get; set; }

        [BsonElement("members")]
        public MemberModel[] Members { get; set; }
    }
}
