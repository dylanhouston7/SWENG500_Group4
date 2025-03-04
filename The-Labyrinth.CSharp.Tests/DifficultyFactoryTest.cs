using System;
using Assets.Scripts.DifficultySettings;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assets.Scripts.DifficultySettings.Tests
{
    /// <summary>This class contains parameterized unit tests for DifficultyFactory</summary>
    [TestClass]
    [PexClass(typeof(DifficultyFactory))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class DifficultyFactoryTest
    {

        /// <summary>Test stub for CreateDifficulty(DifficultyEnum)</summary>
        [PexMethod]
        public IDifficulty CreateDifficultyTest(DifficultyEnum difficultyMode)
        {
            IDifficulty result = DifficultyFactory.CreateDifficulty(difficultyMode);
            return result;
            // TODO: add assertions to method DifficultyFactoryTest.CreateDifficultyTest(DifficultyEnum)
        }
    }
}
