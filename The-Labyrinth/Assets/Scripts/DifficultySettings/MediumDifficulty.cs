﻿// File: MediumDifficulty.cs
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
                return "No timing restrictions, but the mazes are bigger than easy mode.";
            }
        }

        /// <summary>
        /// The timer to use for the difficulty
        /// </summary>
        public ITimer Timer
        {
            get
            {
                if (_timer == null)
                {
                    _timer = new CountUpTimer();
                }
                return _timer;
            }
            set { }
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
            // Build Default Maze
            MazeStructure.Maze2D maze = MazeStructure.Maze2D.GetInstance(10, 10);

            // Set Basic Maze Properties
            maze.Difficulty = DifficultyEnum.MEDIUM;


            // Run Maze Gen on Default Maze
            MazeStructure.MazeGenerator.Generate(MazeStructure.MazeGenerator.MazeGenAlgorithmEnum.kDepthFirstSearch, maze);

            // Solve Generated Maze
            List<MazeStructure.Cell2D> maze_solution = new List<Cell2D>();
            MazeStructure.MazeSolver.Solve(MazeSolver.MazeSolverAlgorithmEnum.kRandomMouse, maze, maze.GetStartCell(), ref maze_solution);
            maze.MazeSolutionPath = maze_solution;


            return maze;
        }

        public void ResetTimer()
        {
            _timer = new CountUpTimer();
        }

        /// <summary>
        /// Gets the scoring multiplier for the maze complete (scoring) screen
        /// </summary>
        public int GetScoringMultiplier
        {
            get
            {
                return 2;
            }
        }
    }
}
