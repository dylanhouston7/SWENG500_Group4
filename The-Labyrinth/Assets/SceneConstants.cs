// File: SceneConstants.cs
// Description: Lists the various scenes in the project
// Author: Dylan Houston

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    /// <summary>
    /// Stores strings representing various scenes in the project
    /// </summary>
    public static class SceneConstants
    {
        /// <summary>
        /// Points to the main scene-- the first maze
        /// </summary>
        public const string MainScene = "MainScene";

        /// <summary>
        /// Points to the difficulty menu scene
        /// </summary>
        public const string DifficultyScene = "DifficultyScene";

        /// <summary>
        /// Points to the maze complete (scoring) scene
        /// </summary
        public const string MazeCompleteScene = "MazeComplete";

        /// <summary>
        /// Points to the main menu scene
        /// </summary
        public const string MainMenuScene = "MainMenu";
    }
}
