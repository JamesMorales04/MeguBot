// <copyright file="MemberModel.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Domain.Models
{
    using MongoDB.Bson.Serialization.Attributes;

    public class MemberModel
    {
        [BsonId]
        [BsonElement("memberid")]
        public string MemberID { get; set; }
    }
}
