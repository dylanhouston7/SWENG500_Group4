// File: DifficultyFactoryTest.cs
// Description: Specifies unit tests for the difficulty factory
// Author: Dylan Houston

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.Scripts.DifficultySettings;

namespace The_LabyrinthUnitTest
{
    /// <summary>
    /// A class to unit test the DifficultyFactory class
    /// </summary>
    [TestClass]
    public class DifficultyFactoryTest
    {
        /// <summary>
        /// Tests to ensure that the difficulty factory works as intended for easy mode
        /// </summary>
        [TestMethod]
        public void TestDifficultyFactoryForEasy()
        {
            IDifficulty difficulty = DifficultyFactory.CreateDifficulty(DifficultyEnum.EASY);
            Assert.AreEqual(difficulty.GetType(), typeof(EasyDifficulty));
        }

        /// <summary>
        /// Tests to ensure that the difficulty factory works as intended for medium mode
        /// </summary>
        [TestMethod]
        public void TestDifficultyFactoryForMedium()
        {
            IDifficulty difficulty = DifficultyFactory.CreateDifficulty(DifficultyEnum.MEDIUM);
            Assert.AreEqual(difficulty.GetType(), typeof(MediumDifficulty));
        }

        /// <summary>
        /// Tests to ensure that the difficulty factory works as intended for hard mode
        /// </summary>
        [TestMethod]
        public void TestDifficultyFactoryForHard()
        {
            IDifficulty difficulty = DifficultyFactory.CreateDifficulty(DifficultyEnum.HARD);
            Assert.AreEqual(difficulty.GetType(), typeof(HardDifficulty));
        }

        /// <summary>
        /// Tests to ensure that the difficulty factory works as intended for epic mode
        /// </summary>
        [TestMethod]
        public void TestDifficultyFactoryForEpic()
        { 
            IDifficulty difficulty = DifficultyFactory.CreateDifficulty(DifficultyEnum.EPIC);
            Assert.AreEqual(difficulty.GetType(), typeof(EpicDifficulty));
        }
    }
}
