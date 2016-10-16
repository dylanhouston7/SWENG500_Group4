// File: MediumDifficulty.cs
// Description: Represents the Medium difficulty level
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
    /// Class for the Medium difficulty
    /// </summary>
    public class MediumDifficulty : IDifficulty
    {
        /// <summary>
        /// The difficulty type
        /// </summary>
        public DifficultyEnum Difficulty
        {
            get
            {
                return DifficultyEnum.MEDIUM;
            }
        }

        /// <summary>
        /// Returns a description associated with this difficulty
        /// </summary>
        public string Description
        {
            get
            {
                return "This difficulty does not have timing restrictions, but the mazes are bigger than easy mode.";
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
                return "MEDIUM";
            }
        }

        /// <summary>
        /// Returns a random maze for this difficulty level.
        /// </summary>
        /// <returns>A random maze</returns>
        public Maze2D GetRandomMaze()
        {
            return MazeStructure.Maze2D.GetInstance(10, 10);
        }
    }
}
