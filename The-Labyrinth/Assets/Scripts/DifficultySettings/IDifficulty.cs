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
        /// </summary>
        ITimer timer { get;}

        /// <summary>
        /// The difficulty type
        /// </summary>
        string DifficultyString { get; }

        /// <summary>
        /// The difficulty type
        /// </summary>
        Maze2D GetRandomMaze();
    }
}
