﻿// File: HardDifficulty.cs
// Description: Represents the Hard difficulty level
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
    /// Class for the Hard difficulty
    /// </summary>
    public class HardDifficulty : IDifficulty
    {
        /// <summary>
        /// The timer object
        /// </summary>
        private ITimer _timer;

        /// <summary>
        /// The difficulty type
        /// </summary>
        public DifficultyEnum Difficulty
        {
            get
            {
                return DifficultyEnum.HARD;
            }
        }

        /// <summary>
        /// The difficulty type
        /// </summary>
        public string Description
        {
            get
            {
                return "There are timing restrictions, and the mazes are quite large.";
            }
        }

        /// <summary>
        /// The timer to use
        /// </summary>
        public ITimer Timer
        {
            get
            {
                if (_timer == null)
                {
                    _timer = new CountDownTimer(200);
                }
                return _timer;
            }
            set { }
        }

        /// <summary>
        /// The difficulty type
        /// </summary>
        public string DifficultyString
        {
            get
            {
                return "HARD";
            }
        }

        /// <summary>
        /// The difficulty type
        /// </summary>
        public Maze2D GetRandomMaze()
        {
            return MazeStructure.Maze2D.GetInstance(15, 15);
        }
        public void ResetTimer()
        {
            _timer = new CountDownTimer(200);
        }

        /// <summary>
        /// Gets the scoring multiplier for the maze complete (scoring) screen
        /// </summary>
        public int GetScoringMultiplier
        {
            get
            {
                return 3;
            }
        }
    }
}
