// <copyright file="BaseCommandsModifiedImages.cs" company="DarkFlame Software">
// Copyright (c) DarkFlame Software. All rights reserved.
// </copyright>

namespace MeguBOT.Commands.BaseCommandsClases
{
    using DSharpPlus.CommandsNext;

    public class BaseCommandsModifiedImages : BaseCommandModule
    {
        public string ResultLinkValidation(string boruSearch)
        {
            if (boruSearch == string.Empty)
            {
                return "https://media2.giphy.com/media/iCbBAJpfvm17G/giphy.gif";
            }

            return boruSearch;
        }

        public string[] KeywordsUppercase(string[] keywords)
        {
            for (int keywordIndex = 0; keywordIndex < keywords.Length; keywordIndex++)
            {
                keywords[keywordIndex] = char.ToUpper(keywords[keywordIndex][0]) + keywords[keywordIndex][1..];
            }

            return keywords;
        }
    }
}
