using Assets.Scripts.Timer;
using MazeStructure;
using System;
using Assets.Scripts.DifficultySettings;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assets.Scripts.DifficultySettings.Tests
{
    /// <summary>This class contains parameterized unit tests for EpicDifficulty</summary>
    [TestClass]
    [PexClass(typeof(EpicDifficulty))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class EpicDifficultyTest
    {

        /// <summary>Test stub for GetRandomMaze()</summary>
        [PexMethod]
        public Maze2D GetRandomMazeTest([PexAssumeUnderTest]EpicDifficulty target)
        {
            Maze2D result = target.GetRandomMaze();
            return result;
            // TODO: add assertions to method EpicDifficultyTest.GetRandomMazeTest(EpicDifficulty)
        }

        /// <summary>Test stub for ResetTimer()</summary>
        [PexMethod]
        public void ResetTimerTest([PexAssumeUnderTest]EpicDifficulty target)
        {
            target.ResetTimer();
            // TODO: add assertions to method EpicDifficultyTest.ResetTimerTest(EpicDifficulty)
        }

        /// <summary>Test stub for get_Description()</summary>
        [PexMethod]
        public string DescriptionGetTest([PexAssumeUnderTest]EpicDifficulty target)
        {
            string result = target.Description;
            return result;
            // TODO: add assertions to method EpicDifficultyTest.DescriptionGetTest(EpicDifficulty)
        }

        /// <summary>Test stub for get_Difficulty()</summary>
        [PexMethod]
        public DifficultyEnum DifficultyGetTest([PexAssumeUnderTest]EpicDifficulty target)
        {
            DifficultyEnum result = target.Difficulty;
            return result;
            // TODO: add assertions to method EpicDifficultyTest.DifficultyGetTest(EpicDifficulty)
        }

        /// <summary>Test stub for get_DifficultyString()</summary>
        [PexMethod]
        public string DifficultyStringGetTest([PexAssumeUnderTest]EpicDifficulty target)
        {
            string result = target.DifficultyString;
            return result;
            // TODO: add assertions to method EpicDifficultyTest.DifficultyStringGetTest(EpicDifficulty)
        }

        /// <summary>Test stub for get_GetScoringMultiplier()</summary>
        [PexMethod]
        public int GetScoringMultiplierGetTest([PexAssumeUnderTest]EpicDifficulty target)
        {
            int result = target.GetScoringMultiplier;
            return result;
            // TODO: add assertions to method EpicDifficultyTest.GetScoringMultiplierGetTest(EpicDifficulty)
        }

        /// <summary>Test stub for get_Timer()</summary>
        [PexMethod]
        public ITimer TimerGetTest([PexAssumeUnderTest]EpicDifficulty target)
        {
            ITimer result = target.Timer;
            return result;
            // TODO: add assertions to method EpicDifficultyTest.TimerGetTest(EpicDifficulty)
        }

        /// <summary>Test stub for set_Timer(ITimer)</summary>
        [PexMethod]
        public void TimerSetTest([PexAssumeUnderTest]EpicDifficulty target, ITimer value)
        {
            target.Timer = value;
            // TODO: add assertions to method EpicDifficultyTest.TimerSetTest(EpicDifficulty, ITimer)
        }
    }
}
