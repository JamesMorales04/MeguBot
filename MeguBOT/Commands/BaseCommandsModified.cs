// <copyright file="BaseCommandsModified.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Commands
{
    using DSharpPlus.CommandsNext;
    using MeguBOT.Lang;

    internal class BaseCommandsModified : BaseCommandModule
    {
        public BaseCommandsModified()
        {
            this.LangManager = SystemLang.GetInstance();
        }

        public SystemLang LangManager { get; private set; }

    }
}
