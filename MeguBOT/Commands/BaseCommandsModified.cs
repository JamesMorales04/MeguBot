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
            this.LangManager = new LangManager("MeguBOT.Lang.Lang", this.GetType().Assembly);
        }

        public LangManager LangManager { get; private set; }
    }
}
