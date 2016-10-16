// File: EasyDifficulty.cs
// Description: Represents the Easy difficulty level
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
    /// Class for the Easy difficulty
    /// </summary>
    public class EasyDifficulty : IDifficulty
    {
        /// <summary>
        /// The difficulty type
        /// </summary>
        public DifficultyEnum Difficulty
        {
            get
            {
                return DifficultyEnum.EASY;
            }
        }

        /// <summary>
        /// Returns a description associated with this difficulty
        /// </summary>
        public string Description
        {
            get
            {
                return "This difficulty is the easiest, with no timing restrictions. The player does not get many points in this mode.";
            }
        }

        /// <summary>
        /// The timer to use for the difficulty
        /// </summary>
        public ITimer timer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Returns a string representing the difficulty level
        /// </summary>
        public string DifficultyString
        {
            get
            {
                return "EASY";
            }
        }

        /// <summary>
        /// Returns a random maze for this difficulty level.
        /// </summary>
        /// <returns>A random maze</returns>
        public Maze2D GetRandomMaze()
        {
            return MazeStructure.Maze2D.GetInstance(5, 5);
        }
    }
}
