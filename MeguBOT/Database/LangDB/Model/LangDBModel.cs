// <copyright file="LangDBModel.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Database.LangDB.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MongoDB.Bson.Serialization.Attributes;

    internal class LangDBModel
    {
        [BsonId]
        [BsonElement("guild")]
        public string DiscordGuild { get; set; }

        [BsonElement("lang")]
        [BsonDefaultValue("es")]
        public string ServerLang { get; set; }
    }
}
