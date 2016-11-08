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
                return "Easiest mode with no timing restrictions.";
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
                return "EASY";
            }
        }

        /// <summary>
        /// Returns a random maze for this difficulty level.
        /// </summary>
        /// <returns>A random maze</returns>
        public Maze2D GetRandomMaze()
        {
            // Build Default Maze
            MazeStructure.Maze2D maze = MazeStructure.Maze2D.GetInstance(5, 5);

            // Set Basic Maze Properties
            maze.Difficulty = DifficultyEnum.EASY;


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
                return 1;
            }
        }
    }
}
