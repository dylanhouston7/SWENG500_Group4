using Assets.Scripts.DifficultySettings;
using System;
using Assets.Scripts.Scoring;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assets.Scripts.Scoring.Tests
{
    /// <summary>This class contains parameterized unit tests for ScoreCalculator</summary>
    [TestClass]
    [PexClass(typeof(ScoreCalculator))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ScoreCalculatorTest
    {

        /// <summary>Test stub for CalculateScore(IDifficulty, Int32, Int32)</summary>
        [PexMethod]
        public ScoreContainer CalculateScoreTest(
            IDifficulty difficulty,
            int mazeCompletionTimeInSeconds,
            int hintCount
        )
        {
            ScoreContainer result
               = ScoreCalculator.CalculateScore(difficulty, mazeCompletionTimeInSeconds, hintCount);
            return result;
            // TODO: add assertions to method ScoreCalculatorTest.CalculateScoreTest(IDifficulty, Int32, Int32)
        }
    }
}
