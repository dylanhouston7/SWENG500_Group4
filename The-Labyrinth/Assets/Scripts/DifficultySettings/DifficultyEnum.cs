// File: DifficultyEnum.cs
// Description: Specifies an enumeration to describe the difficulty modes.
// Author: Dylan Houston

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.DifficultySettings
{
    /// <summary>
    /// Enumeration to specify difficulty levels for the game
    /// </summary>
    public enum DifficultyEnum
    {
        /// <summary>
        /// Easy mode
        /// </summary>
        EASY,

        /// <summary>
        /// Normal mode
        /// </summary>
        /// 
        MEDIUM,

        /// <summary>
        /// Hard mode
        /// </summary>
        /// 
        HARD,

        /// <summary>
        /// Epic mode
        /// </summary>
        EPIC
    }
}
