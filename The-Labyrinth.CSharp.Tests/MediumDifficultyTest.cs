using Assets.Scripts.Timer;
using MazeStructure;
using System;
using Assets.Scripts.DifficultySettings;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assets.Scripts.DifficultySettings.Tests
{
    /// <summary>This class contains parameterized unit tests for MediumDifficulty</summary>
    [TestClass]
    [PexClass(typeof(MediumDifficulty))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class MediumDifficultyTest
    {

        /// <summary>Test stub for GetRandomMaze()</summary>
        [PexMethod]
        public Maze2D GetRandomMazeTest([PexAssumeUnderTest]MediumDifficulty target)
        {
            Maze2D result = target.GetRandomMaze();
            return result;
            // TODO: add assertions to method MediumDifficultyTest.GetRandomMazeTest(MediumDifficulty)
        }

        /// <summary>Test stub for ResetTimer()</summary>
        [PexMethod]
        public void ResetTimerTest([PexAssumeUnderTest]MediumDifficulty target)
        {
            target.ResetTimer();
            // TODO: add assertions to method MediumDifficultyTest.ResetTimerTest(MediumDifficulty)
        }

        /// <summary>Test stub for get_Description()</summary>
        [PexMethod]
        public string DescriptionGetTest([PexAssumeUnderTest]MediumDifficulty target)
        {
            string result = target.Description;
            return result;
            // TODO: add assertions to method MediumDifficultyTest.DescriptionGetTest(MediumDifficulty)
        }

        /// <summary>Test stub for get_Difficulty()</summary>
        [PexMethod]
        public DifficultyEnum DifficultyGetTest([PexAssumeUnderTest]MediumDifficulty target)
        {
            DifficultyEnum result = target.Difficulty;
            return result;
            // TODO: add assertions to method MediumDifficultyTest.DifficultyGetTest(MediumDifficulty)
        }

        /// <summary>Test stub for get_DifficultyString()</summary>
        [PexMethod]
        public string DifficultyStringGetTest([PexAssumeUnderTest]MediumDifficulty target)
        {
            string result = target.DifficultyString;
            return result;
            // TODO: add assertions to method MediumDifficultyTest.DifficultyStringGetTest(MediumDifficulty)
        }

        /// <summary>Test stub for get_GetScoringMultiplier()</summary>
        [PexMethod]
        public int GetScoringMultiplierGetTest([PexAssumeUnderTest]MediumDifficulty target)
        {
            int result = target.GetScoringMultiplier;
            return result;
            // TODO: add assertions to method MediumDifficultyTest.GetScoringMultiplierGetTest(MediumDifficulty)
        }

        /// <summary>Test stub for get_Timer()</summary>
        [PexMethod]
        public ITimer TimerGetTest([PexAssumeUnderTest]MediumDifficulty target)
        {
            ITimer result = target.Timer;
            return result;
            // TODO: add assertions to method MediumDifficultyTest.TimerGetTest(MediumDifficulty)
        }

        /// <summary>Test stub for set_Timer(ITimer)</summary>
        [PexMethod]
        public void TimerSetTest([PexAssumeUnderTest]MediumDifficulty target, ITimer value)
        {
            target.Timer = value;
            // TODO: add assertions to method MediumDifficultyTest.TimerSetTest(MediumDifficulty, ITimer)
        }
    }
}
