// File: EpicDifficulty.cs
// Description: Represents the Epic difficulty level
// Author: Dylan Houston

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Timer;
using MazeStructure;

namespace Assets.Scripts.DifficultySettings
{
    /// <summary>
    /// Class for the Epic difficulty
    /// </summary>
    public class EpicDifficulty : IDifficulty
    {
        /// <summary>
        /// The difficulty type
        /// </summary>
        public DifficultyEnum Difficulty
        {
            get
            {
                return DifficultyEnum.EPIC;
            }

        }

        /// <summary>
        /// The difficulty type
        /// </summary>
        public string Description
        {
            get
            {
                return "You won't win in this mode.";
            }
        }

        /// <summary>
        /// The timer to use
        /// </summary>
        public ITimer timer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The difficulty type
        /// </summary>
        public string DifficultyString
        {
            get
            {
                return "EPIC";
            }
        }

        /// <summary>
        /// The difficulty type
        /// </summary>
        public Maze2D GetRandomMaze()
        {
            return Maze2D.GetInstance(20, 20);
        }

        /// <summary>
        /// Gets the scoring multiplier for the maze complete (scoring) screen
        /// </summary>
        public int GetScoringMultiplier
        {
            get
            {
                return 5;
            }
        }
    }
}
