// File: IDifficulty.cs
// Description: Specifies an interface to use for all difficulty levels
// Author: Dylan Houston

using Assets.Scripts.Timer;
using MazeStructure;

namespace Assets.Scripts.DifficultySettings
{
    /// <summary>
    /// An interface to use for all difficulty levels
    /// </summary>
    public interface IDifficulty
    {
        /// <summary>
        /// The difficulty type
        /// </summary>
        DifficultyEnum Difficulty {get;}

        /// <summary>
        /// The difficulty type
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The timer to use
        /// </summary>
        ITimer Timer { get;}

        /// <summary>
        /// Resets the timer
        /// </summary>
        void ResetTimer();

        /// <summary>
        /// The difficulty type
        /// </summary>
        string DifficultyString { get; }

        /// <summary>
        /// The difficulty type
        /// </summary>
        Maze2D GetRandomMaze();

        /// <summary>
        /// Gets the scoring multiplier for the maze complete (scoring) screen
        /// </summary>
        int GetScoringMultiplier { get; }
    }
}
