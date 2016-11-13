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
        /// Points to the maze level scene
        /// </summary
        public const string MazeLevelScene = "MazeLevelScene";

        /// <summary>
        /// Points to the maze complete (scoring) scene
        /// </summary
        public const string MazeCompleteScene = "MazeComplete";

        /// <summary>
        /// Points to the main menu scene
        /// </summary
        public const string MainMenuScene = "MainMenu";

        /// <summary>
        /// Points to the maze generator scene
        /// </summary
        public const string MazeGeneratorScene = "MazeGen";

        /// <summary>
        /// Points to the import maze scene
        /// </summary
        public const string MazeImportScene = "ImportMazeScene";

        /// <summary>
        /// Points to the game over scene
        /// </summary
        public const string GameOverScene = "GameOver";

        /// <summary>
        /// Points to the credits scene
        /// </summary
        public const string CreditsScene = "Credits";
    }

    public class MaterialResources
    {
        public class MaterialResource
        {
            public String name;
            public String path;

            public enum MaterialTypeEnum
            {
                kGround = 0,
                kConcrete,
                kPavement,
                kStone,
                kArchitecture
            };
            public MaterialTypeEnum type;

            public MaterialResource(String resName, String resPath, MaterialTypeEnum resType)
            {
                name = resName;
                path = resPath;
                type = resType;
            }
        }

        private static List<MaterialResource> m_material_resources = new List<MaterialResource>
        {
            new MaterialResource("BricksGrey", "Materials/Architecture/Bricks grey Mat", MaterialResource.MaterialTypeEnum.kArchitecture),
            new MaterialResource("BricksRedRough", "Materials/Architecture/Bricks red rough Mat", MaterialResource.MaterialTypeEnum.kArchitecture),
            new MaterialResource("BricksRedSmooth", "Materials/Architecture/Bricks red smooth Mat", MaterialResource.MaterialTypeEnum.kArchitecture),
            new MaterialResource("BricksRough", "Materials/Architecture/Bricks rough Mat", MaterialResource.MaterialTypeEnum.kArchitecture),
            new MaterialResource("BricksWeathered", "Materials/Architecture/Bricks weathered Mat", MaterialResource.MaterialTypeEnum.kArchitecture),
            new MaterialResource("GibionWall", "Materials/Architecture/Gibion wall Mat", MaterialResource.MaterialTypeEnum.kArchitecture)
        };

        public static IList<MaterialResource> GetMaterialResources()
        {
            return m_material_resources.AsReadOnly();
        }
    }
}
