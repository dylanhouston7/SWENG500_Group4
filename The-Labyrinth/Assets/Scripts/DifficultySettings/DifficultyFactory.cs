// File: DifficultyFactory.cs
// Description: Specifies a factory to use for retrieving difficulty objects
// Author: Dylan Houston

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.DifficultySettings
{
    /// <summary>
    /// A factory to use for retrieving difficulty objects
    /// </summary>
    public class DifficultyFactory
    {
        /// <summary>
        /// Gets a difficulty object based on the difficultyMode specified
        /// </summary>
        /// <param name="difficultyMode">The difficulty mode</param>
        /// <returns></returns>
        public static IDifficulty CreateDifficulty(DifficultyEnum difficultyMode)
        {
            IDifficulty difficulty;

            if (difficultyMode == DifficultyEnum.EASY)
            {
                difficulty = new EasyDifficulty();
            }

            else if (difficultyMode == DifficultyEnum.MEDIUM)
            {
                difficulty = new MediumDifficulty();
            }

            else if (difficultyMode == DifficultyEnum.HARD)
            {
                difficulty = new HardDifficulty();
            }

            else if (difficultyMode == DifficultyEnum.EPIC)
            {
                difficulty = new EpicDifficulty();
            }

            else
            {
                throw new ArgumentOutOfRangeException("difficulty", "There was an invalid difficulty specified");
            }

            return difficulty;
        }
    }
}
