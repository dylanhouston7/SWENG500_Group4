// File: IDifficulty.cs
// Description: Specifies an interface to use for all difficulty levels
// Author: Dylan Houston

using Assets.Scripts.Timer;

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

    }
}
