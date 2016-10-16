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

        string Description { get; }

        /// <summary>
        /// The timer to use for the difficulty
        /// </summary>
        ITimer timer { get;}

        string DifficultyString { get; }

        /// <summary>
        /// Returns a random maze for this difficulty level.
        /// </summary>
        /// <returns>A random maze</returns>
       Maze2D GetRandomMaze();
    }
}
