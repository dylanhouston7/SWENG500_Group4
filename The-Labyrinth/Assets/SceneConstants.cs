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

        /// <summary>
        /// Points to the settings scene
        /// </summary
        public const string SettingsScene = "Settings";

        /// <summary>
        /// Points to the Account Registration scene
        /// </summary
        public const string RegisterScene = "AccountRegister";
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
            new MaterialResource("GibionWall", "Materials/Architecture/Gabion wall Mat", MaterialResource.MaterialTypeEnum.kArchitecture),

            new MaterialResource("CobblePattern01", "Materials/Stone/Cobble pattern 01", MaterialResource.MaterialTypeEnum.kStone),
            new MaterialResource("CobblePattern02", "Materials/Stone/Cobble pattern 02", MaterialResource.MaterialTypeEnum.kStone),
            new MaterialResource("CobblePattern03", "Materials/Stone/Cobble pattern 03", MaterialResource.MaterialTypeEnum.kStone),
            new MaterialResource("CobblePattern04", "Materials/Stone/Cobble pattern 04", MaterialResource.MaterialTypeEnum.kStone),
            new MaterialResource("CobblePattern05", "Materials/Stone/Cobble pattern 05", MaterialResource.MaterialTypeEnum.kStone),
            new MaterialResource("CobblePattern06", "Materials/Stone/Cobble pattern 06", MaterialResource.MaterialTypeEnum.kStone),
            new MaterialResource("CobblePattern07", "Materials/Stone/Cobble pattern 07", MaterialResource.MaterialTypeEnum.kStone),
            new MaterialResource("CobblePattern08", "Materials/Stone/Cobble pattern 08", MaterialResource.MaterialTypeEnum.kStone),
            new MaterialResource("CobblePattern09", "Materials/Stone/Cobble pattern 09", MaterialResource.MaterialTypeEnum.kStone),
            new MaterialResource("CobblePattern10", "Materials/Stone/Cobble pattern 10", MaterialResource.MaterialTypeEnum.kStone),
            new MaterialResource("CobblePattern11", "Materials/Stone/Cobble pattern 11", MaterialResource.MaterialTypeEnum.kStone),
            new MaterialResource("CobblePattern12", "Materials/Stone/Cobble pattern 12", MaterialResource.MaterialTypeEnum.kStone),
            new MaterialResource("CobblePattern13", "Materials/Stone/Cobble pattern 13", MaterialResource.MaterialTypeEnum.kStone),

            new MaterialResource("PavementPattern01", "Materials/Pavement/pavement pattern 01", MaterialResource.MaterialTypeEnum.kPavement),
            new MaterialResource("PavementPattern02", "Materials/Pavement/pavement pattern 02", MaterialResource.MaterialTypeEnum.kPavement),
            new MaterialResource("PavementPattern03", "Materials/Pavement/pavement pattern 03", MaterialResource.MaterialTypeEnum.kPavement),
            new MaterialResource("PavementPattern04", "Materials/Pavement/pavement pattern 04", MaterialResource.MaterialTypeEnum.kPavement),
            new MaterialResource("PavementPattern05", "Materials/Pavement/pavement pattern 05", MaterialResource.MaterialTypeEnum.kPavement),
            new MaterialResource("PavementPattern06", "Materials/Pavement/pavement pattern 06", MaterialResource.MaterialTypeEnum.kPavement),
            new MaterialResource("PavementPattern07", "Materials/Pavement/pavement pattern 07", MaterialResource.MaterialTypeEnum.kPavement),
            new MaterialResource("PavementPattern08", "Materials/Pavement/pavement pattern 08", MaterialResource.MaterialTypeEnum.kPavement),
            new MaterialResource("PavementPattern13", "Materials/Pavement/pavement pattern 13", MaterialResource.MaterialTypeEnum.kPavement),
            new MaterialResource("PavementPattern14", "Materials/Pavement/pavement pattern 14", MaterialResource.MaterialTypeEnum.kPavement),
            new MaterialResource("PavementPattern15", "Materials/Pavement/pavement pattern 15", MaterialResource.MaterialTypeEnum.kPavement),
            new MaterialResource("PavementPattern16", "Materials/Pavement/pavement pattern 16", MaterialResource.MaterialTypeEnum.kPavement),
            new MaterialResource("PavementPattern17", "Materials/Pavement/pavement pattern 17", MaterialResource.MaterialTypeEnum.kPavement),
            new MaterialResource("PavementPattern18", "Materials/Pavement/pavement pattern 18", MaterialResource.MaterialTypeEnum.kPavement),
            new MaterialResource("PavementPattern19", "Materials/Pavement/pavement pattern 19", MaterialResource.MaterialTypeEnum.kPavement),
            new MaterialResource("PavementPattern20", "Materials/Pavement/pavement pattern 20", MaterialResource.MaterialTypeEnum.kPavement),

            new MaterialResource("Concrete01", "Materials/Concrete/Concrete pattern 01", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete02", "Materials/Concrete/Concrete pattern 02", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete03", "Materials/Concrete/Concrete pattern 03", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete04", "Materials/Concrete/Concrete pattern 04", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete05", "Materials/Concrete/Concrete pattern 05", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete06", "Materials/Concrete/Concrete pattern 06", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete07", "Materials/Concrete/Concrete pattern 07", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete08", "Materials/Concrete/Concrete pattern 08", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete09", "Materials/Concrete/Concrete pattern 09", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete10", "Materials/Concrete/Concrete pattern 10", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete11", "Materials/Concrete/Concrete pattern 11", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete12", "Materials/Concrete/Concrete pattern 12", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete13", "Materials/Concrete/Concrete pattern 13", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete14", "Materials/Concrete/Concrete pattern 14", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete15", "Materials/Concrete/Concrete pattern 15", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete16", "Materials/Concrete/Concrete pattern 16", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete17", "Materials/Concrete/Concrete pattern 17", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete18", "Materials/Concrete/Concrete pattern 18", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete19", "Materials/Concrete/Concrete pattern 19", MaterialResource.MaterialTypeEnum.kConcrete),
            new MaterialResource("Concrete20", "Materials/Concrete/Concrete pattern 20", MaterialResource.MaterialTypeEnum.kConcrete),

            new MaterialResource("GroundDryEarthPattern", "Materials/Ground/Dry ground pattern", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundGrassDeadLeavesPattern01", "Materials/Ground/Grass & dead leafs pattern 01", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundGrassDeadLeavesPattern02", "Materials/Ground/Grass & dead leafs pattern 02", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundGrassRocksPattern", "Materials/Ground/Grass & rocks pattern", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundGrassPattern01", "Materials/Ground/Grass pattern 01", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundGrassPattern02", "Materials/Ground/Grass pattern 02", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundGrassPattern03", "Materials/Ground/Grass pattern 03", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundGrassPattern04", "Materials/Ground/Grass pattern 04", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundGrassPattern05", "Materials/Ground/Grass pattern 05", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundGrassPattern06", "Materials/Ground/Grass pattern 06", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundMossPattern", "Materials/Ground/Ground & moss pattern", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundRocksPattern01", "Materials/Ground/Ground & rocks pattern 01", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundRocksPattern02", "Materials/Ground/Ground & rocks pattern 02", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundRocksPattern03", "Materials/Ground/Ground & rocks pattern 03", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundWeedsPattern", "Materials/Ground/Ground & weeds", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundPattern01", "Materials/Ground/Ground pattern 01", MaterialResource.MaterialTypeEnum.kGround),
            new MaterialResource("GroundPattern02", "Materials/Ground/Ground pattern 02", MaterialResource.MaterialTypeEnum.kGround)
        };
        

        public static IList<MaterialResource> GetMaterialResources()
        {
            return m_material_resources.AsReadOnly();
        }
    }
}
